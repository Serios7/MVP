namespace DownloadMusicCore.Zaycev
{
    class ZaycevSettings : IParserSettings
    {
        public ZaycevSettings(string search)
        {
            Search = search;
        }

        public string BaseUrl { get; } = "http://go.mail.ru/zaycev?q={search}&page={pageNumber}";
        public string Search { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}
