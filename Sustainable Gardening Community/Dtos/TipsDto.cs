using System.ComponentModel.DataAnnotations;

namespace Sustainable_Gardening_Community.Dtos
{
    public class TipsDto
    {
        public TipsDto()
        {
            
        }
        public int Id { get; set; }

        public string? Image { get; set; } = default!;
        [Display(Name = "Image")]
        public IFormFile? ImagePath { get; set; } = default!;
        [Required, Display(Name = "Title")]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
