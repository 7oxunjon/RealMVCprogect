using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; } = string.Empty;

        [StringLength(50)]
        public string WriterSurname { get; set; } = string.Empty;

        [StringLength(250)]
        public string WriterImaged { get; set; } = string.Empty;

        [StringLength (100)]
        public string WriterAbout { get; set; } = String.Empty;

        [StringLength(200)]
        public string WriterEmail { get; set; } = String.Empty;

        [StringLength(50)]
        public string WriterTitle { get; set; } = String.Empty;

        public bool WriterStatus { get; set; }

        [StringLength(200)]
        public string WriterPaswword { get; set; } = String.Empty;

        public ICollection<Heading> Heading { get; set; } = new List<Heading>();

        public ICollection<Content> Contents { get; set; } = new List<Content>();
    }
}
