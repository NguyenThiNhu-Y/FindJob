using ClosedXML.Excel;
using FindJob.Employers;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace FindJob.Web.Pages.Employers.Employer
{
    public class IndexModel : FindJobPageModel
    {
        private readonly IEmployerRepository _employerRepository;
        public IndexModel(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
        public async Task<IActionResult> OnPostExportAsync()
        {

            var employers = await _employerRepository.GetListAsync();
            var memoryStream = new MemoryStream();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 100;
                worksheet.Column(3).Width = 100;
                var stt = worksheet.Cell(1, 1);
                var companyname = worksheet.Cell(1, 2);
                var address = worksheet.Cell(1, 3);


                companyname.Value = L["EmployerCompanyName"];
                companyname.Style.Font.Bold = true;
                address.Value = L["EmployerAddress"];
                address.Style.Font.Bold = true;
              
                stt.Value = L["Index"];
                stt.Style.Font.Bold = true;
                

                for (var i = 0; i < employers.Count; i++)
                {
                    var employer = employers[i];
                    
                    worksheet.Cell(i + 2, 1).Value = i + 1;
                    worksheet.Cell(i + 2, 2).Value = employer.CompanyName;
                    worksheet.Cell(i + 2, 3).Value = employer.Address;
                    

                }
                workbook.SaveAs(memoryStream);
            }
            memoryStream.Position = 0;
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
