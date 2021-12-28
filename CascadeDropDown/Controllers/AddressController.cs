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
            var StateList= GetStates(countryid);

            var StateData = StateList.Select(m => new SelectListItem()
            {
                Value=m.Id.ToString(),
                Text=m.Name.ToString()
            });

            return new JsonResult(StateData);
        }

        public JsonResult LoadCityByStateId(int stateid)
        {
            var CityList = GetCities(stateid);

            var CityData = CityList.Select(m => new SelectListItem()
            {
                Value = m.Id.ToString(),
                Text = m.Name.ToString()
            });

            return new JsonResult(CityData);
        }

        private static IList<State> GetStates(int id)
        {
 
            IList<State> S = new List<State>
            {
                new State{Id=1,Cid=1,Name="Maharashtra"},
                new State{Id=2,Cid=1,Name="Delhi" },
                new State{Id=3,Cid=1,Name="Tamil Nadu"},
                new State{Id=4,Cid=2,Name="Punjab"},
                new State{Id=5,Cid=2,Name="Sindh"},
                new State{Id=6,Cid=2,Name="Balochistan"}
            };
            return S.Where(m=>m.Cid==id).ToList();
        }

        private static IList<City> GetCities(int id)
        {

            IList<City> C = new List<City>
            {
                new City{Id=1,Sid=1,Name="Pune"},
                new City{Id=2,Sid=2,Name="Noida" },
                new City{Id=3,Sid=3,Name="Chennai"},
                new City{Id=4,Sid=4,Name="Lahore"},
                new City{Id=5,Sid=5,Name="Karachi"},
                new City{Id=6,Sid=6,Name="Quetta"},
                new City{Id=7,Sid=1,Name="Mumbai"},
                new City{Id=8,Sid=2,Name="Gurugram" },
                new City{Id=9,Sid=3,Name="Coimbatore"},
                new City{Id=10,Sid=4,Name="Multan"},
                new City{Id=11,Sid=5,Name="Sukkur"},
                new City{Id=12,Sid=6,Name="Khuzdar"}
            };
            return C.Where(m => m.Sid == id).ToList();
        }
    } 
}
