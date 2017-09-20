using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BundesligaWeb.Services
{
    public class NewsService
    {
        List<NewsViewModel> news;
        public IEnumerable<NewsViewModel> GetNews()
        {
            XDocument doc = XDocument.Load("http://www.bundesliga.com/rss/en/liga/rss_news.xml");

            var news = doc.Root.Element("channel").Elements("item").Select(x =>
                 new NewsViewModel
                 {
                     Title = x.Element("title").Value,
                     Link = x.Element("link").Value,
                     ImageSrc = x.Elements().Where(e => e.Name.ToString().Contains("content")).FirstOrDefault().Attribute("url").Value
                 }
             );

            return news;
        }
    }
}
