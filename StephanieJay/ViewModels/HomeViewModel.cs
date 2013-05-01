using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StephanieJay.Classes;
using RSS;

namespace StephanieJay.ViewModels
{
    public class HomeViewModel
    {
        public WelcomeMessage WelcomeMessage { get; set; }
        public List<Item> News { get; set; }
    }
}