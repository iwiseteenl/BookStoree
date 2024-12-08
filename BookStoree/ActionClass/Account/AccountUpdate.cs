using System.ComponentModel.DataAnnotations;

namespace BookStoree.ActionClass.Account
{
    public class AccountUpdate
    {
        [Required]
        public long ClientId { get; set; }
        [Required]
        public string Name { get; internal set; } = null!;
        [Required]
        public string phoneNumber { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string surname { get; set; } = null!;
        [Required]
        public long addressID { get; set; } 
    }
}
