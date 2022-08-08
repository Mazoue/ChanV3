namespace Services.Interfaces
{
    public interface IGeneralConfigService
    {
        bool ShowImagePreview();

        bool ShowWorkSafeOnlyBoards();
        string LogBasePath();
    }
}
