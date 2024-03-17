namespace StockProductLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual Provider Provider { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}
