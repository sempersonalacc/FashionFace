using System;

namespace FashionFace.Repositories.Context.Interfaces;

public interface IWithProcessingStartedAt
{
    DateTime? ProcessingStartedAt { get; set; }
}