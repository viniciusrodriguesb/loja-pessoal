namespace Domain.Entities
{
    public class TB003_USUARIO_EMPRESA
    {
        public int NuEmpresa {  get; set; }
        public int NuUsuario { get; set; }


        public virtual TB001_USUARIO UsuarioNavigation { get; set; }
        
        //EmpresaNavigation
        //public virtual TB001_USUARIO UsuarioNavigation { get; set; }
    }
}
