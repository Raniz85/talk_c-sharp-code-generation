using FluentAssertions;
using Xunit;

namespace Codegen.IntegrationTests;

public class EqualsAndHashCodeFunctionalityTest
{

    public static IEnumerable<object[]> EqualityTestData()
    {
        return
        [
            [ new TestSubject("foo", 7), new TestSubject("foo", 7), true],
            [ new TestSubject("foo", 8), new TestSubject("foo", 7), false],
            [ new TestSubject("bar", 7), new TestSubject("foo", 7), false],
            [ new TestSubject("bar", 8), new TestSubject("foo", 7), false],
            [ new TestSubject(null, 8), new TestSubject("foo", 7), false],
            [ new TestSubject("bar", null), new TestSubject("foo", 7), false],
            [ new TestSubject(null, null), new TestSubject(null, null), true],
            [ new TestSubject(null, 7), new TestSubject(null, 7), true],
            [ new TestSubject("foo", null), new TestSubject("foo", null), true],
            [ null, new TestSubject("foo", 7), false],
            [ new TestSubject("foo", 7), null, false],
            [ null, null, false],
        ];
    }
    
    [Theory]
    [MemberData(nameof(EqualityTestData))]
    public void ThatGeneratedEqualsTreatEqualTestsEquality(TestSubject? a, TestSubject? b, bool expectEqual)
    {
        // Expect their equality to be correct
        if (a != null)
        {
            a.Equals(b).Should().Be(expectEqual);
        }
        
        // And in reverse
        if (b != null)
        {
            b.Equals(a).Should().Be(expectEqual);
        }
    }
    
    public static IEnumerable<object[]> HashCodeTestData()
    {
        return
        [
            [ new TestSubject("foo", 7), new TestSubject("foo", 7)],
            [ new TestSubject("bar", 8), new TestSubject("bar", 8)],
            [ new TestSubject(null, null), new TestSubject(null, null)],
            [ new TestSubject(null, 7), new TestSubject(null, 7)],
            [ new TestSubject("foo", null), new TestSubject("foo", null)],
        ];
    }
    
    [Theory]
    [MemberData(nameof(HashCodeTestData))]
    public void ThatGeneratedGetHashCodeProducesConsistentResults(TestSubject a, TestSubject b)
    {
        a.GetHashCode().Should().Be(b.GetHashCode());
    }
}

[EqualsAndHashCode]
public partial class TestSubject
{
    public string? String;
    public int? Number;
    public TestSubject(string? str, int? number)
    {
        String = str;
        Number = number;
    }
}