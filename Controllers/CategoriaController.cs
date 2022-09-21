using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaServices _categoria;
    public CategoriaController(ICategoriaServices _categoria)
    {
        this._categoria = _categoria;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoria.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria model)
    {
        if(model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        _categoria.Save(model);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria model)
    {
        _categoria.Update(id,model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoria.Delete(id);
        return Ok();
    }

}


