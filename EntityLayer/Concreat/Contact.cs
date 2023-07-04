using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [StringLength(50)]
        public string UserMail { get; set; } = string.Empty;

        [StringLength(50)]
        public string Subject { get; set; } = string.Empty;

        public DateTime Contect_date { get; set; }


        public string Message { get; set; } = string.Empty;
    }
}
