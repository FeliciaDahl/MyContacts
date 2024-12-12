
using Business.Entites;
using Business.Helpers;
using Business.Models;

namespace Business.Test.Factories;

public class ContactEntityFactory_Tests
{
    [Fact]
    public void Create_FromContactModel_ShouldReturnContactEntityWithProperties()
    {
        // Arrange
        var model = new ContactModel
        {
         
            FirstName = "TestFirstName",
            LastName = "TestLastName",
            Email = "test@example.com",
            Phone = "123456789",
            Address = "Street",
            PostalCode = "12345",
            City = "GBG"
        };

        // Act
        var entity = ContactEntityFactory.Create(model);

        // Assert
        Assert.NotNull(entity);
        Assert.Equal(model.Id, entity.Id);
        Assert.Equal(model.FirstName, entity.FirstName);
        Assert.Equal(model.LastName, entity.LastName);
        Assert.Equal(model.Email, entity.Email);
        Assert.Equal(model.Phone, entity.Phone);
        Assert.Equal(model.Address, entity.Address);
        Assert.Equal(model.PostalCode, entity.PostalCode);
        Assert.Equal(model.City, entity.City);
        Assert.NotEqual(default(DateTime), entity.CreatedDate); // CreatedDate ska inte vara default
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
        var model = ContactEntityFactory.Create(entity);

        // Assert
        Assert.NotNull(model);
        Assert.Equal(entity.Id, model.Id);
        Assert.Equal(entity.FirstName, model.FirstName);
        Assert.Equal(entity.LastName, model.LastName);
        Assert.Equal(entity.Email, model.Email);
        Assert.Equal(entity.Phone, model.Phone);
        Assert.Equal(entity.Address, model.Address);
        Assert.Equal(entity.PostalCode, model.PostalCode);
        Assert.Equal(entity.City, model.City);
    }
}


