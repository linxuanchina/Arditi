using System.Diagnostics;
using NPOI.SS.UserModel;
using Serilog;
using Serilog.Events;

namespace Arditi.Office.Excel;

public abstract class AbstractExcelReader<TBook, TSheet, TRow, TCell>
    where TBook : IExcelBook<TSheet, TRow, TCell>
    where TSheet : IExcelSheet<TRow, TCell>
    where TRow : IExcelRow<TCell>
    where TCell : IExcelCell
{
    private static readonly ILogger s_logger = Log.ForContext<AbstractExcelReader<TBook, TSheet, TRow, TCell>>();

    protected abstract TCell? ReadCell(ICell cell);
    protected abstract TRow? ReadRow(IRow row, IEnumerable<TCell> cells);
    protected abstract TSheet? ReadSheet(ISheet sheet, IEnumerable<TRow> rows);
    protected abstract TBook? ReadBook(IWorkbook workbook, IEnumerable<TSheet> sheets);

    public virtual TBook? Read(Stream stream)
    {
        var stopwatch = Stopwatch.StartNew();

        var workBook = WorkbookFactory.Create(stream);

        IList<TSheet> sheets = new List<TSheet>();

        for (var sheetIndex = 0; sheetIndex < workBook.NumberOfSheets; sheetIndex++)
        {
            var workSheet = workBook.GetSheetAt(sheetIndex);

            IList<TRow> rows = new List<TRow>();

            foreach (IRow workRow in workSheet)
            {
                IList<TCell> cells = new List<TCell>();

                foreach (var workCell in workRow.Cells)
                {
                    var cell = ReadCell(workCell);

                    if (cell != null)
                    {
                        cells.Add(cell);
                    }
                }

                if (cells.IsNullOrEmpty())
                {
                    continue;
                }

                var row = ReadRow(workRow, cells);

                if (row != null)
                {
                    rows.Add(row);
                }
            }

            if (rows.IsNullOrEmpty())
            {
                continue;
            }

            var sheet = ReadSheet(workSheet, rows);

            if (sheet != null)
            {
                sheets.Add(sheet);
            }
        }

        TBook? book = default;

        if (sheets.IsNotNullOrEmpty())
        {
            book = ReadBook(workBook, sheets);
        }

        stopwatch.Stop();

        if (s_logger.IsEnabled(LogEventLevel.Information))
        {
            s_logger.Information("Finished reading the excel file ({ElapsedMilliseconds}ms)",
                stopwatch.ElapsedMilliseconds);
        }

        return book;
    }
}
