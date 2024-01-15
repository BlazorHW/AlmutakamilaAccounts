using System.ComponentModel.DataAnnotations;

namespace Accounts.Model;

public class MakeJournalBody 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [StringLength(100, ErrorMessage = "يحمل 100 حرف فقط")]
    public string Details { get; set; }
    /// مدين
    /// </summary>
    public decimal? Debit { get; set; }
    /// <summary>
    /// دائن
    /// </summary>
    public decimal? Credit { get; set; }
    /// <summary>
    /// حركة الرصيد
    /// </summary>
    public decimal? BalanceMovement { get; set; }
    public Guid MakeJournalHeadId { get; set; }
    public MakeJournalHead? makeJournalHead { get; set; }
    public Guid AccountssId { get; set; }
    public Accountss? accountss { get; set; }
    public Guid CostCenterId { get; set; }
    public CostCenter? costCenter { get; set; }
}
