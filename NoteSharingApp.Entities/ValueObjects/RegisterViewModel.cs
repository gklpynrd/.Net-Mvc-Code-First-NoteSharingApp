using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NoteSharingApp.Entities.ValueObjects
{
    public class RegisterViewModel
    {
        [DisplayName("Username"),
         Required(ErrorMessage = "{0} Can't be empty."),
         StringLength(25, ErrorMessage = "{0} max. {1} characters.")]
        public string Username { get; set; }

        [DisplayName("E-Mail"),
         Required(ErrorMessage = "{0} Can't be empty."),
         StringLength(70, ErrorMessage = "{0} max. {1} characters."),
         EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz.")]
        public string EMail { get; set; }

        [DisplayName("Password"),
         Required(ErrorMessage = "{0} Can't be empty."),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} characters.")]
        public string Password { get; set; }

        [DisplayName("Password Check"),
         Required(ErrorMessage = "{0} Can't be empty."),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} characters."),
         Compare("Password", ErrorMessage = "{0} and {1} don't match.")]
        public string RePassword { get; set; }
    }
}
