using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Lap07.Models;

namespace Lap07.Controllers
{
    public class AccountController : Controller
    {
        
        private static List<Account> _accounts = new List<Account>()
        {
            new Account()
            {
                Id = 1,
                FullName = "Nguyễn Văn A",
                Email = "vana@gmail.com",
                Phone = "0986421127",
                Address = "Hà Nội",
                Avatar = "avatar.png",
                Birthday = new DateTime(2000, 1, 1),
                Gender = "Nam",
                Password = "Password123",
                Facebook = "https://facebook.com/vana"
            }
        };

        
        public ActionResult Index()
        {
            return View(_accounts);
        }

        
        public ActionResult Details(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        
        public ActionResult Create()
        {
            Account model = new Account();
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                
                _accounts.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return Json(true);
            }

            
            Regex _isPhone = new Regex(@"^(0|\+84)[-. ]?([0-9]{2,3})[-. ]?([0-9]{3})[-. ]?([0-9]{3,4})$");
            string cleanDigits = Regex.Replace(phone, @"\D", "");

            if (!_isPhone.IsMatch(phone) || (cleanDigits.Length != 10 && cleanDigits.Length != 11))
            {
                return Json($"Số điện thoại {phone} Không đúng định dạng, VD: 0986421127 hoặc 098.421.1127");
            }

            return Json(true);
        }
    }
}