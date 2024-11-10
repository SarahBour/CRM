namespace Culture2Geth.Models
{
    public class Interest
    {
        public int InterestID { get; set; }
        public string Name { get; set; }
        public List<UserInterest> UserInterests { get; set; }
    }
}
