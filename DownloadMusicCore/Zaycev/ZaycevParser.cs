using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace DownloadMusicCore.Zaycev
{
    class ZaycevParser : IParser<List<InformationMusic>>
    {
        public event Action OnNotFound;

        List<InformationMusic> IParser<List<InformationMusic>>.Parse(IHtmlDocument document)
        {
            OnNotFound?.Invoke();
            
        }
    }
}

 