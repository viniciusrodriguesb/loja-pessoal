namespace Domain.Entities
{
    public class TB001_USUARIO
    {
        public int NuUsuario { get; set; }
        public int IcUsuario { get; set; }
        public string CoSenha { get; set; }
        public string NoEmail { get; set; }
        public string NoUsuario { get; set; }

        #region Navigations
        public List<TB003_USUARIO_EMPRESA> UsuarioEmpresaNavigation { get; set; } 
        #endregion

    }
}
