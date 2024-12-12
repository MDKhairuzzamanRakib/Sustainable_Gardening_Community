namespace Sustainable_Gardening_Community.Models
{
    public class Tips
    {
        public Tips()
        {

        }
        public int Id { get; set; }

        public string? Image { get; set; } = default!;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
