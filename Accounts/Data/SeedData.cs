using Microsoft.EntityFrameworkCore;

namespace Accounts.Data;

public class SeedData
{
    private readonly AccountingDbContext _context;
    public SeedData(AccountingDbContext context)
    {
        _context = context;
    }
    public async Task _intz()
    {
        await _context.Database.MigrateAsync();
        if (!_context.accountTypes.Any(x => x.AccName == "الاصول"))
        {
            _context.accountTypes.Add(new() { AccName = "الاصول" });
            _context.accountTypes.Add(new() { AccName = "الخصوم" });
            _context.accountTypes.Add(new() { AccName = "الايرادات" });
            _context.accountTypes.Add(new() { AccName = "المصروفات" });
            //_context.accounts.Add(new() { AccNumer = 00, AccName = "قيد افتتاحي" });
            //_context.accounts.Add(new() { IsProfit = true, AccNumer = 1, AccName = "/الاصول" });
            //_context.accounts.Add(new() { IsProfit = true, AccNumer = 11, AccName = "/الاصول الثابتة" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 113, AccName = "الات" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 114, AccName = "اثاث" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 12, AccName = "/الاصول متداولة" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 121, AccName = "/العملاء" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 12101, AccName = "عميل 1" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 122, AccName = "/مسحوبات الشركاء" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 12201, AccName = "مسحوبات شريك 1" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 123, AccName = "المخزون" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 124, AccName = "عهدة نقدية/" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 12401, AccName = "1 عهدة فلان" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 125, AccName = " سلفة عاملين/" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 12501, AccName = " سلفة عامل 1" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 126, AccName = " ايرادات متنوعة (عملاء)" });
            //_context.accounts.Add(new() { IsProfit = true, AccNumer = 13, AccName = "/الاموال جاهزة" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 131, AccName = "الصندوق" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 132, AccName = "الخزينة" });
            //_context.accounts.Add(new() {  IsProfit = true, AccNumer = 133, AccName = "بنك 1" });


            await _context.SaveChangesAsync();
        }
        // تحقق من وجود الحساب قبل إضافته
        //if (!_context.accounts.Any(a => a.AccNumer == 00))
        //{
        //    _context.accounts.Add(new() { AccNumer = 00, AccName = "قيد افتتاحي" });
        //    _context.accounts.Add(new() { IsProfit = true, AccNumer = 1, AccName = "/الاصول" });
        //_context.accounts.Add(new() { ParentId = 2, IsBudgetProfit = true, NumberAccount = 11, AccName = "/الاصول الثابتة" });
        //_context.accounts.Add(new() { ParentId = 3, IsBudgetProfit = true, NumberAccount = 111, AccName = "الاراضي" });
        //_context.accounts.Add(new() { ParentId = 3, IsBudgetProfit = true, NumberAccount = 112, AccName = "مباني" });
        //_context.accounts.Add(new() { ParentId = 3, IsBudgetProfit = true, NumberAccount = 113, AccName = "الات" });
        //_context.accounts.Add(new() { ParentId = 3, IsBudgetProfit = true, NumberAccount = 114, AccName = "اثاث" });
        //_context.accounts.Add(new() { ParentId = 2, IsBudgetProfit = true, NumberAccount = 12, AccName = "/الاصول متداولة" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 121, AccName = "/العملاء" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12101, AccName = "عميل 1" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12102, AccName = "عميل 2" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 122, AccName = "/مسحوبات الشركاء" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12201, AccName = "مسحوبات شريك 1" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12202, AccName = "مسحوبات شريك 2" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 123, AccName = "المخزون" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 124, AccName = "عهدة نقدية/" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12401, AccName = "1 عهدة فلان" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12402, AccName = "2 عهدة فلان" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 125, AccName = " سلفة عاملين/" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12501, AccName = " سلفة عامل 1" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 12502, AccName = " سلفة عامل 2" });
        //_context.accounts.Add(new() { ParentId = 8, IsBudgetProfit = true, NumberAccount = 126, AccName = " ايرادات متنوعة (عملاء)" });
        //_context.accounts.Add(new() { ParentId = 2, IsBudgetProfit = true, NumberAccount = 13, AccName = "/الاموال جاهزة" });
        //_context.accounts.Add(new() { ParentId = 23, IsProfit = true, NumberAccount = 131, AccName = "الصندوق" });
        //_context.accounts.Add(new() { ParentId = 23, IsProfit = true, NumberAccount = 132, AccName = "الخزينة" });
        //_context.accounts.Add(new() { ParentId = 23, IsProfit = true, NumberAccount = 133, AccName = "بنك 1" });
        //_context.accounts.Add(new() { ParentId = 23, IsProfit = true, NumberAccount = 134, AccName = "بنك 2" });

        //_context.accounts.Add(new() { IsBudgetProfit = true, NumberAccount = 2, AccName = "/الخصوم" });
        //_context.accounts.Add(new() { ParentId = 28, IsBudgetProfit = true, NumberAccount = 21, AccName = "الخصوم الثابتة/" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 211, AccName = "راس المال/" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 21101, AccName = "راس المال الشركاء" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 212, AccName = "القروض" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 213, AccName = "حقوق اصحاب المشروع" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 22, AccName = "/الخصوم المتداولة" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 221, AccName = "/الموردون" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 22101, AccName = "مورد 1" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 22102, AccName = "مورد 2" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 222, AccName = "دائنون مختلفون" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 223, AccName = "/اجور مرتبات" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 22301, AccName = "مرتب فلان 1" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 22302, AccName = "مرتب فلان 2" });
        //_context.accounts.Add(new() { ParentId = 29, IsBudgetProfit = true, NumberAccount = 224, AccName = "ارباح غير موزعة" });

        //_context.accounts.Add(new() { NumberAccount = 3, AccName = "/صافي الايرادات" });
        //_context.accounts.Add(new() { ParentId = 43, NumberAccount = 31, AccName = "الايرادات" });
        //_context.accounts.Add(new() { ParentId = 44, NumberAccount = 32, AccName = "مردود المبيعات" });
        //_context.accounts.Add(new() { ParentId = 44, NumberAccount = 33, AccName = "ايرادات متنوعة" });
        //_context.accounts.Add(new() { ParentId = 44, NumberAccount = 34, AccName = "خصم مكتسب" });
        //_context.accounts.Add(new() { ParentId = 44, NumberAccount = 35, AccName = "ايرادات اخرى" });

        //_context.accounts.Add(new() { NumberAccount = 4, AccName = "/مصاريف" });
        //_context.accounts.Add(new() { ParentId = 49, NumberAccount = 41, AccName = "مصروفات/" });
        //_context.accounts.Add(new() { ParentId = 50, NumberAccount = 411, AccName = "اجور مرتبات" });
        //_context.accounts.Add(new() { ParentId = 50, NumberAccount = 412, AccName = "وقود" });
        //_context.accounts.Add(new() { ParentId = 50, NumberAccount = 413, AccName = "وجبات" });
        //_context.accounts.Add(new() { ParentId = 50, NumberAccount = 414, AccName = "مستلزمات تشغيل" });
        //_context.accounts.Add(new() { ParentId = 50, NumberAccount = 415, AccName = "مواد بناء" });
        //_context.accounts.Add(new() { ParentId = 50, NumberAccount = 416, AccName = "هاتف اتصلات" });
        //_context.accounts.Add(new() { ParentId = 50, NumberAccount = 42, AccName = "خصم مسموح به" });

        //_context.CostCenters.Add(new() { NumberCostCenter = 8000, NameCostCenter = "الادارة" });
        //_context.CostCenters.Add(new() { NumberCostCenter = 1, NameCostCenter = "شركة عميل 1" });
        //_context.CostCenters.Add(new() { NumberCostCenter = 2, NameCostCenter = "شركة عميل 2" });
        //_context.CostCenters.Add(new() { NumberCostCenter = 3, NameCostCenter = "مورد 1" });
        //_context.CostCenters.Add(new() { NumberCostCenter = 2, NameCostCenter = "مورد 2" });


        //await _context.SaveChangesAsync();
        //}
    }
}
