using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebParcer.Models;

namespace WebParcer.Helpers
{
    public class UrlParser
    {
        public static string[] Parse(UnparcedUrlModel UnparcedUrl)
        {
            string[] separators = { "; \r\n", " ", "; ", "\r\n ", ";", ";\r\n", "\r\n" };
            var sm = UnparcedUrl.Urls.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return sm;
        }
    }
}