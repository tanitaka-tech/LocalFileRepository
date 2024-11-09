namespace TanitakaTech.LocalFileRepository
{
    /// <summary>
    /// データを暗号化/複合化するinterface
    /// </summary>
    public interface ICryptographer
    {
        public byte[] Encrypt<T>(T obj, string password);
        public T Decrypt<T>(byte[] data, string password);
    }
}