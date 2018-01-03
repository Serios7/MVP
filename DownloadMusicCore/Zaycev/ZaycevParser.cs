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

        List<InformationMusic> IParser<List<InformationMusic>>.Parse(IHtmlDocument document)
        {
            var itemsBlock = document.QuerySelectorAll("div.zaycev__block");            
            var itemsTitle = itemsBlock.Select(s => s.GetElementsByClassName("light-link"));
            var itemsRecord = itemsBlock.Select(s => s.GetElementsByClassName("result__snp"));
            var itemsLink = itemsBlock.Select(s => s.GetElementsByClassName("light-link")
                                      .Select(m => m.GetAttribute("href")));





            OnNotFound?.Invoke();            
        }
    }
}

  