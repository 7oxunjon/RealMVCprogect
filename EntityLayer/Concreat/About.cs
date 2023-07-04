using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public  class About
    {
        [Key]
        public int AboutId { get; set; }
        
        [StringLength(1000)]
        public string AboutDetals1 { get; set; } = string.Empty;


        [StringLength(1000)]
        public string AboutDetals2 { get; set; } = string.Empty;


        [StringLength(100)]
        public string AboutImeg1 { get; set; } = string.Empty;

        [StringLength (100)]
        public string AboutImeg2 { get; set; } = string.Empty;
    }
}
