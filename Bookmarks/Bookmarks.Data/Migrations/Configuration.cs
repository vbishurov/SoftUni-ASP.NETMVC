namespace Bookmarks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<BookmarksDbContext>
    {
        // Hashed string for "password"
        private const string Password = "AEedFkCGQY1riE69EZnncx4WGQzILE3enra9G+VquzLZ6SOIAjxV/7wxVdyN/iI9SA==";

        // Dummy security stamp
        private const string SecurityStamp = "5ea5f609-c75a-48e9-bebb-cce5647ba188";

        private readonly Random random = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookmarksDbContext context)
        {
            if (!context.Users.Any())
            {
                this.GenerateUsers(context);
            }

            if (!context.Categories.Any())
            {
                this.GenerateCategories(context);
            }

            if (!context.Bookmarks.Any())
            {
                this.GenerateBookmarks(context);
            }

            if (!context.Comments.Any())
            {
                this.GenerateComments(context);
            }

            if (!context.Votes.Any())
            {
                this.GenerateVotes(context);
            }
        }

        private void GenerateUsers(BookmarksDbContext context)
        {
            User user;
            string email;
            string username;

            for (int i = 1; i < 11; i++)
            {
                username = "user" + i;
                email = username + "@localhost.me";

                user = new User { UserName = username, Email = email, PasswordHash = Password, SecurityStamp = SecurityStamp };
                context.Users.Add(user);
            }

            username = "admin";
            email = username + "@localhost.me";
            user = new User { UserName = username, Email = email, PasswordHash = Password, SecurityStamp = SecurityStamp };
            context.Users.Add(user);

            context.SaveChanges();
        }

        private void GenerateCategories(BookmarksDbContext context)
        {
            Category category;
            string name;

            for (int i = 1; i < 11; i++)
            {
                name = "Category" + i;
                category = new Category() { Name = name };

                context.Categories.Add(category);
            }

            context.SaveChanges();
        }

        private void GenerateBookmarks(BookmarksDbContext context)
        {
            Bookmark bookmark;
            string title;
            string description;
            string userId;
            string url;
            int categoryId;

            for (int i = 1; i < 11; i++)
            {
                title = "Bookmark" + i;
                description = i % 2 == 0 ? "Description" + i : null;
                userId = this.GetRandomUser(context).Id;
                url = "~/Bookmarks/Details/" + title;
                categoryId = this.random.Next(1, 10);
                bookmark = new Bookmark() { Title = title, Description = description, OwnerId = userId, Url = url, CategoryId = categoryId };

                context.Bookmarks.Add(bookmark);
            }

            context.SaveChanges();
        }

        private void GenerateComments(BookmarksDbContext context)
        {
            Comment comment;
            string text;
            int bookmarkId;
            string userId;

            for (int i = 1; i < 11; i++)
            {
                text = "Comment" + i;
                bookmarkId = this.GetRandomBookmark(context).Id;
                userId = this.GetRandomUser(context).Id;
                comment = new Comment() { Text = text, BookmarkId = bookmarkId, UserId = userId };

                context.Comments.Add(comment);
            }

            context.SaveChanges();
        }

        private void GenerateVotes(BookmarksDbContext context)
        {
            Vote vote;
            int stars;
            string userId;
            int bookmarkId;

            for (int i = 1; i < 11; i++)
            {
                stars = this.random.Next(0, 11);
                userId = this.GetRandomUser(context).Id;
                bookmarkId = this.GetRandomBookmark(context).Id;
                vote = new Vote() { Stars = stars, UserId = userId, BookmarkId = bookmarkId };

                context.Votes.Add(vote);
            }

            context.SaveChanges();
        }

        private User GetRandomUser(BookmarksDbContext context)
        {
            User user = null;

            while (user == null)
            {
                string randomNumber = this.random.Next(1, 10).ToString();
                user = context.Users.FirstOrDefault(u => u.UserName.Contains(randomNumber));
            }

            return user;
        }

        private Bookmark GetRandomBookmark(BookmarksDbContext context)
        {
            Bookmark bookmark = null;

            while (bookmark == null)
            {
                int randomNumber = this.random.Next(1, 10);
                bookmark = context.Bookmarks.Find(randomNumber);
            }

            return bookmark;
        }
    }
}
