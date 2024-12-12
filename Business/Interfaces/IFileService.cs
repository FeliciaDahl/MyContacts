using Business.Entites;

namespace Business.Interfaces
{
    public interface IFileService
    {
        List<ContactEntity> LoadListFromFile();
        void SaveListToFile(List<ContactEntity> list);
    }
}