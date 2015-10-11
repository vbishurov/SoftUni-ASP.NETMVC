namespace TwitterLike.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [ForeignKey("FromUser")]
        public string FromUserId { get; set; }

        public virtual ApplicationUser FromUser { get; set; }

        [Required]
        [ForeignKey("ToUser")]
        public string ToUserId { get; set; }

        public virtual ApplicationUser ToUser { get; set; }
    }
}
