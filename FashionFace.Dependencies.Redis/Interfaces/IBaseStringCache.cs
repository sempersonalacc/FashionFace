namespace FashionFace.Dependencies.Redis.Interfaces;

public interface IBaseStringCache<TEntity> : IBaseCache<string, TEntity>
    where TEntity : class { }