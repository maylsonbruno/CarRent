﻿using CarRent.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatoriosVendasService relatoriosVendasService;

        public AdminRelatorioVendasController(RelatoriosVendasService _relatoriosVendasService)
        {
            relatoriosVendasService = _relatoriosVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate, DateTime? maxDate)
        {
            if(!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year,1,1);
            }

            if(!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await relatoriosVendasService.FindByDateAsync(minDate,maxDate);
            return View(result);
        }
    }
}
