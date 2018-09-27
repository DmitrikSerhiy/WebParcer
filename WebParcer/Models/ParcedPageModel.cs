using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebParcer.Models
{
    public class ParcedPageModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
