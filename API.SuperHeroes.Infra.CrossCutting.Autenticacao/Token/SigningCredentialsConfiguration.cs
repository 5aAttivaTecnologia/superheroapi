using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Template.Cadastro.Infra.CrossCutting.Autenticacao
{
    public class SigningCredentialsConfiguration
    {
        private const string SecretKey = "template_hauhauhauhauhauahauha";
        public static readonly SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public SigningCredentials SigningCredentials { get; }

        public SigningCredentialsConfiguration()
        {
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
        }
    }
}