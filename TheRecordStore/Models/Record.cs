namespace TheRecordStore.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public required string Artist { get; set; }
        public required string Album { get; set; }
        public required double Price { get; set; }
        public required int Stock { get; set; }
    }
}
