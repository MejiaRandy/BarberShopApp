using System.ComponentModel.DataAnnotations;

namespace BarberShop.Dtos.LoginUser
{
        public class UserLoginDtoRequest
        {
                [MaxLength(255)]
                [Required]
                [EmailAddress]
                public string UserName  { get; set; }

                [Required]
                public string Password { get; set; }
        }
}
