using System;

namespace FashionFace.Services.Singleton.Interfaces;

public interface IFilePathService
{
    string GetRelativePath(
        Guid fileId
    );
}