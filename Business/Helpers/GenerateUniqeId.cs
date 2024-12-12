
using Business.Interfaces;

namespace Business.Helpers;

public class GenerateUniqeId : IGenerateUniqeId
{
    public static string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }

}
