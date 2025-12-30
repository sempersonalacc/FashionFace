using System;

namespace FashionFace.Repositories.Context.Interfaces;

public interface IWithCreatedAt
{
    DateTime CreatedAt { get; }
}