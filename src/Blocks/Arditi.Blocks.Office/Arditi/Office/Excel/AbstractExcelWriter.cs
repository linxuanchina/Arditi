using System.Diagnostics;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Serilog;
using Serilog.Events;

namespace Arditi.Office.Excel;

public abstract class AbstractExcelWriter<TBook, TSheet, TRow, TCell>
    where TBook : IExcelBook<TSheet, TRow, TCell>
    where TSheet : IExcelSheet<TRow, TCell>
    where TRow : IExcelRow<TCell>
    where TCell : IExcelCell
{
    private static readonly ILogger s_logger = Log.ForContext<AbstractExcelWriter<TBook, TSheet, TRow, TCell>>();

    protected abstract ICell WriteCell(IRow row, TCell cell);
    protected abstract IRow WriteRow(ISheet sheet, TRow row);
    protected abstract ISheet WriteSheet(IWorkbook workbook, TSheet sheet);
    protected abstract void WriteBook(IWorkbook workbook, TBook book);

    public void Write(TBook book, Stream stream)
    {
        var stopwatch = Stopwatch.StartNew();

        IWorkbook workbook = new HSSFWorkbook();

        WriteBook(workbook, book);

        foreach (var sheet in book.Sheets)
        {
            var workSheet = WriteSheet(workbook, sheet);

            foreach (var row in sheet.Rows)
            {
                var workRow = WriteRow(workSheet, row);

                foreach (var cell in row.Cells)
                {
                    WriteCell(workRow, cell);
                }
            }
        }

        workbook.Write(stream);

        stopwatch.Stop();

        if (s_logger.IsEnabled(LogEventLevel.Information))
        {
            s_logger.Information("Finished writing the excel file ({ElapsedMilliseconds}ms)",
                stopwatch.ElapsedMilliseconds);
        }
    }
}
