using Microsoft.EntityFrameworkCore;

namespace Accounts.Model;
[Index("AccName", IsUnique = true)]
public class CostCenter : BassEntity
{
}
