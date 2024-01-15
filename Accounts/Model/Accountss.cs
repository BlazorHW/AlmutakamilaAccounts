using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Model;
[Index("AccName",IsUnique =true)]
public class Accountss : BassEntity
{
    /// <summary>
    /// الميزانية - قائمة الدخل
    /// </summary>
    public bool IsProfit { get; set; }
    /// <summary>
    /// حساب فرعي -حساب رئيسي
    /// </summary>
    public Guid? ParentId { get; set; } =Guid.NewGuid();
    public Accountss? Parent { get; set; }

    public Guid AccountTypeId { get; set; }
    public AccountType? AccountType { get; set; }
}
