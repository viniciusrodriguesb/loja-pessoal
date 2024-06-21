namespace Application.DTO.Response
{
    public class UsuarioResponse
    {
        private string _senha;
        private string _email;
        public string Usuario { get; set; }
        public string Senha { get => MascararSenha(_senha); set => _senha = value; }
        public string Email { get => MascararEmail(_email); set => _email = value; }

        private string MascararSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return string.Empty;

            return new string('*', senha.Length);
        }
        private string MascararEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return string.Empty;

            int atIndex = email.IndexOf('@');

            return new string('*', atIndex) + email.Substring(atIndex);

        }

    }
}
