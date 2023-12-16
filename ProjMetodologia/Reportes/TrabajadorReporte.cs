using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ProjMetodologia.Data.CentroCosto;
using ProjMetodologia.Data.Trabajador;
using System.Reflection.PortableExecutable;

namespace ProjMetodologia.Reportes
{
    public class TrabajadorReporte
    {
        public byte[] Edition(List<Trabajador> data, int sucursal)
        {
            var wb = new XLWorkbook();

            var ws = wb.Worksheets.Add("Reporte de trabajadores");

            ws.Cell(2, 2).Value = $"Reporte de trabajadores sucursal: {sucursal}";

            ws.Cell(3, 2).Value = "Cedula";
            ws.Cell(3, 3).Value = "Nombres";
            ws.Cell(3, 4).Value = "Apellido materno";
            ws.Cell(3, 5).Value = "Apellido paterno";
            ws.Cell(3, 6).Value = "Genero";
            ws.Cell(3, 7).Value = "Nivel salarial";

            int currentRow = 4;

            foreach (var trabajador in data)
            {
                ws.Cell(currentRow, 2).Value = trabajador.Identificacion;
                ws.Cell(currentRow, 3).Value = trabajador.Nombres;
                ws.Cell(currentRow, 4).Value = trabajador.Apellido_Materno;
                ws.Cell(currentRow, 5).Value = trabajador.Apellido_Paterno;
                ws.Cell(currentRow, 6).Value = trabajador.Genero;
                ws.Cell(currentRow, 7).Value = trabajador.Remuneracion_Minima;

                currentRow++;
            }

            var rngTable = ws.Range($"B2:G{currentRow-1}");

            var rngHeaders = rngTable.Range("B3:G3");
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

            ws.Columns(2, 7).AdjustToContents();

            ws.Column(1).Width = 2;

            ws.Row(1).Height = 10;

            MemoryStream XLSStream = new();
            wb.SaveAs(XLSStream);

            return XLSStream.ToArray();
        }
    }
}
