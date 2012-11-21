using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace StephanieJay.Models
{
    public class NewsItemModel
    {
        public IList<NewsItem> NewsItems { get; set; }
    }

    public class NewsItem
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        public string PubDate { get; set; }
    }

}
