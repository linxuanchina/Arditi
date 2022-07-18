namespace Arditi.Office.Excel;

public interface IExcelCell
{
    int ColIndex { get; }

    string Value { get; }
}
