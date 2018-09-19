using System.ComponentModel.DataAnnotations;

namespace Template.Cadastro.Api.ViewModels
{
    public sealed class LoginViewModel
    {
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Este campo só permite até 150 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo só permite até 20 caracteres")]
        public string Senha { get; set; }
    }
}
