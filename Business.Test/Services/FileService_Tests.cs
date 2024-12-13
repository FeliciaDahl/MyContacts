

using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;
using System.Text.Json;

namespace Business.Test.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;
    private readonly Mock<IGenerateUniqeId> _generateUniqeIdMock;
    public FileService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _generateUniqeIdMock = new Mock<IGenerateUniqeId>();

        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        _contactService = new ContactService(_fileServiceMock.Object, _generateUniqeIdMock.Object, jsonOptions);
    }

    [Fact]
    public void SaveListToFile_ShouldReturnTrue_WhenContactIsCreatedAndSavedToFile()
    {
        //arrange
        var contactModel = new ContactModel();
     
        _fileServiceMock
            .Setup(fs => fs.SaveListToFile(It.IsAny<string>()))
            .Returns(true);
        //act
        var result = _contactService.AddContact(contactModel);

        //assert
        Assert.True(result);

        _fileServiceMock.Verify(fs => fs.SaveListToFile(It.IsAny<string>()), Times.Once);

    }

    [Fact]
    public void LoadListFromFile_ShouldReturnContentFromFile()
    {

    }
}