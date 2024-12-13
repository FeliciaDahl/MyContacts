
using Business.Interfaces;
using Business.Models;
using Moq;
using System.Net;
using System.Numerics;

namespace Business.Test.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _contactService = _contactServiceMock.Object;
    }

    [Fact]  
    public void AddContact_ShouldReturnTrue_WhenContactIsCreated()
    {
        //arrange
        var contactModel = new ContactModel
        {
           FirstName = "TestFirstName",
           LastName = "TestLastName",
           Email = "test@example.com",
           Phone = "123456789",
           Address = "Street",
           PostalCode = "12345",
           City = "GBG"
        };
        _contactServiceMock
            .Setup(cs => cs.AddContact(contactModel))
            .Returns(true);

        //act
        var result = _contactService.AddContact(contactModel);
      
        //assert
        Assert.True(result);
        _contactServiceMock.Verify(cs => cs.AddContact(contactModel), Times.Once);
    }

    [Fact]

    public void GetAll_ShouldReturnContactListWithAllContacts()
    {
        //arrange

        var contacts = new List<Contact>()
        {
            new() {
                Id = "123",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Email = "test@example.com",
                Phone = "123456789",
                Address = "Street",
                PostalCode = "12345",
                City = "GBG"
                },
            new() {
                Id = "456",
                FirstName = "TestFirstName2",
                LastName = "TestLastName2",
                Email = "test2@example.com",
                Phone = "123456789",
                Address = "Street 2",
                PostalCode = "123",
                City = "GBG",
            }

        };
        _contactServiceMock.Setup(cs => cs.GetAll()).Returns(contacts);

        //act
        var result = _contactService.GetAll();

        //assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }
}
