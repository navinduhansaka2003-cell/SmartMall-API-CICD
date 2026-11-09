namespace SmartMall.API.Models
{
    public class Category
    {
        public int Id { get; set; }
       
        public string Name { get; set; } = string.Empty;
        public string CategoryType { get; set; } = string.Empty;
    }
}