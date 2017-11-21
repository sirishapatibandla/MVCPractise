using System.Web.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MVCPractiseEntities objEntities = new MVCPractiseEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserData objUser)
        {
      UserData user=   objEntities.UserDatas.Find(objUser.username);
            if (user.username == objUser.username && user.password == objUser.password)
            {
                return View("result", user);
            }
            ViewBag.message = "UserName or Password are incorrect";
            return View("Index");
        }
    }
}