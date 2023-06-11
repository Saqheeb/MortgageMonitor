using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MortgageMoniteringSystem.Models;
using MortgageMoniteringSystem.Services;
//using MortgageMoniteringSystem.Services;

namespace MortgageMoniteringSystem.Controllers
{
    public class FeatureController : Controller
    {
        private const string connectionStr = "Endpoint=https://myappcalcreact.azconfig.io;Id=NgAX;Secret=Z0BYRA46JSMZK/sdjWF28RgwrXNblkAD91FzUGhU2xw=";

        private const string calcLabel = "Calculator";


        FeatureManagementService obj = new FeatureManagementService(connectionStr, calcLabel);
        //private readonly IFeatureManagementService _featureManagementService;

        //public FeatureController(FeatureManagementService service)
        //{
        //    _featureManagementService = service;
        //}

        // GET: FeatureController
        public ActionResult Index()
        {
            List<FeatureFlag> flags = new List<FeatureFlag>()
            {
                new FeatureFlag()
                {
                    UniqueId = 1,
                    Label = calcLabel,
                    FeatureId = "showcalc",
                    FeatureName = "Calculator",
                    FeatureDescription = "Calcualtor Feature in Risk Automation System"
                },
                //new FeatureFlag()
                //{
                //    UniqueId= 2,
                //    Label = "RiskMeter",
                //    FeatureId = "showRisk",
                //    FeatureName = "Risk-O-Meter",
                //    FeatureDescription = "This feature is a dynamic meter for all the result"
                //},
            };

            return View(flags);
        }

        // GET: FeatureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeatureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeatureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: FeatureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            //var featureFlagEnabled = _featureManagementService.GetFlagStatus("myFeatureFlagId");
            //_featureManagementService.SetFlagStatus("myFeatureFlagId", !featureFlagEnabled);
            return View();
        }

        // GET: FeatureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeatureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //PATCH: Feature/ToggleAccess
        [HttpPatch]
        public IActionResult ToggleAccess(int uniqueId, string featureFlagId ,bool access)
        {
            Console.WriteLine();
            Console.WriteLine("Feature patch getting triggered!!!" + " " + uniqueId + " " + featureFlagId + " " + access);
            
            if ( uniqueId == 1)
            {
                obj.SetFlagStatus(featureFlagId, access);
                return Ok();
            }
            else
            {
                return UnprocessableEntity("flag is out of service!!!");

            }
        }
    }
}
