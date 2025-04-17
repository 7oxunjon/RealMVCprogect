using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public string? photoNews { get; set; } 
        public int status { get; set; }
        public Users Users { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public virtual ICollection<Photos> Images { get; set; } = new List<Photos>();
    }
}
