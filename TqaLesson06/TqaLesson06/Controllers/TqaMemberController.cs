using Microsoft.AspNetCore.Mvc;
using TqaLesson06.Models;

namespace TqaLesson06.Controllers
{
    public class TqaMemberController : Controller
    {
        private static readonly List<TqaMember> _tqaMember = new List<TqaMember>()
        {
            new TqaMember
    {
        TqaMemberId = Guid.NewGuid().ToString(),
        TqaMemberUserName = "quanganh206",
        TqaMemberPassword = "quanganh",
        TqaMemberEmail = "thinquanganh0910206@gmail.com",
        TqaMemberFullName = "Thịnh Quang Anh"
    },

    new TqaMember
    {
        TqaMemberId = Guid.NewGuid().ToString(),
        TqaMemberUserName = "tranthib",
        TqaMemberPassword = "123456",
        TqaMemberEmail = "tranthib@gmail.com",
        TqaMemberFullName = "Trần Thị B"
    },

    new TqaMember
    {
        TqaMemberId = Guid.NewGuid().ToString(),
        TqaMemberUserName = "levanc",
        TqaMemberPassword = "123456",
        TqaMemberEmail = "levanc@gmail.com",
        TqaMemberFullName = "Lê Văn C"
    }
        };
        public IActionResult TqaIndex()
        {
            return View(_tqaMember);
        }
        public IActionResult TqaCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TqaCreate(TqaMember tqaMember)
        {
            tqaMember.TqaMemberId = Guid.NewGuid().ToString();
            _tqaMember.Add(tqaMember);
            return RedirectToAction("TqaIndex");
        }
        public IActionResult TqaEdit(string id)
        {
            var tqaMember = _tqaMember.FirstOrDefault(x => x.TqaMemberId.Equals(id));
            return View(tqaMember);
        }
        [HttpPost]
        public IActionResult TqaEdit( string id ,TqaMember tqaMember)
        {
            for(int i = 0; i < _tqaMember.Count; i++)
            {
                if (_tqaMember[i].TqaMemberId == id)
                {
                    _tqaMember[i].TqaMemberId = tqaMember.TqaMemberId;
                    _tqaMember[i].TqaMemberUserName = tqaMember.TqaMemberUserName;
                    _tqaMember[i].TqaMemberPassword = tqaMember.TqaMemberPassword;
                    _tqaMember[i].TqaMemberFullName = tqaMember.TqaMemberFullName;
                    _tqaMember[i].TqaMemberEmail = tqaMember.TqaMemberEmail;
                    break;
                }
                
            }
            return RedirectToAction("TqaIndex");
        }

        public IActionResult TqaGetDetails()
        {
            var tqaMember = new TqaMember()
            {
                TqaMemberId = Guid.NewGuid().ToString(),
                TqaMemberUserName = "Quang Anh",
                TqaMemberPassword = "quanganh",
                TqaMemberFullName = "Thịnh Quang Anh",
                TqaMemberEmail = "thinhquanganh0910206@gmail.com"
            };
            return View(tqaMember);
        }
    }
}
