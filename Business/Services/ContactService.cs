
using Business.Entites;
using Business.Factories;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService(IFileService fileService, IGenerateUniqeId generateId) : IContactService

    
{
    private readonly IFileService _fileService = fileService;
    private List<ContactEntity> _contacts = [];
    private readonly IGenerateUniqeId _generateId = generateId;

    public bool AddContact(ContactModel contact)
    {
        try
        {
            var contactEntity = ContactEntityFactory.Create(contact, _generateId);
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
    

