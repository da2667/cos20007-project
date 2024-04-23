namespace TheRecordStore.Models
{
    public class Customer
    {
        public required int id { get; set; }
        public required string Name { get; set; }
        public required Membership Membership { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
