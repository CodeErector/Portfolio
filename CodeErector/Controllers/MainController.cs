using CodeErector.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeErector.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly projectDbContext _context;

        public MainController(projectDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
