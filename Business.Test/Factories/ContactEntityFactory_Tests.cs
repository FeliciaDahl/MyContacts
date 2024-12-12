
using Business.Entites;
using Business.Helpers;
using Business.Models;

namespace Business.Test.Factories;

public class ContactEntityFactory_Tests
{
    [Fact]
    public void Create_FromContactModel_ShouldReturnContactEntityWithProperties()
    {
        // arrange
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
        var entity = ContactEntityFactory.Create(contact);

        // assert
        Assert.NotNull(entity);
        Assert.Equal(contact.Id, entity.Id);
        Assert.Equal(contact.FirstName, entity.FirstName);
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
        // Arrange
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

        // Act
        var contact = ContactEntityFactory.Create(entity);

        // Assert
        Assert.NotNull(contact);
        Assert.Equal(entity.Id, contact.Id);
        Assert.Equal(entity.FirstName, contact.FirstName);
        Assert.Equal(entity.LastName, contact.LastName);
        Assert.Equal(entity.Email, contact.Email);
        Assert.Equal(entity.Phone, contact.Phone);
        Assert.Equal(entity.Address, contact.Address);
        Assert.Equal(entity.PostalCode, contact.PostalCode);
        Assert.Equal(entity.City, contact.City);
    }
}


