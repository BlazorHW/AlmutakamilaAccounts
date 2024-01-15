using Accounts.Data.Interfaces;
using Accounts.Model;
using Accounts.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Services;

public class CostCenterServices(IUnitOfWork<CostCenter> _costCenter)
{
    // Get All
    public async Task<IEnumerable<CostCenter>> GetAllCostCenter()
    {
        return await _costCenter.Entity.GetAll().ToListAsync();
    } 
    // Add
    public async Task<ResponseVM> AddCostCenterAsync(CostCenter costCenter)
    {
        if (_costCenter.Entity.Find(x => x.AccName == costCenter.AccName).Count() > 0)
        {
            return new ResponseVM { State = false, Message = "name account exist" };
        }
        if (_costCenter.Entity.Find(x => x.AccNumer == costCenter.AccNumer).Count() > 0)
        {
            return new ResponseVM { State = false, Message = "number account exist" };
        }
        _costCenter.Entity.Insert(new CostCenter
        {
            AccName = costCenter.AccName,
            AccNumer = costCenter.AccNumer,
        });
        await _costCenter.SaveAsync();
        return new ResponseVM { State = true, Message = "saved done" };
    }
    // Deletet
    public async Task<ResponseVM> DeleteCostCenterAsync(Guid Id)
    {
        var Oldcostcenter = await _costCenter.Entity.GetByIdAsync(Id);
        if (Oldcostcenter != null)  new ResponseVM { State = false, Message = "لم يتم العتور على الحساب" };
        _costCenter.Entity.Delete(Id);
        await _costCenter.SaveAsync();
        return new ResponseVM { State = true, Message = "تم الحدف بنجاح" };
    }
    // Get By ID
    public async Task<CostCenter> GetCostCenterById(Guid Id) =>
        await _costCenter.Entity.Find(x=>x.Id == Id,false).FirstAsync();

    public async Task<ResponseVM> EditCostCenterAsync(Guid Id , CostCenter costCenter)
    {
        var OldCostcenter = await _costCenter.Entity.GetByIdAsync(Id);
        if (OldCostcenter == null)
            return new ResponseVM() { State = false, Message = "الحساب لم يعد موجود!" };
        OldCostcenter.AccNumer = costCenter.AccNumer;
        OldCostcenter.AccName = costCenter.AccName;
        _costCenter.Entity.Update(OldCostcenter);
        _costCenter.SaveAsync();
        return new ResponseVM() { State = true, Message = "تم الحفظ بنجاح" };
    }
}
