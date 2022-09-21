using Microsoft.AspNetCore.Mvc;
using webapi.Models;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareasServices _tarea;
    public TareaController(ITareasServices _tarea)
    {
        this._tarea = _tarea;
    }    

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tarea.Get());
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        _tarea.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Tarea tarea)
    {
        _tarea.Update(id,tarea);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _tarea.Delete(id);
        return Ok();
    }
}