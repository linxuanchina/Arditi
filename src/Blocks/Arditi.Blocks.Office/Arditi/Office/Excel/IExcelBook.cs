namespace Arditi.Office.Excel;

public interface IExcelBook<out TSheet, TRow, TCell>
    where TSheet : IExcelSheet<TRow, TCell>
    where TRow : IExcelRow<TCell>
    where TCell : IExcelCell
{
    IEnumerable<TSheet> Sheets { get; }
}
