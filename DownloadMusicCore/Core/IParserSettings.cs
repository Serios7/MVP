namespace DownloadMusicCore
{
    interface IParserSettings
    {
        string BaseUrl { get; }

        string Search { get; set; }

        int PageNumber { get; set; }
    }
}
