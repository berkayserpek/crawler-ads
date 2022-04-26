using System;
using System.Collections.Generic;

namespace crawler_ads
{
    class Program
    {
        static void Main(string[] args)
        {
            //ads. information and user information
            List<string> data = new List<string>();
            List<UserContent> list = new List<UserContent>();
            for (int i = 0; i < 10; i++)
            {
                SahibindenCrawler sc = new SahibindenCrawler("https://www.sahibinden.com/emlak?pagingOffset=" + (i * 20));
                sc.GetCrawlURLs();
                data.AddRange(sc.CrawlURLs);
                list.AddRange(sc.GetUserContent());
            }

            foreach (var item in list)
            {
                System.Console.WriteLine(item.ToString());
            }
        }
    }
}
