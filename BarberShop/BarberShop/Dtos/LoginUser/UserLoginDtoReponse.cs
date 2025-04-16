using BarberShop.Enums;

namespace BarberShop.Dtos.LoginUser
{
        public class UserLoginDtoReponse 
        {
                public string? Id { get; set; }
                public string? FirstName { get; set; }
                public string? LastName { get; set; }
                public string FullName => $"{FirstName} {LastName}";
                public string? Email { get; set; }
                public string? PhoneNumber { get; set; }
                public string? UserName { get; set; }
                public string? Password { get; set; }
                public string? ConfirmPassowrd { get; set; }
                public UserRoles Role { get; set; }
                public bool? IsActive { get; set; }
        }
}
