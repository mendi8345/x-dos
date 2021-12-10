using System.ComponentModel.DataAnnotations;

namespace X_dos.Models
{
    public class User
    {
            public int Id { get; set; }
        public String Name { get; set; }
        [EmailAddress]
        public String Email { get; set; }
        //public String Phone { get; set; }
        [RegularExpression(@"^0x[ a-fA-F0-9 ]{40}$", ErrorMessage = "You must inser a valid address, please check your address and try again")]
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}
