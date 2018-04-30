using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace StackClone.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Votes { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
