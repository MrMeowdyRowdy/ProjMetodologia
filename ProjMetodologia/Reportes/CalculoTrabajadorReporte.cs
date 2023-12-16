using ClosedXML.Excel;
using ProjMetodologia.Data.Trabajador;

namespace ProjMetodologia.Reportes
{
    public class CalculoTrabajadorReporte
    {
        public byte[] Edition(List<CalculosTrabajador> data, int sucursal)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Reporte de Cálculos");

            ws.Cell(2, 2).Value = $"Reporte de salarios sucursal: {sucursal}";
            // Setting up the headers
            ws.Cell(3, 2).Value = "ID Trabajador";
            ws.Cell(3, 3).Value = "Nombres";
            ws.Cell(3, 4).Value = "Identificación";
            ws.Cell(3, 5).Value = "Remuneración Mínima";
            ws.Cell(3, 6).Value = "IESS Patrono";
            ws.Cell(3, 7).Value = "IESS Personal";
            ws.Cell(3, 8).Value = "Suma";

            int currentRow = 4;
            foreach (var item in data)
            {
                ws.Cell(currentRow, 2).Value = item.Id_Trabajador;
                ws.Cell(currentRow, 3).Value = item.Nombres;
                ws.Cell(currentRow, 4).Value = item.Identificacion;
                ws.Cell(currentRow, 5).Value = item.Remuneracion_Minima;
                ws.Cell(currentRow, 6).Value = item.IESS_Patrono;
                ws.Cell(currentRow, 7).Value = item.IESS_Personal;
                ws.Cell(currentRow, 8).Value = item.Suma;
                currentRow++;
            }

            // Style adjustments and auto-sizing columns as needed
            //ws.Columns().AdjustToContents();

            var rngTable = ws.Range($"B2:H{currentRow - 1}");

            var rngHeaders = rngTable.Range("B3:H3");
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.FontSize = 12;
            //rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

            rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;

            rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            rngTable.Cell(1, 1).Style.Font.Bold = true;
            //rngTable.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
            rngTable.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngTable.Cell(1, 1).Style.Font.FontSize = 14;

            rngTable.Row(1).Merge();

            ws.Columns(2, 8).AdjustToContents();

            ws.Column(1).Width = 2;

            ws.Row(1).Height = 10;

            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);
            return XLSStream.ToArray();
        }
    }
}
