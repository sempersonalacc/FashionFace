using System.Threading.Tasks;

using FashionFace.Facades.Domains.Synchronization.Args;

namespace FashionFace.Facades.Domains.Synchronization.Interfaces;

public interface IAppearanceTraitsDimensionsSynchronizationFacade
{
    Task SynchronizeAsync(
        AppearanceTraitsDimensionsSynchronizationArgs args
    );
}