using System.IO;

namespace FashionFace.Dependencies.SkiaSharp.Interfaces;

public interface IImageResizeService
{
    MemoryStream Optimize(
        Stream inputStream
    );
}