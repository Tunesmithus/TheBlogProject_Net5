using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TheBlogProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string BlogUserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="The {0} must be at least {2} and no more than {1} characters long", MinimumLength =2)]
        public string Text { get; set; }

        //navigation property
        public Post Post { get; set; }
        public BlogUser BlogUser { get; set; }

    }
}
