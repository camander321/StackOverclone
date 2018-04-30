using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StackClone.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace StackClone.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly StackDbContext _db;
        private readonly UserManager<AppUser> _userManager;

        public QuestionController (UserManager<AppUser> userManager, StackDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Questions.Where(x => x.User.Id == currentUser.Id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            question.User = currentUser;
            _db.Questions.Add(question);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
