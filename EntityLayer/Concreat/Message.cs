using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        
        [StringLength(50)]        
        public string YuboruvchiMail { get; set; }

        [StringLength(50)]
        public string Qabul_qiluvchiMail { get; set; }

        [StringLength(150)]
        public string Subject { get; set; } = string.Empty;

        
        public string MessageContent { get; set; } = string.Empty;
        
        public DateTime MessageDate { get; set; }
    }
}
