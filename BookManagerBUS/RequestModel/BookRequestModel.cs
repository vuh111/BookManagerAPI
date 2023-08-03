using BookManagerEntities.Entities;

namespace BookManagerBUS.RequestModel
{
    public class BookRequestModel
    {
        
        public string Name { get; set; }
        public DateTime PublicDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
