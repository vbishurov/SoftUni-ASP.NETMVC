namespace TwitterLike.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Message> sentMessages;
        private ICollection<Message> receivedMessages;
        private ICollection<Notification> notifications;
        private ICollection<ApplicationUser> followers;
        private ICollection<ApplicationUser> following;
        private IEnumerable<Tweet> tweets;
        private ICollection<Tweet> retweets;
        private ICollection<Tweet> reportedTweets;
        private ICollection<Tweet> favouriteTweets;

        public ApplicationUser()
        {
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
            this.notifications = new HashSet<Notification>();
            this.followers = new HashSet<ApplicationUser>();
            this.following = new HashSet<ApplicationUser>();
            this.tweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Tweet>();
            this.reportedTweets = new HashSet<Tweet>();
            this.favouriteTweets = new HashSet<Tweet>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Message> SentMessages
        {
            get
            {
                return this.sentMessages;
            }

            set
            {
                this.sentMessages = value;
            }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get
            {
                return this.receivedMessages;
            }

            set
            {
                this.receivedMessages = value;
            }
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }

            set
            {
                this.notifications = value;
            }
        }

        public virtual ICollection<ApplicationUser> Followers
        {
            get
            {
                return this.followers;
            }

            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<ApplicationUser> Following
        {
            get
            {
                return this.following;
            }

            set
            {
                this.following = value;
            }
        }

        public virtual IEnumerable<Tweet> Tweets
        {
            get
            {
                return this.tweets.Union(this.Retweets);
            }

            set
            {
                this.tweets = value;
            }
        }

        public virtual ICollection<Tweet> Retweets
        {
            get
            {
                return this.retweets;
            }

            set
            {
                this.retweets = value;
            }
        }

        public virtual ICollection<Tweet> ReportedTweets
        {
            get
            {
                return this.reportedTweets;
            }

            set
            {
                this.reportedTweets = value;
            }
        }

        public virtual ICollection<Tweet> FavouriteTweets
        {
            get
            {
                return this.favouriteTweets;
            }

            set
            {
                this.favouriteTweets = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}