using System;

namespace FashionFace.Facades.Domains.Synchronization.Args;

public sealed record AppearanceTraitsDimensionsSynchronizationArgs(
    Guid ProfileId
);