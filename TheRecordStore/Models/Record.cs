namespace TheRecordStore.Models
{
    public class Record
    {
        public int id { get; set; }
        public string? artist { get; set; }
        public string? album { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public bool? available { get; set; }
    }
}
