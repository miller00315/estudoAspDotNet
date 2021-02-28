namespace Domain.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }

        public bool IsActive { get; set; }
    }
}