using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DownloadMusicCore
{
    class HtmlLoader
    {
        readonly WebClient webClient;
        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            webClient = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            url = $"{settings.BaseUrl}{settings.Search}{settings.PageNumber}";
        }

        public async Task<string> GetSourceBySearch(string search, int pageNumber)
        {
            var currentUrl = url.Replace("{search}", search).Replace("{pageNumber}", pageNumber.ToString());
            return await webClient.DownloadStringTaskAsync(currentUrl);
        }
    }
}