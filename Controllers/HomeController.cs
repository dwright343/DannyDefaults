using DannyDefaults.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DannyDefaults.Models;
using DannyDefaults.Models.ViewModels;

namespace DannyDefaults.Controllers
{
    public class HomeController : Controller
    {
        private I_Repository _repo;
        public HomeController(I_Repository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum=1, string? defaultLetter) // name this pageNum, because "page" means something to the .NET environment
        {
            int pageSize = 5;
            var PageInfo = new DefaultListViewModel
            {
                Defaults_table = _repo.Defaults_table // Default_Model is a table
                .Where(x => x.DefaultLetter == defaultLetter || defaultLetter == null)
                .OrderBy(x => x.DefaultId)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = defaultLetter == null ? _repo.Defaults_table.Count() : _repo.Defaults_table.Where(x => x.DefaultName == defaultLetter).Count()
                },

                CurrentDefaultLetter = defaultLetter
            };

            return View(PageInfo);
        }
    }
}
