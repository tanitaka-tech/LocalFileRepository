namespace Project
{
    /// <summary>
    /// ローカルのファイル操作を行うinterface
    /// </summary>
    public interface ILocalFileRepository
    {
        void Save(string path, byte[] data);
        byte[] Load(string path);
        bool FileExists(string path);
        void Delete(string path);
    }
}