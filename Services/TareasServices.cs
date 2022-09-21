
using webapi;
using webapi.Models;

public interface ITareasServices
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id,Tarea tarea);
    Task Delete(Guid id);
}
public class TareasServices : ITareasServices
{
    TareasContext context;
    public TareasServices(TareasContext context)
    {
        this.context = context;
    }

    public async Task Delete(Guid id)
    {
        var tareaActual = context.Tareas.Find(id);
        if(tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);
        
        if(tareaActual!=null)
        {
            tareaActual.Categoria = tarea.Categoria;
            tareaActual.CategoriaId = tarea.CategoriaId;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.FechaCreacion = DateTime.Now;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.Titulo = tarea.Titulo;

            await context.SaveChangesAsync();
        }
    }
}