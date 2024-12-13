using Business.Entites;

namespace Business.Interfaces
{
    public interface IFileReader
    {
        List<ContactEntity> LoadListFromFile();
    }
}