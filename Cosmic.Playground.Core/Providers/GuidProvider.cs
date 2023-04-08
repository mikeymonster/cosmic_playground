using Cosmic.Playground.Core.Interfaces;

namespace Cosmic.Playground.Core.Providers;
public class GuidProvider : IGuidProvider
{
    public Guid NewGuid() => Guid.NewGuid();
}
