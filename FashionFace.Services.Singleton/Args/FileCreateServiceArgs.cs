using System.IO;

namespace FashionFace.Services.Singleton.Args;

public sealed record FileCreateServiceArgs(
    Stream FileStream,
    string FilePath
);