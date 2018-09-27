using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebParcer.Models;

namespace WebParcer.Helpers
{
    public class ParcedModelBuilder
    {
        public static List<ParcedPageModel> FormModels(List<(string, string)> urlsAndTitles)
        {
            var models = new List<ParcedPageModel>();
            foreach (var tuple in urlsAndTitles)
            {
                models.Add(new ParcedPageModel { Url = tuple.Item1, Title = tuple.Item2 });
            }
            return models;
        }
    }
}
