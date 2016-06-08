using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class FeatureToggleController : Controller
    {
        // GET: FeatureToggle
        public ActionResult Index(string key, string value)
        {
            ConfigurationManager.Instance.Toggle(key, value);
            return RedirectToAction("Index", "Home");
        }
    }
}