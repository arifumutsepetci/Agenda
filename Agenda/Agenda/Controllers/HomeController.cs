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
        public IActionResult AddEvent(AddEventModel model)
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
            return View("Index", new HomeIndexModel(_dbContext.GetEventIsntDoneList(), _dbContext.GetEventUrgencyList(), isSuccessful, null));
        }

        [HttpPost]
        public IActionResult DoEvents(string[] eventIdArray)
        {
            bool isMarkingAsDoneSuccessful = false;
            if (eventIdArray.Count() > 0)
            {
                foreach (var item in eventIdArray)
                    _dbContext.GetEventByEventId(Convert.ToInt32(item)).IsDone = true;

                isMarkingAsDoneSuccessful = true;
            }
            _dbContext.SaveChanges();
            return View("Index", new HomeIndexModel(_dbContext.GetEventIsntDoneList(), _dbContext.GetEventUrgencyList(), null, isMarkingAsDoneSuccessful));
        }
    }
}
