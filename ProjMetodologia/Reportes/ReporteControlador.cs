using Microsoft.JSInterop;
using ProjMetodologia.Data.Trabajador;

namespace ProjMetodologia.Reportes
{
    public class ReporteControlador
    {
        public async Task GenerarReporteTrabajador(IJSRuntime js,
                                                   List<Trabajador> data,
                                                   string filename = "export.xlsx",
                                                   int sucursal=0)
        {
            var trabajador = new TrabajadorReporte();
            var XLSStream = trabajador.Edition(data, sucursal);

            await js.InvokeVoidAsync("BlazorDownloadFile", filename, XLSStream);
        }
    }
}
