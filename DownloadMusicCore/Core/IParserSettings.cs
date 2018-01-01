namespace DownloadMusicCore
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }

        string Search { get; set; }

        int PageNumber { get; set; }
    }
}
