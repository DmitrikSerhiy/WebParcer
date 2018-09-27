using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebParcer.Helpers
{
    public class PageLoager
    {
        public static async Task<string> LoadTitleAsync(string url)
        {
            WebClient x = new WebClient();

            var client = new WebClient();
            return Regex.Match(await client.DownloadStringTaskAsync(url), @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value; // Yeap, I just googled this huge regex!
        }
    }
}
