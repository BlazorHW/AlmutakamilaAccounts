using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Accounts.Model;

public class BassEntity
{
    public Guid Id { get; set; }= Guid.NewGuid();
    [Required(ErrorMessage = "يجب ادخال رقم حساب")]
    //[StringLength(6,ErrorMessage = "حقل يحمل 6 ارقام فقط")]
    public int AccNumer {  get; set; }

    [Required(ErrorMessage = "يجب ادخال اسم حساب")]
    [StringLength(50, ErrorMessage = "حقل يحمل 50 حرف فقط")]
    public string AccName { get; set; }

    [StringLength(200,ErrorMessage = "حقل يحمل 200 حرف فقط")]
    public string? Details { get; set; }
}
