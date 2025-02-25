﻿namespace Culture2Geth.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string Role { get; set; }
        public int MailingList { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileStatus { get; set; }

        public List<UserInterest> UserInterests { get; set; }



    }
}
