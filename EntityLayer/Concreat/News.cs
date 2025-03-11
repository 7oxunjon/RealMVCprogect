using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class News
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }

    }
}
