using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBlogProject.Models
{
    public class BlogUser: IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "The {0} must be at least {2} and no more that {1} characters long", MinimumLength =2)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "The {0} must be at least {2} and no more that {1} characters long", MinimumLength = 2)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public byte[]? ImageData { get; set; }

        public string? ContentType { get; set; }

        
        [StringLength(maximumLength: 100, ErrorMessage = "The {0} must be at least {2} and no more that {1} characters long", MinimumLength = 2)]
        public string FacebookUrl { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "The {0} must be at least {2} and no more that {1} characters long", MinimumLength = 2)]
        public string TwitterUrl { get; set; }

        [NotMapped]
        public string FullName
        {

            get
            {
                return $"{FirstName} {LastName}";
            }
            
        }

        //Navigation Property

        public ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
        public ICollection<Post> Post { get; set; } = new HashSet<Post>();



    }
}
