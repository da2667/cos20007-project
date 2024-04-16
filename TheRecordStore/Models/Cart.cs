namespace TheRecordStore.Models
{
    public class Cart
    {
        public List<Record>? items { get; set; }
        public double totalPrice { get; set; }
    }
}
