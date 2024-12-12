
using Business.Helpers;

namespace Business.Test.Helpers;

public class GenerateUniqeId_Tests
{
    [Fact]
    public void GenerateId_ShouldReturnStringOfTypeGuid()
    {
        //act
        string id = GenerateUniqeId.GenerateId();

        //assert
        Assert.False(string.IsNullOrEmpty(id));
        Assert.True(Guid.TryParse(id, out _));
    }
}
