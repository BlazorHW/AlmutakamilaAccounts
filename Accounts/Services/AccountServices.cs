using Accounts.Data.Interfaces;
using Accounts.Model;
using Accounts.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Services
{
    public class AccountServices(IUnitOfWork<Accountss> _account)
    {
        // Get All Account
        public async Task<IEnumerable<Accountss>> GetAllAccounts()
        {
            return await _account.Entity.GetAll().Include(x => x.Parent).Include(x => x.AccountType).ToListAsync();
        }
        // Add Account
        public async Task<ResponseVM> AddAccAsync(Accountss accountss)
        {
            if (_account.Entity.Find(x => x.AccNumer == accountss.AccNumer).Count() > 0)
            {
                return new ResponseVM() { State = false, Message = "رقم الحساب موجود مسبقا" };
            }
            if (_account.Entity.Find(x => x.AccName == accountss.AccName).Count() > 0)
            {
                return new ResponseVM() { State = false, Message = "رقم الحساب موجود مسبقا" };
            }
            _account.Entity.Insert(new Accountss()
            {
                AccName = accountss.AccName,
                AccNumer = accountss.AccNumer,
                Details = accountss.Details,
                IsProfit = accountss.IsProfit,
                ParentId = accountss.Parent?.Id,
                AccountTypeId = accountss.AccountType.Id,
            });
            await _account.SaveAsync();
            return new ResponseVM() { State = true, Message = "تم الحفظ بنجاح" };
        }
        // Delete Account
        public async Task<ResponseVM> DeleteAccountAsync(Guid Id)
        {
            var OldeAcc = await _account.Entity.GetByIdAsync(Id);
            if (OldeAcc == null)
            {
                return new ResponseVM() { State = false, Message = "تم الحدف من قبل مستخدم اخر" };
            }
            _account.Entity.Delete(Id);
            await _account.SaveAsync();
            return new ResponseVM() { State = true, Message = "تم الحدف بنجاح" };
        }
        // Get By Id
        public async Task<Accountss> GetAccountByIdAsync(Guid Id) =>
            await _account.Entity.Find(x => x.Id == Id, false).Include(x=>x.AccountType).Include(x=>x.Parent)
            .FirstAsync();
        // Edit
        public async Task<ResponseVM> EditAccountAsync(Guid Id,Accountss accounts)
        {
            var OldAccount = await _account.Entity.GetByIdAsync(Id);
            if (OldAccount == null)
            {
                return new ResponseVM() { State = false, Message = "الحساب لم يعد موجود" };
            }
            OldAccount.AccNumer = accounts.AccNumer;
            OldAccount.AccName = accounts.AccName;
            OldAccount.IsProfit = accounts.IsProfit;
            OldAccount.ParentId = accounts.ParentId;
            OldAccount.AccountTypeId = accounts.AccountType.Id;
            _account.Entity.Update(OldAccount);
            await _account.SaveAsync();
            return new ResponseVM() { State = true, Message = "تم الحفظ بنجاح" };
        }
    }
}
