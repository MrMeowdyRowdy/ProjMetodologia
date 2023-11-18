namespace ProjMetodologia.Data.GestionNomina
{
    public class GestionNomina
    {
        public int Sucursal { get; set; }
        public int CodigoConceptoNomina { get; set; }
        public string DescripcionConcepto { get; set; }
        public int CodigoCategoriaocupacional { get; set; }
        public string DescripcionCategoria { get; set; }
        public string CodigoOperacion { get; set; }
        public double CodigoCuentaContable { get; set; }
        public string CodigoTipoCuenta { get; set; }
        public string DescripcionCuenta { get; set; }
        public object Mensaje { get; set; }
    }
}
