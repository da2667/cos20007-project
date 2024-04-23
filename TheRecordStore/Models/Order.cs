namespace TheRecordStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public required List<Record> Records { get; set; }
        public required DateTime OrderDate { get; set; }
        public required double TotalPrice { get; set; }
        public required bool Completed { get; set; }
    }
}
