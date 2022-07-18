namespace Arditi.Office.Excel;

public interface IExcelSheet<out TRow, TCell>
    where TRow : IExcelRow<TCell>
    where TCell : IExcelCell
{
    IEnumerable<TRow> Rows { get; }
}
