using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Models
{
    public class Home : FeatureToggle
    {
        public bool IsMenuEnabled
        {
            get { return IsEnabled("LinkButton"); }
        }
    }
}