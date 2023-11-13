using ProjMetodologia.Data.CentroCosto;

namespace ProjMetodologia.Data.MovimientoPlanilla
{
    public class SharedMovimientoPlanilla
    {
        public MovimientoPlanilla Value { get; set; }
        public void SetValue(MovimientoPlanilla value)
        {
            this.Value = value;
        }
    }
}
