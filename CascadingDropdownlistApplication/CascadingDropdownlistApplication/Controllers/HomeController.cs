using System.Web.Mvc;
using CascadingDropdownlistApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace CascadingDropdownlistApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MVCPractiseEntities1 objEntity = new MVCPractiseEntities1();

        public ActionResult Index()
        {
           // MVCPractiseEntities1 objEntity = new MVCPractiseEntities1();
            ViewModel model = new ViewModel();
            Country obj = new Country();
            List<Country> liCountry = new List<Country>();
            liCountry = objEntity.Countries.Distinct().ToList();
            model.CountryProperty = liCountry;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            //List<State> listate = new List<State>();
            //listate = objEntity.States.Where(x => x.countryId == id).ToList();
            //ViewModel model = new ViewModel();
            //model.StateProperty= liCountry;
            

            return View();
        }
        //public List<SelectListGroup> BindCountries()
        //{
        //    List<SelectListGroup> liCountry = new List<SelectListGroup>();
        //    liCountry.Add(new SelectListGroup() { Name = "1" });
        //    liCountry.Add(new SelectListGroup() { Name = "2" });
        //    return liCountry;
        //}
        //public List<SelectListItem> States()
        //{
        //    List<SelectListItem> liStataes = new List<SelectListItem>();
        //    List<SelectListGroup> liCountry = BindCountries();
        //    liStataes.Add(new SelectListItem() { Text = "Select State", Value = "0",Selected=true });
        //    liStataes.Add(new SelectListItem() { Text = "Telangana", Value = "1",Group=liCountry.Find(x=>x.Name=="1")});
        //    liStataes.Add(new SelectListItem() { Text = "AndhraPradesh", Value = "1" ,Group = liCountry.Find(x => x.Name == "1") });
        //    liStataes.Add(new SelectListItem() { Text = "Taxas", Value = "2", Group = liCountry.Find(x => x.Name == "2") });
        //    liStataes.Add(new SelectListItem() { Text = "New Jersey", Value = "2", Group = liCountry.Find(x => x.Name == "2") });
        //    return liStataes;
        //}
        [HttpPost]
        public JsonResult BindStates(int countryId)
        {
            List<State> listate = new List<State>();
            listate = objEntity.States.Where(x => x.countryId == countryId).ToList();
            //ViewModel model = new ViewModel();
            //model.StateProperty = listate;
            var li = listate.Select(e => new { e.Statename, e.value }).ToList();
            return  Json(li, JsonRequestBehavior.AllowGet);
        }
    }
}