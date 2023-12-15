using ExampleProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace ExampleProject.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private readonly PagesRepository _pagesRepository;

        public PagesController(PagesRepository pagesRepository)
        {
            _pagesRepository = pagesRepository;
        }
        public async Task<IActionResult> Company()
        {
            var result =await _pagesRepository.GetCompanyListAsync();
            return View(result);
        }
         public async Task<IActionResult> Dispatcher(string partyName, DateTime? startDate, DateTime? endDate)
        {
            var result = await _pagesRepository.GetDispatcherListAsync();
            if (!string.IsNullOrWhiteSpace(partyName))  
            {
                result = result.Where(item => item.PartyName.Contains(partyName)).ToList();
            }

            if (startDate.HasValue)
            {
                result = result.Where(item => item.Date >= startDate).ToList();
            }

            if (endDate.HasValue)
            {
                result = result.Where(item => item.Date <= endDate).ToList();
            }
            ViewBag.PartyNameFilter = partyName;
            ViewBag.StartDateFilter = startDate;
            ViewBag.EndDateFilter = endDate;

            return View(result);
        }
        

    }
}
