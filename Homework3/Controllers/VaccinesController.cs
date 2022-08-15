using homework2.Models;
using homework2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework2.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly IVaccineService _vaccineService;

        public VaccinesController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //shows the Index view
            return View();
        }

        [HttpPost]
        public IActionResult Index(string link)
        {
            //redirects to link you click
            return RedirectToAction("VaccineManagement");
        }

        [HttpGet]
        public IActionResult VaccineManagement()
        {
            ViewData["Name"] = "Vaccine Management";
            //passes on the data from the database to the view
            return View(_vaccineService.GetVaccines());
        }
        [HttpGet]
        public IActionResult AddNewDosesView()
        {
            ViewData["Name"] = "Add New Doses";
            //passes on the data from the database to the view
            return View(_vaccineService.GetVaccines());
        }


        [HttpPost]
        public IActionResult AddNewDosesView(int vaccineSelect, int newDosesReceived)
        {
            //vaccine service in my Vaccine service interface
            _vaccineService.AddDoses(vaccineSelect, newDosesReceived);
            return RedirectToAction("VaccineManagement");
        }


        //action: display form doGet
        [HttpGet]
        public IActionResult AddVaccineView()
        {
            return View(_vaccineService.GetVaccines());
        }



        //action: form submission: doPost
        [HttpPost]
        public IActionResult AddVaccineView(Vaccine vaccine)
        {
            _vaccineService.AddVaccine(vaccine);
            return RedirectToAction("VaccineManagement");
        }


        [HttpGet]
        public IActionResult EditVaccine(int id)
        {

            ViewBag.id = id;

            ViewData["Name"] = "Edit Vaccine";
            //passes on the data from the database to the view

            
            return View(_vaccineService.GetVaccines());
        }


        [HttpPost]
        public IActionResult EditVaccine(int Id, int DosesRequired, int DaysBetweenDoses)
        {
            //vaccine service in my Vaccine service interface
            _vaccineService.EditVaccine(Id, DosesRequired, DaysBetweenDoses);
            return RedirectToAction("VaccineManagement");
        }



    }
        


}
