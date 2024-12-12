
using Business.Entites;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace Business.Test.Services;

public class ContactService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;
    
    public ContactService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactService = new ContactService(_fileServiceMock.Object);
    }

    [Fact]
    public void AddContact_ShouldReturnTrue_WhenContactIsCreatedAndSavedToFile()
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

        _fileServiceMock
            .Setup(fs => fs.SaveListToFile(It.IsAny<List<ContactEntity>>()))
            .Verifiable();
        //act
        var result = _contactService.AddContact(contactModel);

      //assert
      Assert.True(result);

       //Med hjälp av ChaptGpt har jag fått fram denna sträng som verifierar att listan
       //innehåller ett element, som har första värdet är "TestFirstName". Metoden SaveListToFile anropas en gång när villkoren uppfyllts.

        _fileServiceMock.Verify(fs => fs.SaveListToFile(It.Is<List<ContactEntity>>
    (list => list.Count == 1 && list[0].FirstName == "TestFirstName")), Times.Once);
    
        

   




    }
}
