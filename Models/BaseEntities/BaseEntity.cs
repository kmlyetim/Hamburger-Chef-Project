namespace HamburgerMenuProject.Models.BaseEntities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public decimal? Price { get; set; }
        public int Piece { get; set; } = 1;
        public string? Photo { get; set; }
    }
}
