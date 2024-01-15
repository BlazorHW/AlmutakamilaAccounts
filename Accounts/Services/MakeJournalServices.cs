using Accounts.Data.Interfaces;
using Accounts.Model;
using Accounts.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Accounts.Services;

public class MakeJournalServices(IUnitOfWork<MakeJournalHead> _makeJournalHead, IUnitOfWork<MakeJournalBody> _makeJournalBody)
{
    public async Task<IEnumerable<MakeJournalHead>> GetAllJournalEntry() =>
        await _makeJournalHead.Entity.Find(x=>x.IsDeleted == false,false).Include(x => x.makeJournalsbodis).ToListAsync();

    public async Task<ResponseVM> AddJournalAsync(MakeJournalHead journalHead)
    {
        if (_makeJournalHead.Entity.Find(x => x.Id == journalHead.Id).Count() > 1)
        {
            return new ResponseVM() { State = false, Message = "موجود مسبقا" };
        }
        _makeJournalHead.Entity.Insert(new MakeJournalHead()
        {
            Date = journalHead.Date,
            Details = journalHead.Details,
            EntryJournal = journalHead.EntryJournal,
            makeJournalsbodis = journalHead.makeJournalsbodis.Select(x => { x.accountss = null; return x; }).
            Select(x => { x.costCenter = null; return x; }).ToList()
        });
        await _makeJournalHead.SaveAsync();
        return new ResponseVM() { State = true, Message = "تم الحفظ بنجاح" };
    }

    public async Task<ResponseVM> DeleteJournalAsync(Guid Id)
    {
        var oldjournal = await _makeJournalHead.Entity.GetByIdAsync(Id);
       if (oldjournal == null) { return new ResponseVM() { State = false, Message = "deleted" }; }
        oldjournal.IsDeleted = true;
       _makeJournalHead.Entity.Update(oldjournal);
        await _makeJournalHead.SaveAsync();
        return new ResponseVM() { State = true, Message = "delete don" };
    }

    public async Task<MakeJournalHead> GetByIdJournal(Guid Id)
    {
        if (Id != Guid.Empty)
            return await _makeJournalHead.Entity.Find(x => x.Id == Id, Tracking: false)
                .Include(x => x.makeJournalsbodis).ThenInclude(x => x.accountss)
                .Include(x => x.makeJournalsbodis).ThenInclude(x => x.costCenter).FirstAsync();

        else
            return await _makeJournalHead.Entity.GetAll().OrderByDescending(x => x.Id)
                .Include(x => x.makeJournalsbodis).ThenInclude(x => x.accountss).Include(x => x.makeJournalsbodis)
                .ThenInclude(x => x.costCenter).FirstAsync();
    }

    public async Task<ResponseVM> EditJournalAsync(Guid Id,MakeJournalHead journalHead)
    {
        var OldJournal = await _makeJournalHead.Entity.Find(x=>x.Id == Id,false).Include(x=>x.makeJournalsbodis).FirstAsync();
        if (OldJournal == null) return new ResponseVM() { State = true, Message = "القيد غير موجود" };
        ////حذف كل (MakeJournalBody)  من قاعدة البيانات 
        ///-------------------
        ////اخذ البيانات الجديدة في اوبجكت مفصول
        List<MakeJournalBody> bodies = journalHead.makeJournalsbodis.Select(x=> new MakeJournalBody
        {
            //AccountssId = x.AccountssId,
            //CostCenterId = x.CostCenterId,
            MakeJournalHeadId = x.MakeJournalHeadId,
            accountss = x.accountss,
            costCenter = x.costCenter,
            Debit = x.Debit,
            Credit = x.Credit,
            Details = x.Details,
        }).ToList();
        ///--------------------------------------------------------
        //تفريغ البيانات الجديدة 
        journalHead.makeJournalsbodis = null;
        //حذف كل البيانات القديمة
        if (OldJournal.makeJournalsbodis != null) _makeJournalBody.Entity.RemoveRange(OldJournal.makeJournalsbodis);
        ///--------------------------------------------------------
        //تعديل البيانات القديمة
        OldJournal.Details = journalHead.Details;
        OldJournal.Date = journalHead.Date;
        OldJournal.makeJournalsbodis = bodies; //اضافة كل البيانات
        _makeJournalHead.Entity.Update(OldJournal);
        ///--------------------------------------------------------
        await _makeJournalBody.SaveAsync();
        await _makeJournalHead.SaveAsync();
        return new ResponseVM() { State = true, Message = "تم الحفظ بنجاح" };
    }
}
