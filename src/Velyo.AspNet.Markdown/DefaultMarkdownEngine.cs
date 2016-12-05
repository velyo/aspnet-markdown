using System;
using System.Collections.Generic;

namespace Velyo.AspNet.Markdown
{
    public class DefaultMarkdownEngine : MarkdownEngine
    {
        public static HeyRed.MarkdownSharp.MarkdownOptions DefaultOptions = new HeyRed.MarkdownSharp.MarkdownOptions
        {
            AllowEmptyLinkText = false,
            AutoHyperlink = true,
            AutoNewLines = true,
            LinkEmails = true,
            QuoteSingleLine = true,
            StrictBoldItalic = true
        };

        private HeyRed.MarkdownSharp.MarkdownOptions _options;
        private IDictionary<string, string> _cache = new Dictionary<string, string>();
        private readonly object _syncRoot = new object();

        public DefaultMarkdownEngine(HeyRed.MarkdownSharp.MarkdownOptions options)
        {
            _options = options;
        }

        public DefaultMarkdownEngine() : this(DefaultOptions) { }


        public override string GetHtml(string markdown)
        {
            var engine = new HeyRed.MarkdownSharp.Markdown(_options);
            return engine.Transform(markdown);
        }

        public override string GetHtml(string key, Func<string> fetch)
        {
            string content = null;

            if (!_cache.TryGetValue(key, out content))
            {
                lock (_syncRoot)
                {
                    if (!_cache.TryGetValue(key, out content))
                    {
                        content = fetch();
                        if (content != null)
                        {
                            content = GetHtml(content);
                            _cache[key] = content;
                        }
                    }
                }
            }

            return content;
        }
    }

}
