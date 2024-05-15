using CarRent.Areas.Admin.FastReportUtils;
using CarRent.Areas.Admin.Services;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCarrosReportController : Controller
    {
       private readonly IWebHostEnvironment _webHostEnv;
        private readonly RelatorioCarrosService _relatorioCarrosService;

        public AdminCarrosReportController(IWebHostEnvironment webHostEnv, RelatorioCarrosService relatorioCarrosService)
        {
            _webHostEnv = webHostEnv;
            _relatorioCarrosService = relatorioCarrosService;
        }

        public async Task<ActionResult> CarrosCategoriasReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "CarrosCategoria.frx"));

            var carros = HelperFastReport.GetTable(await _relatorioCarrosService.GetCarrosReport(), "CarrosReport");

            var categorias = HelperFastReport.GetTable(await _relatorioCarrosService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(carros, "CarroReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");
            return View(webReport);
        }
        [Route("CarrosCategoriasPdf")]
        public async Task<ActionResult> CarrosCategoriasPdf()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports", "CarrosCategoria.frx"));

            var carros = HelperFastReport.GetTable(await _relatorioCarrosService.GetCarrosReport(), "CarrosReport");

            var categorias = HelperFastReport.GetTable(await _relatorioCarrosService.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(carros, "CarroReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();
            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            return File(stream, "application/zip", "CarrosCategoria.pdf"); // faz o download do pdf
            // return new FileStreamResult(stream,"application/pdf"); // abre o pdf no navegador
        }
    }
}
