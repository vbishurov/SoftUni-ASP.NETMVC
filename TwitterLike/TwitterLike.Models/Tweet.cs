namespace TwitterLike.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        public int Id { get; set; }

        private ICollection<ApplicationUser> favouritedBy;
        private ICollection<ApplicationUser> retweetedBy;
        private ICollection<ApplicationUser> reportedBy;

        public Tweet()
        {
            this.favouritedBy = new HashSet<ApplicationUser>();
            this.retweetedBy = new HashSet<ApplicationUser>();
            this.reportedBy = new HashSet<ApplicationUser>();
        }

        public DateTime DateTime { get; set; }

        public string Content { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool IsReported { get; set; }

        public string Url { get; set; }

        public virtual ICollection<ApplicationUser> FavouritedBy
        {
            get
            {
                return this.favouritedBy;
            }

            set
            {
                this.favouritedBy = value;
            }
        }

        public virtual ICollection<ApplicationUser> RetweetedBy
        {
            get
            {
                return this.retweetedBy;
            }

            set
            {
                this.retweetedBy = value;
            }
        }

        public virtual ICollection<ApplicationUser> ReportedBy
        {
            get
            {
                return this.reportedBy;
            }

            set
            {
                this.reportedBy = value;
            }
        }
    }
}
