using AngleSharp.Dom.Html;

namespace DownloadMusicCore
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
