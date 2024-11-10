namespace Culture2Geth.Models
{
    public class UserInterest
    {
        public int UserInterestID { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }

        public int InterestID { get; set; }
        public Interest interest { get; set; }
    }
}
