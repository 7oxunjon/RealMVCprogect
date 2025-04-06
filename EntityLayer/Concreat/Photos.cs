using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class Photos
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public string ImagePath { get; set; }
        public virtual News? News { get; set; }
    }
}
