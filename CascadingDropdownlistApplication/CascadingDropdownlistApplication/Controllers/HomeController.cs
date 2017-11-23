using System.Web.Mvc;
using CascadingDropdownlistApplication.Models;
using System.Collections.Generic;

namespace CascadingDropdownlistApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public List<SelectListGroup> BindCountries()
        {
            List<SelectListGroup> liCountry = new List<SelectListGroup>();
            liCountry.Add(new SelectListGroup() { Name = "1" });
            liCountry.Add(new SelectListGroup() { Name = "2" });
            return liCountry;
        }
        public List<SelectListItem> States()
        {
            List<SelectListItem> liStataes = new List<SelectListItem>();
            List<SelectListGroup> liCountry = BindCountries();
            liStataes.Add(new SelectListItem() { Text = "Select State", Value = "0",Selected=true });
            liStataes.Add(new SelectListItem() { Text = "Telangana", Value = "1",Group=liCountry.Find(x=>x.Name=="1")});
            liStataes.Add(new SelectListItem() { Text = "AndhraPradesh", Value = "1" ,Group = liCountry.Find(x => x.Name == "1") });
            liStataes.Add(new SelectListItem() { Text = "Taxas", Value = "2", Group = liCountry.Find(x => x.Name == "2") });
            liStataes.Add(new SelectListItem() { Text = "New Jersey", Value = "2", Group = liCountry.Find(x => x.Name == "2") });
            return liStataes;
        }
        [HttpPost]
        public JsonResult BindStates(string countryId)
        {
           
            List<SelectListItem> liStates = States();
          //  List<SelectListGroup> liCountry = BindCountries();
            liStates = liStates.FindAll(x=>x.Value== countryId);
            ViewBag.states = liStates;
            return  Json(liStates,JsonRequestBehavior.AllowGet);
        }
    }
}