
using Business.Factories;
using Business.Models;

namespace Business.Test.Factories;

public class ContactFactory_Tests
{
    [Fact]

    public void Create_ShouldReturnContactModel()
    {
        //act
        ContactModel result = ContactFactory.Create();

        //assert
        Assert.IsType<ContactModel>(result);
    }
   
}
