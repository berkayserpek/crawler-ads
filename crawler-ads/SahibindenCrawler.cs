using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_ads
{
    public class SahibindenCrawler : CrawlerUtils
    {
        public List<string> CrawlURLs { get; set; }
        public SahibindenCrawler(string link) : base(link)
        {

        }
        //get ads. links
        public void GetCrawlURLs()
        {
            CrawlURLs = new List<string>();

            var rawDataList = CrawlNodes("//*[contains(@class,'classifiedTitle')]");

            foreach (var item in rawDataList)
            {
                CrawlURLs.Add(item.Attributes["href"].Value);
            }
        }
        //get user inf.
        public List<UserContent> GetUserContent()
        {
            List<UserContent> list = new List<UserContent>();

            foreach (var item in CrawlURLs)
            {
                try
                {   //not phone and name for users
                    CrawlerUtils crawler = new CrawlerUtils("https://www.sahibinden.com/" + item);
                    List<string> Plist = new List<string>();
                    var data = crawler.CrawlNodes("//*[contains(@class,'username-info-area')]/h5");
                    string UserNameInfoArea = data.FirstOrDefault().InnerHtml;
                    foreach (var pitem in crawler.CrawlNodes("//*[contains(@class,'pretty-phone-part')]"))
                    {
                        Plist.Add(pitem.InnerHtml);
                    }
                    list.Add(new UserContent()
                    {
                        UserNameInfoArea = UserNameInfoArea,
                        UserContactInfo = Plist
                    });
                }
                catch (Exception)
                {

                }

            }

            return list;
        }
    }

    public class UserContent
    {
        public string UserNameInfoArea { get; set; }
        public List<string> UserContactInfo { get; set; }

        public string ToString()
        {
            return "Name: " + this.UserNameInfoArea + ", { " + String.Join(", ", this.UserContactInfo) + " }";
        }
    }
}

