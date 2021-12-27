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
        [Required(ErrorMessage="Blog Title Girmelisiniz!")]   // diger yapida burdaki stringi yansitamiyoruz ondan boyle kullanildi
        public string BlogTitle { get; set; }
        [Required(ErrorMessage ="Category Secmelisniz!")]
        public int? CategoryId { get; set; }   // secim isin icine girdiginde ? kullanilmadan required aktif edemezsin 
        public int NumberOfClicks { get; set; }

    }
}
