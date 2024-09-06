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

    public static IEnumerable<object[]> EqualityTestData()
    {
        return
        [
            [new TestSubject("foo", 7), new TestSubject("foo", 7), true],
            [new TestSubject("bar", 7), new TestSubject("foo", 7), false],
            [new TestSubject("bar", 8), new TestSubject("foo", 7), false],
            [new TestSubject("foo", 8), new TestSubject("foo", 7), false],
            [new TestSubject("foo", 8), null, false],
        ];
    }
    
    [Theory]
    [MemberData(nameof(EqualityTestData))]
    public void ThatEqualityCheckWorksAsExpected(TestSubject a, TestSubject? b, bool expectedEqual)
    {
        // Expect their equality to be correct
        a.Equals(b).Should().Be(expectedEqual);
    }


    [Fact]
    public void ThatGetHashCodeReturnsSameHashForEqualObjects()
    {
        // Given two equal test subjects
        var a = new TestSubject("bar", 8);
        var b = new TestSubject("bar", 8);
        
        // Expect their hash codes to be equal
        a.GetHashCode().Should().Be(b.GetHashCode());
    }
}