namespace Arditi.JuheAPI;

public static class ResponseExtensions
{
    public static bool IsSucceed(this Response response) => response.ErrorCode == 0;
}
