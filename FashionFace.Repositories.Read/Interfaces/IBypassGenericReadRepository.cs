using System.Linq;

namespace FashionFace.Repositories.Read.Interfaces;

public interface IBypassGenericReadRepository
{
    IQueryable<T> GetCollection<T>()
        where T : class;
}