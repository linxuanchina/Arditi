namespace Arditi.Office.Excel;

public interface IExcelRow<out TCell>
    where TCell : IExcelCell
{
    int RowIndex { get; }

    IEnumerable<TCell> Cells { get; }
}
