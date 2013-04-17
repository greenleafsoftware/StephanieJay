using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StephanieJay.Classes.Extensions
{
    public static class ModelExtensions
    {
        public static void DumpErrors(this System.Web.Mvc.ModelStateDictionary ModelState)
        {
            var errors = from key in ModelState
                         let errorList = ModelState[key.Key].Errors
                         where errorList.Any()
                         select new
                         {
                             Item = key.Key,
                             Value = key.Value,
                             errorList
                         };

            foreach (var errorList in errors)
            {
                System.Diagnostics.Debug.WriteLine("MODEL ERROR:");
                System.Diagnostics.Debug.WriteLine(errorList.Item);
                System.Diagnostics.Debug.WriteLine(errorList.Value);
                foreach (var error in errorList.errorList)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                    System.Diagnostics.Debug.WriteLine(error.Exception);
                }
                System.Diagnostics.Debug.WriteLine("-----");
            }
        }
    }
}