using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using StephanieJay.Classes;
using StephanieJay.Models;

namespace StephanieJay.Classes
{
    public static class DataFactory
    {
        public static NewsItemModel GetNews()
        {
            var news = new NewsItemModel();
            var newsItems = new List<NewsItem>(); 

            XDocument rss = XDocument.Load(HttpRuntime.AppDomainAppPath + "/XML/News.xml");
            foreach (XElement item in rss.Descendants("item"))
            {
                var newsItem = new NewsItem 
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    PubDate = item.Element("pubDate").Value,
                    Link = item.Element("link").Value
                };

                newsItems.Add(newsItem);
            }

            news.NewsItems = newsItems;
            return news;
        }
    }
}