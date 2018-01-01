using AngleSharp.Dom.Html;
using System;

namespace DownloadMusicCore
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
        event Action OnNotFound;
    }
}
