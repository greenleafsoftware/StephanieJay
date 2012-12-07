using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;

namespace StephanieJay.Classes
{
    public class NewsData
    {
        private IList<News> _news;

        public IList<News> Get()
        {
            return _news;
        }

        public News Get(int ID)
        {
            return _news[ID];
        }

        public NewsData() 
        {
            _news = new List<News>();
            XDocument rss = XDocument.Load(HttpRuntime.AppDomainAppPath + "/XML/News.xml");
            foreach (XElement item in rss.Descendants("item"))
            {
                var news = new News
                {
                    Title = item.Element("title").Value,
                    Description = item.Element("description").Value,
                    PubDate = item.Element("pubDate").Value,
                    Link = item.Element("link").Value
                };
                _news.Add(news);
            }
        }

        public void Add(News news)
        {
            _news.Add(news);
        }

        public void Remove(News news)
        {
            _news.Remove(news);
        }

        public void Save()
        {
            //TODO: Add to the XML
            var rss = new XDocument(
                new XElement("news",
                from n in _news
                select new XElement("item",
                    new XAttribute("title", n.Title),
                    new XElement("description", n.Description),
                    new XElement("pubDate", n.PubDate),
                    new XElement("link", n.Link)
            )));

            rss.Save(HttpRuntime.AppDomainAppPath + "/XML/News.xml");
        }
    }
}
