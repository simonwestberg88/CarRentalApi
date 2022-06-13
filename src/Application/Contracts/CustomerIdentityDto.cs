using IdType = Application.Contracts.IdType;

namespace Application.Contracts;

public class CustomerIdentityDto
{
    public string IdentityNumber { get; set; }
    public IdType IdType { get; set; }
}