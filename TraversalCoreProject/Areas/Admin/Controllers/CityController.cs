﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues =JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
           
            return NoContent();
        }


        public IActionResult UpdateCity(Destination destination)
        {
            var values = _destinationService.TGetByID(destination.DestinationID);
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }















        //public IActionResult CityList()
        //{
        //    var jsonCity = JsonConvert.SerializeObject(cities);
        //    return Json(jsonCity);
        //}

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID=1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID=2,
        //        CityName="Ankara",
        //        CityCountry="Türkiye"
        //    },
        //    new CityClass
        //    {
        //        CityID=3,
        //        CityName="Paris",
        //        CityCountry="Fransa"
        //    }

        //}; ----STATIK IŞLEM----


    }
}
