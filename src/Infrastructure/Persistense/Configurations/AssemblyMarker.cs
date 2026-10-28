using System.Reflection;

namespace LinguaCommunity.Infrastructure.Persistense.Configurations;

public abstract class AssemblyMarker
{
    public static readonly Assembly Assembly = typeof(AssemblyMarker).Assembly;
}
