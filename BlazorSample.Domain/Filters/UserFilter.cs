using System;

namespace BlazorSample.Domain
{
    public class UserFilter
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public string ImageBase64 { get; set; }
    }
}
