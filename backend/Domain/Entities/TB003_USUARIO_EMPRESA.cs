namespace Domain.Entities
{
    public class TB003_USUARIO_EMPRESA
    {
        public int NuEmpresa {  get; set; }
        public int NuUsuario { get; set; }

        #region Navigations
        public virtual TB001_USUARIO UsuarioNavigation { get; set; }
        public virtual TB002_EMPRESA EmpresaNavigation { get; set; } 
        #endregion

    }
}
