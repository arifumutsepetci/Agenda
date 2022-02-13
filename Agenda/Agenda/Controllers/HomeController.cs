using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        #region Providers
        private readonly ILogger<HomeController> _logger;
        private readonly AgendaDataAccessLayer.AgendaContext _dbContext;
        public HomeController(AgendaDataAccessLayer.AgendaContext dbContext, ILogger<HomeController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        #endregion

        public IActionResult Index()
        {
            var model = new HomeIndexModel(_dbContext.GetEventIsntDoneList(), _dbContext.GetEventUrgencyList());
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddEvent()
        {
            var model = new HomeIndexModel(_dbContext.GetEventIsntDoneList(), _dbContext.GetEventUrgencyList());
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Index(AddEventModel model)
        {
            bool isSuccessful;
            if (ModelState.IsValid)
            {
                model.Event.CreatedDate = DateTime.Now;
                _dbContext.Add(model.Event);
                _dbContext.SaveChanges();
                isSuccessful = true;
                ModelState.Clear();
            }
            else
                isSuccessful = false;
            return View("Index", new HomeIndexModel(_dbContext.GetEventIsntDoneList(), _dbContext.GetEventUrgencyList(), isSuccessful));
        }

        [HttpPost]
        public IActionResult DoEvents(string[] eventIdArray)
        {
            if (eventIdArray.Count() > 0)
            {
                AgendaDataAccessLayer.Events doneEvent;
                foreach (var item in eventIdArray)
                {
                    doneEvent = _dbContext.GetEventByEventId(Convert.ToInt32(item));
                    if (doneEvent != null)
                    {
                        doneEvent.IsDone = true;
                        doneEvent.CompletionDate = DateTime.Now;
                    }
                }
            }
            _dbContext.SaveChanges();
            return Json(new { result = "Redirect", url = Url.Action("Index", "Home") });
        }
    }
}
