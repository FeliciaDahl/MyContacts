using Business.Entites;

namespace Business.Interfaces
{
    public interface IFileWriter
    {
        bool SaveListToFile(string content);
    }
}