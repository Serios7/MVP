using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DownloadMusicCore
{
    class HtmlLoader
    {
        readonly WebClient WebClient;
        readonly string Url;

        public HtmlLoader(IParserSettings settings)
        {
            WebClient = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            Url = $"{settings.BaseUrl}{settings.Search}{settings.PageNumber}";
        }

        public async Task<string> GetSourceBySearch(string search, int pageNumber)
        {
            var currentUrl = Url.Replace("{search}", search).Replace("{pageNumber}", pageNumber.ToString());
            return await WebClient.DownloadStringTaskAsync(currentUrl);
        }
    }
}