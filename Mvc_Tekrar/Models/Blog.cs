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

        [Required]
        [StringLength(100,MinimumLength =10,ErrorMessage="Blog Title Girmelisiniz!")]
        public string BlogTitle { get; set; }
        [Required(ErrorMessage ="Category Secmelisniz!")]
        public int CategoryId { get; set; }
        public int NumberOfClicks { get; set; }

    }
}
