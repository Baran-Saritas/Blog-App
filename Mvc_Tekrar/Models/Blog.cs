using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Tekrar.Models
{
    public class Blog
    {

        [Key]
        public int id { get; set; }
        public string BlogTitle { get; set; }
        public int CategoryId { get; set; }
        public int NumberOfClicks { get; set; }

    }
}
