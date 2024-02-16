using todoclass;

namespace todounit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var item = new ToDoItem();
        item.ID = 1;
        Assert.Equal(1, item.ID);
    }

    [Fact]
    public void Test2()
    {
        var item = new ToDoItem();
        item.Description = "hello";
        Assert.Equal("hello", item.Description);
    }

    [Fact]
    public void Test3()
    {
        var item = new ToDoItem();
        item.DueDate = DateTime.MaxValue;
        Assert.Equal(DateTime.MaxValue, item.DueDate);
    }

    [Fact]
    public void Test4()
    {
        var item = new ToDoItem();
        item.CompletedDate = DateTime.MinValue;
        Assert.Equal(DateTime.MinValue, item.CompletedDate);
    }
}