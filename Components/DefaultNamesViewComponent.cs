using DannyDefaults.Models;
using Microsoft.AspNetCore.Mvc;

namespace DannyDefaults.Components
{
    public class DefaultNamesViewComponent : ViewComponent
    {
        private I_Repository _defaultRepo;
        // Contstructor
        public DefaultNamesViewComponent(I_Repository temp)
        {
            _defaultRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedDefaultLetter = RouteData?.Values["defaultLetter"];

            var defaultLetters = _defaultRepo.Defaults_table
                .Select(x => x.DefaultLetter)
                .Distinct()
                .OrderBy(x => x);

            return View(defaultLetters);
        }
    }
}
