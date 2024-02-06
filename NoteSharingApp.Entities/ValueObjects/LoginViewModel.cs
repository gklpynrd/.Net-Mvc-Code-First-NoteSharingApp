using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoteSharingApp.Entities.ValueObjects
{
    public class LoginViewModel
    {
        [DisplayName("Username"),
         Required(ErrorMessage = "{0} Can't be empty."),
         StringLength(25, ErrorMessage = "{0} max. {1} characters.")]
        public string Username { get; set; }

        [DisplayName("Şifre"),
         Required(ErrorMessage = "{0} Can't be empty."),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} characters.")]
        public string Password { get; set; }
    }
}
