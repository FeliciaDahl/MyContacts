
using Business.Helpers;
using Business.Interfaces;

namespace Business.Test.Helpers;

public class GenerateUniqeId_Tests
{
    [Fact]
    public void GenerateId_ShouldReturnStringOfTypeGuid()
    {
        var idGenerator = new GenerateUniqeId();

        //act
        string id = idGenerator.GenerateId();

        //assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
    }
}
