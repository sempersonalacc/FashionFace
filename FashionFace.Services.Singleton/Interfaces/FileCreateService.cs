using System.Threading.Tasks;

using FashionFace.Services.Singleton.Args;

namespace FashionFace.Services.Singleton.Interfaces;

public interface IFileCreateService
{
    Task Create(
        FileCreateServiceArgs args
    );
}