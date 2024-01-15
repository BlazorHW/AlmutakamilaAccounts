using Accounts.Data.Interfaces;
using Accounts.Model;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Services;

public class AccountTypeServicse(IUnitOfWork<AccountType> _acctype)
{
    public async Task<IEnumerable<AccountType>> GetAllAccountTypes()
    {
        return await _acctype.Entity.GetAll().ToListAsync();
    }
}
