using System.Collections.Generic;

namespace Forum.Models
{
    public class Tag
    {
        private ICollection<Post> posts;

        public Tag()
        {
            this.posts = new HashSet<Post>();
        }

        public int TagId { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}