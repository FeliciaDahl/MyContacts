
using Business.Entites;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService

    
{
    private readonly IFileService _fileService = fileService;
    private List<ContactEntity> _contacts = [];

    public bool AddContact(ContactModel contact)
    {
        try
        {
            var contactEntity = ContactEntityFactory.Create(contact);
            _contacts.Add(contactEntity);
            _fileService.SaveListToFile(_contacts);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<ContactModel> GetAll()
    {
        _contacts = _fileService.LoadListFromFile();

        return _contacts.Select(contact => ContactEntityFactory.Create(contact));
    }
}
    

