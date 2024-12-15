
using Business.Entites;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Moq;

namespace Business.Test.Factories;

public class ContactEntityFactory_Tests
{
    [Fact]
    public void Create_FromContactModel_ShouldReturnContactEntityWithPropertiesAndId()
    {
        // arrange
        var mockIdGenerator = new Mock<IGenerateUniqeId>();
        var Id = "TestId";
        mockIdGenerator
            .Setup(generate => generate.GenerateId())
            .Returns(Id);

        var contact = new ContactModel
        {
         
            FirstName = "TestFirstName",
            LastName = "TestLastName",
            Email = "test@example.com",
            Phone = "123456789",
            Address = "Street",
            PostalCode = "12345",
            City = "GBG"
        };

        // act
        var entity = ContactEntityFactory.Create(contact, mockIdGenerator.Object);

        // assert
        Assert.NotNull(entity);
        Assert.Equal(Id, entity.Id);
        Assert.Equal(contact.LastName, entity.LastName);
        Assert.Equal(contact.Email, entity.Email);
        Assert.Equal(contact.Phone, entity.Phone);
        Assert.Equal(contact.Address, entity.Address);
        Assert.Equal(contact.PostalCode, entity.PostalCode);
        Assert.Equal(contact.City, entity.City);
        Assert.NotEqual(default(DateTime), entity.CreatedDate); 
    }

    [Fact]
    public void Create_FromContactEntity_ShouldReturnContactModelWithProperties()
    {
        // arrange
        var entity = new ContactEntity
        {
          
            FirstName = "TestFirstName2",
            LastName = "TestLastName2",
            Email = "test2@example.com",
            Phone = "123456789",
            Address = "Street 2",
            PostalCode = "123",
            City = "GBG",
            CreatedDate = DateTime.Now
        };

        // act
        var contactM = ContactEntityFactory.Create(entity);

        // assert
        Assert.NotNull(contactM);
        Assert.Equal(entity.Id, contactM.Id);
        Assert.Equal(entity.FirstName, contactM.FirstName);
        Assert.Equal(entity.LastName, contactM.LastName);
        Assert.Equal(entity.Email, contactM.Email);
        Assert.Equal(entity.Phone, contactM.Phone);
        Assert.Equal(entity.Address, contactM.Address);
        Assert.Equal(entity.PostalCode, contactM.PostalCode);
        Assert.Equal(entity.City, contactM.City);
    }
}


