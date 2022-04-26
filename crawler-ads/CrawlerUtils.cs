using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace crawler_ads
{
    public class CrawlerUtils
    {
        protected Uri uri { get; set; }
        protected HtmlDocument document { get; set; }

        public CrawlerUtils(string link)
        {
            this.uri = new Uri(link);
            this.InitUrl();
        }
        //read links.
        public string GetHtmlRaw()
        {
            WebClient wc = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            string RawHtml = wc.DownloadString(this.uri);
            return RawHtml;
        }
        //load links.
        public void InitUrl()
        {
            document = new HtmlDocument();
            document.LoadHtml(this.GetHtmlRaw());
        }
        //select xpath way
        public HtmlNodeCollection CrawlNodes(string xpath)
        {
            return this.document.DocumentNode.SelectNodes(xpath);
        }
    }
}
