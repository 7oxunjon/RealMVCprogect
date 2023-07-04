using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; } = string.Empty;

        public DateTime HeadingDate { get; set; }

        public bool Headingstatus { get; set; }

        public int CotegoryId { get; set; }
       
        public virtual Category Category { get; set; } = new Category();

        public int WriterId { get; set; }

        public virtual Writer Writer { get; set; } = new Writer();


        public ICollection<Content> Contents { get; set; } = new List<Content>();

       
    }
}
