using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EntityLayer.Concreat
{
    
    public class Category
    {
        [Key]
        public int CotegoryId { get; set; }

        [StringLength(50)]
        public string CotegoryName { get; set; } = string.Empty;

        [StringLength(200)]
        public string CotegoryDescription { get; set; } = string.Empty;

        public bool CotegoryStatus { get; set; }

        public ICollection<Heading> Headings { get; set; } = new List<Heading>();


    }
}
