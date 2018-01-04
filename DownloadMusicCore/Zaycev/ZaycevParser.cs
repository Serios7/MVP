using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using System.Text.RegularExpressions;

namespace DownloadMusicCore.Zaycev
{
    class ZaycevParser : IParser<List<InformationMusic>>
    {
        public event Action OnNotFound;
        readonly Regex regex = new Regex(@"длительность([^\t]+)размер([^\t]+)битрейт([^\t]+)Скачать");

        List<InformationMusic> IParser<List<InformationMusic>>.Parse(IHtmlDocument document)
        {            
            List<InformationMusic> items = new List<InformationMusic>();
            if (IsNotFound(document))
            {
                OnNotFound?.Invoke();
                return items;
            }

            var itemsBlock = document.QuerySelectorAll("div.zaycev__block");            
            var itemsTitle = itemsBlock.Select(s => s.GetElementsByClassName("light-link"));
            var itemsRecord = itemsBlock.Select(s => s.GetElementsByClassName("result__snp"));
            var itemsLink = itemsBlock.Select(s => s.GetElementsByClassName("light-link")
                                      .Select(m => m.GetAttribute("href")));


            for (int i = 0; i < itemsBlock.Length; i++)
            {
                var record = regex.Split(itemsRecord.ElementAt(i).First().TextContent.Replace("\n", "").Replace(" ", ""));
                var title = itemsTitle.ElementAt(i).First().TextContent.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                items.AddRange(new InformationMusic[] { new InformationMusic()
                {
                    Author = title.ElementAt(0),
                    Name = title.ElementAt(1),
                    Duration = record.ElementAt(1),
                    Size = record.ElementAt(2),
                    Quality = record.ElementAt(3),                 
                    Link = itemsLink.ElementAt(i).First()
                }});
            }

            return items;
        }

        private bool IsNotFound(IHtmlDocument document)
        {
            if(document.QuerySelectorAll("div.not-found").Length == 0) return false;
            return true;
        }
    }
}

  