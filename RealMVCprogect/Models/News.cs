namespace RealMVCprogect.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }


    }
}
