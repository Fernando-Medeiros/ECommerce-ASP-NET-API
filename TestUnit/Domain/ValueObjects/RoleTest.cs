using ECommerceDomain.Enums;
using ECommerceCommon.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestUnit.Domain.ValueObjects;

public class RoleTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { nameof(ERole.customer) };
        yield return new object[] { nameof(ERole.employee) };
        yield return new object[] { nameof(ERole.employee) };
    }

    public static IEnumerable<object[]> ExceptionData()
    {
        yield return new object[] { "any string" };
        yield return new object[] { "Manager" };
        yield return new object[] { nameof(ERole.employee) + "1" };
    }

    [Theory]
    [MemberData(nameof(SuccessData))]
    public void Should_Create_Role(string? input)
    {
        Assert.Equal(new Role(input), input);
    }

    [Theory]
    [InlineData(null)]
    [MemberData(nameof(SuccessData))]
    public void Should_Update_Role_Or_Not(string? input)
    {
        Assert.Equal(new Role(input, required: false), input);
    }

    [Theory]
    [MemberData(nameof(ExceptionData))]
    public void Should_Throw_Exception_On_Create_Role(string? input)
    {
        Assert.Throws<RoleTypeException>(() => new Role(input));
    }
}
