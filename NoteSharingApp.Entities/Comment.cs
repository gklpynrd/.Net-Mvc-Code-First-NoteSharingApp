using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteSharingApp.Entities
{
    [Table("Comments")]
    public class Comment : MyEntityBase
    {
        [Required,StringLength(300)]
        public string text { get; set; }

        public virtual Note Note { get; set; }
        public virtual EvernoteUser Owner { get; set; }
    }
}
