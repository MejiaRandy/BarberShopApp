using System.ComponentModel.DataAnnotations;

namespace BarberShop.ViewModels.UserLogin
{
        public class LoginViewModel
        {
                [Required(ErrorMessage = "Nombre de usuario requerido.")]
                [DataType(DataType.Text)]
                [Display(Name = "Nombre de usuario")]
                public string? Username { get; set; }

                [Required(ErrorMessage = "Contraseña requerida.")]
                [DataType(DataType.Password)]
                [Display(Name = "Contraseña")]
                public string? Password { get; set; }
        }
}
