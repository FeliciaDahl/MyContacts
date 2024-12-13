using Business.Entites;

namespace Business.Interfaces
{
    public interface IFileWriter
    {
        void SaveListToFile(List<ContactEntity> list);
    }
}