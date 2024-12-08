using System.ComponentModel.DataAnnotations;

namespace BookStoree.ActionClass.HelperClass
{
    public class AccountDTOs
    {
        [Key]
        public long ClientId { get; set; }
        public string Name { get; internal set; } = null!;
        public string phoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string surname { get; set; } = null!;
        public long addressID { get; set; } 
    }
}
