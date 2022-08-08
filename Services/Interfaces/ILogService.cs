namespace Services.Interfaces
{
    public interface ILogService
    {
        Task WriteError(Exception exception);
    }
}
