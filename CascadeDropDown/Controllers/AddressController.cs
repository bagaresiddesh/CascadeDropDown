using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CascadeDropDown.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CascadeDropDown.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            List <Country> C=new List<Country>
            { 
                new Country{Id=1,Name="India"},
                new Country{Id=2,Name="Pakistan"}
            };
            
            ViewBag.Country = C;

            return View();
        }

        public JsonResult LoadStateByCountryId(int countryid)
        {
            var StateList=GetStates(countryid);

            var StateData = StateList.Select(m => new SelectListItem()
            {
                Value=m.Id.ToString(),
                Text=m.Name.ToString()
            });

            return new JsonResult(StateData);
        }

        private IList<State> GetStates(int countryid)
        {             
            IList<State> S = new List<State>
            {
                new State{Id=1,Cid=1,Name="Mumbai"},
                new State{Id=2,Cid=1,Name="Delhi" },
                new State{Id=3,Cid=1,Name="Chennai"},
                new State{Id=4,Cid=2,Name="Lahor"},
                new State{Id=5,Cid=2,Name="Multan"},
                new State{Id=6,Cid=2,Name="Karachi"}
            };
            return S.Where(m=>m.Cid==countryid).ToList();
        }
    } 
}
