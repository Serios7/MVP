using AngleSharp.Parser.Html;
using System;
using AngleSharp.Dom.Html;

namespace DownloadMusicCore
{
    class ParserWorker<T> where T : class
    {
        private HtmlLoader HtmlLoader;
        private bool IsActive;
        private IParser<T> Parser { get; set; }
        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

        private IParserSettings ParserSettings
        { get { return ParserSettings; }
            set
            {
                ParserSettings = value;
                HtmlLoader = new HtmlLoader(value);
            }
        }
        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
            Parser.OnNotFound += Abort;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            ParserSettings = parserSettings;
        }

        public void Start()
        {
            IsActive = true;
            Worker();
        }

        public void Abort()
        {
            IsActive = false;
        }

        private async void Worker()
        {
            for(int i = ParserSettings.PageNumber; IsActive; i++)
            {
                HtmlParser domParser = new HtmlParser();
                string source = await HtmlLoader.GetSourceBySearch(ParserSettings.Search, ParserSettings.PageNumber);
                IHtmlDocument document = await domParser.ParseAsync(source);
                T result = Parser.Parse(document);
                OnNewData?.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
        }
    }
}
