namespace Task4Test;

public class MissingMembersTest
{
    [Fact]
    public void MissingMembers_EmptyArrayOfMissingMembers()
    {
        var data = new[] {1, 2, 3};

        var result = Task4.ArrayProblem.MissingElements(data);
        
        Assert.Equal(result, Array.Empty<int>());
    }
    
    [Fact]
    public void MissingMembers_EmptyArrayOfMissingMembersDueToInputArrayLengthLessThan2()
    {
        var data = new[] {1};

        var result = Task4.ArrayProblem.MissingElements(data);
        
        Assert.Equal(result, Array.Empty<int>());
    }

    [Fact]
    public void MissingMembers_OneMissingMemberRange()
    {
        var data = new[] {-2, 6};

        var result = Task4.ArrayProblem.MissingElements(data);
        
        Assert.Equal(result, new[]{-1, 0, 1, 2, 3, 4, 5});
    }
    
    [Fact]
    public void MissingMembers_SingleElementIsMissing()
    {
        var data = new[] {-2, 0};

        var result = Task4.ArrayProblem.MissingElements(data);
        
        Assert.Equal(result, new[]{-1});
    }
    
    [Fact]
    public void MissingMembers_ALotOfMissingMembersRanges()
    {
        var data = new[] {-2, 0, 3, 7};

        var result = Task4.ArrayProblem.MissingElements(data);
        
        Assert.Equal(result, new[]{-1, 1, 2, 4, 5, 6});
    }
    
    [Fact]
    public void MissingMembers_InputArrayIsNull()
    {
        int[] data = null;

        var result = Task4.ArrayProblem.MissingElements(data);
        
        Assert.Equal(result, Array.Empty<int>());
    }
}