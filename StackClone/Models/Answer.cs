using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StackClone.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public int Votes { get; set; }
        [ForeignKey("Questions")]
        public int QuestionId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
