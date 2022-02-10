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
            var model = new HomeIndexModel { EventList = _dbContext.GetEventList(), UrgencyList = _dbContext.GetEventUrgencyList() };

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

        [HttpPost]
        public IActionResult AddEvent(AddEventModel model)
        {
            if (ModelState.IsValid)
            {
                model.Event.CreatedDate = DateTime.Now;
                _dbContext.Add(model.Event);
                _dbContext.SaveChanges();
                ModelState.Clear();
            }
            else
            {

            }
            return View("Index", new HomeIndexModel { EventList = _dbContext.GetEventList(), UrgencyList = _dbContext.GetEventUrgencyList() });
        }
    }
}
