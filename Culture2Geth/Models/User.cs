namespace Culture2Geth.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string MembershipType { get; set; }
        public string JoinDate { get; set; }
        public string ExpiryDate { get; set; }

        public string Role { get; set; }
        public int MailingList { get; set; }

        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string ProfileStatus { get; set; }



    }
}
