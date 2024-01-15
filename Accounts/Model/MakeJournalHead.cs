using System.ComponentModel.DataAnnotations;

namespace Accounts.Model;

public class MakeJournalHead 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required(ErrorMessage = "ادخل التاريخ بشكل صحيح")]
    public DateTime? Date { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "يجب ادخال ارقام فقط")]
    public int EntryJournal { get; set; }
    [StringLength(100,ErrorMessage ="يحمل 100 حرف فقط")]
    public string Details { get; set; }
    public bool IsDeleted { get; set; } 
    public ICollection<MakeJournalBody> makeJournalsbodis { get; set; } = new HashSet<MakeJournalBody>();
}
