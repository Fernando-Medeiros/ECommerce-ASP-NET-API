using ECommerceDomain.Exceptions;
using ECommerceDomain.ValueObjects;

namespace TestsUnit.ECommerceDomain.ValueObjects;

public class FullNameTest
{
    public static IEnumerable<object[]> SuccessData()
    {
        yield return new object[] { "Test", "Example", "Sample" };
        yield return new object[] { "John", "Dee", "Dee" };
        yield return new object[] { "Shun Lee", "speed", "legs" };
        yield return new object[] { "John Dee", "foo", "again" };
        yield return new object[] { "Julius Cesar", "crazy", "bitch" };
    }

    public static IEnumerable<object[]> ExceptionData()
    {
        yield return new object[] { "Test", "", "" };
        yield return new object[] { "16/", "09/", "2023/" };
        yield return new object[] { "Example Test", "Dev", "2222" };
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
    [InlineData(null, null, null)]
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
    [MemberData(nameof(ExceptionData))]
    public void Should_Return_Exception_On_Create_FullName(
        string? name, string? firstName, string? lastName)
    {
        Assert.Throws<NameFormatException>(() =>
        {
            new FullName(
                name: new Name(name),
                firstName: new Name(firstName),
                lastName: new Name(lastName));
        });
    }
}
