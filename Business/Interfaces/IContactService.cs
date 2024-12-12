using Business.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool AddContact(ContactModel contact);
        IEnumerable<ContactModel> GetAll();
    }
}