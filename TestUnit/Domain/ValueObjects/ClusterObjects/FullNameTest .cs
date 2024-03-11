using ECommerceDomain.ClusterObjects;
using ECommerceCommon.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestUnit.Domain.ClusterObjects;

public class FullNameTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { "Test", "Example", "Sample" };
        yield return new object[] { "John", "Dee", "Foo" };
        yield return new object[] { "Shun Lee", "speed", "legs" };
        yield return new object[] { "John Dee", "foo", "again" };
        yield return new object[] { "Julius Cesar", "crazy", "bitch" };
    }

    public static IEnumerable<object[]> ExceptionData()
    {
        yield return new object[] { "John", "John", "John" };
        yield return new object[] { "john", "Dee", "Dee" };
        yield return new object[] { "john", "john", "Dee" };
    }

    [Theory]
    [MemberData(nameof(SuccessData))]
    public void Should_Create_FullName(
        string? name, string? firstName, string? lastName)
    {
        var fullName = new FullName(
            name: new Name(name),
            firstName: new Name(firstName),
            lastName: new Name(lastName));

        Assert.Equal(fullName.Name, name);
        Assert.Equal(fullName.FirstName, firstName);
        Assert.Equal(fullName.LastName, lastName);
    }


    [Theory]
    [InlineData("John", "dee", null)]
    [MemberData(nameof(SuccessData))]
    public void Should_Update_FullName_Or_Not(
        string? name, string? firstName, string? lastName)
    {
        var fullName = new FullName(
            name: new Name(name, required: false),
            firstName: new Name(firstName, required: false),
            lastName: new Name(lastName, required: false));

        Assert.Equal(fullName.Name, name);
        Assert.Equal(fullName.FirstName, firstName);
        Assert.Equal(fullName.LastName, lastName);
    }

    [Theory]
    [InlineData(null, null, null)]
    [MemberData(nameof(ExceptionData))]
    public void Should_Throw_Exception_On_Create_FullName(
        string? name, string? firstName, string? lastName)
    {
        Assert.Throws<FullNameFormatException>(() =>
        {
            new FullName(
                name: new Name(name, required: false),
                firstName: new Name(firstName, required: false),
                lastName: new Name(lastName, required: false));
        });
    }
}
