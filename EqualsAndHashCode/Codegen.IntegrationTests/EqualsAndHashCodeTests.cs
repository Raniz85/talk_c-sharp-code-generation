using FluentAssertions;
using Xunit;
using Codegen;

namespace Codegen.IntegrationTests;

[EqualsAndHashCode]
public partial class TestSubject
{
    private string name;
    private int number;

    public TestSubject(string name, int number)
    {
        this.name = name;
        this.number = number;
    }
}

public class EqualsAndHashCodeTests
{
    [Fact]
    public void ThatEqualInstancesAreConsideredEqual()
    {
        // Given two equal instances of the same class
        var a = new TestSubject("foo", 7);
        var b = new TestSubject("foo", 7);
        
        // Expect them to be considered equal
        a.Equals(b).Should().BeTrue();
    }
}