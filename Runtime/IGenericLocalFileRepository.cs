namespace Project
{
    public interface IGenericLocalFileRepository<TData>
    {
        TData Load();
        void Save(TData userSettingsSaveDataData);
    }
}