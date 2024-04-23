namespace TheRecordStore.Models
{
    public class Membership
    {
        public enum MembershipTypes
        {
            Bronze,
            Silver,
            Gold,
            Platinum
        }

        public required int Id { get; set; }

        public required MembershipTypes MembershipType { get; set; }
    }
}
