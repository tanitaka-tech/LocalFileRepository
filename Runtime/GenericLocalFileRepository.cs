namespace TanitakaTech.LocalFileRepository
{
    public abstract class GenericLocalFileRepository<TData> : IGenericLocalFileRepository<TData> where TData : class
    {
        private ILocalFileRepository LocalFileRepository { get; }
        protected ICryptographer Cryptographer { get; }
        
        private TData _data = null;
        protected string FilePath => GetFilePath();
        protected string FilePassword => GetFilePassword();
        
        protected abstract TData CreateDefaultSettingData();
        protected abstract string GetFilePath();
        protected abstract string GetFilePassword();


        protected GenericLocalFileRepository(ILocalFileRepository localFileRepository, ICryptographer cryptographer)
        {
            LocalFileRepository = localFileRepository;
            Cryptographer = cryptographer;
        }
        
        public void Init()
        {
            if (LocalFileRepository.FileExists(FilePath))
            {
                LocalFileRepository.Delete(FilePath);
                _data = null;
            }
        }

        public TData Load()
        {
            if (_data != null)
            {
                return _data;
            }

            if (LocalFileRepository.FileExists(FilePath))
            {
                var binary = LocalFileRepository.Load(FilePath);
                _data = Cryptographer.Decrypt<TData>(binary, FilePassword);
                return _data;
            }
            else
            {
                _data = CreateDefaultSettingData();
                Save(_data);
                return _data;
            }
        }

        public void Save(TData userSettingsSaveDataData)
        {
            _data = userSettingsSaveDataData;
            var secureBinary = Cryptographer.Encrypt(_data, FilePassword);
            LocalFileRepository.Save(FilePath, secureBinary);
        }
    }
}