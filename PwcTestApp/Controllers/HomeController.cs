using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using PwcTestApp.BL;
using PwcTestApp.DAL;
using PwcTestApp.DL;
using PwcTestApp.DL.Entities;
using PwcTestApp.Models;

namespace PwcTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly int _pageSize = 10;
        private readonly IHistoryRepository _historyRepository;

        public HomeController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(SearchDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await ProcessData.Run(model.SearchString);
            await _historyRepository.SaveHistoryAsync(result);
        
            return View("Result", result);
        }

        public ActionResult History(int? page)
        {
            var data =_historyRepository.GetHistory();

            return View(data.ToPagedList(page ?? 1, _pageSize));
        }
    }
}