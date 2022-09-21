using webapi;
using webapi.Models;
public interface ICategoriaServices
{
    IEnumerable<Categoria> Get();
    Task Delete(Guid id);
    Task Update(Guid id,Categoria categoria);
    Task Save(Categoria categoria);        
}
public class CategoriaServices : ICategoriaServices
{
    TareasContext context;
    public CategoriaServices(TareasContext context)
    {
        this.context = context;
    }
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }
    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id,Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual!=null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
            
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual!=null)
        {
            context.Remove(categoriaActual);           
            await context.SaveChangesAsync();
        }
    }
}