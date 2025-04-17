using BarberShop.Enums;
using System.ComponentModel.DataAnnotations;

namespace BarberShop.ViewModels.UserLogin
{
        public class RegisterUserViewModels
        {
                public string? Id { get; set; }

                [Required(ErrorMessage = "Debe colocar un nombre")]
                [DataType(DataType.Text)]
                [Display(Name = "Nombre")]
                public string? FirstName { get; set; }

                [Required(ErrorMessage = "Debe colocar un apellido")]
                [DataType(DataType.Text)]
                [Display(Name = "Apellido")]
                public string? LastName { get; set; }

                [Required(ErrorMessage = "Debe colocar un correo")]
                [DataType(DataType.EmailAddress)]
                [Display(Name = "Correo")]
                public string? Email { get; set; }

                [Required(ErrorMessage = "Debe colocar un numero de telefono")]
                [DataType(DataType.Text)]
                [Display(Name = "Numero de telefono")]
                public string? PhoneNumber { get; set; }

                [Required(ErrorMessage = "Debe colocar un username")]
                [DataType(DataType.Text)]
                [Display(Name = "Nombre de usuario")]
                public string? UserName { get; set; }

                [Required(ErrorMessage = "Debe colocar una password")]
                [DataType(DataType.Password)]
                [Display(Name = "Contraseña")]
                public string? Password { get; set; }

                [Required(ErrorMessage = "Debe colocar colocar la password de nuevo")]
                [DataType(DataType.Password)]
                [Display(Name = "Confirmar contraseña")]
                public string? ConfirmPassword { get; set; }

                [Required(ErrorMessage = "Debe elegit un role")]
                [Display(Name = "Rol de usuario")]
                public UserRoles Role { get; set; }
        }
}
