namespace TanitakaTech.LocalFileRepository
{
    public interface IGenericLocalFileRepository<TData>
    {
        TData Load();
        void Save(TData userSettingsSaveDataData);
    }
}