namespace TheRecordStore.Models
{
    public class ErrorViewModel
    {
        public string? Requestid { get; set; }

        public bool ShowRequestid => !string.IsNullOrEmpty(Requestid);
    }
}
