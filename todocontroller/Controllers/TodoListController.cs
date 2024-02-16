using Microsoft.AspNetCore.Mvc;
using todoclass;
using todocontroller.data;

namespace todocontroller.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    readonly DataContext _db;

    public TodoListController(DataContext db) => _db = db;

    [HttpGet]
    public List<ToDoItem> ReturnAll()
    {
        var items = _db.ToDoItems.Where(item => item.CompletedDate == null).ToList();
        return items;
    }

    [HttpGet("{id}")]
    public ToDoItem ReturnById(int id)
    {
        var item = _db.ToDoItems.Find(id);
        return item;
    }

    [HttpPost]
    public ToDoItem CreateItem(ToDoItem item)
    {
        _db.ToDoItems.Add(item);
        _db.SaveChanges();
        return item;
    }

    [HttpPost("{id}")]
    public IActionResult UpdateById(int id)
    {
        var item = _db.ToDoItems.Find(id);
        if(item is null)
            return NotFound();
        item.CompletedDate = DateTime.Now;
        _db.SaveChanges();
        return Ok();
    }
}
