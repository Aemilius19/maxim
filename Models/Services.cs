using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maxim.Models
{
	public class Services
	{
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Title { get; set; }
		[Required]
		[MinLength(1)]
		[MaxLength(255)]
		public string Description { get; set; }
		[MinLength(1)]
		[MaxLength(255)]
		public string? ImgUrl { get; set; }
		[NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
