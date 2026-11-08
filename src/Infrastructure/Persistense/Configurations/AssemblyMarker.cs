using System.Reflection;

namespace LinguaCommunity.Infrastructure.Persistense.Configurations;

public abstract class AssemblyMarker
{
    public static readonly Assembly s_assembly = typeof(AssemblyMarker).Assembly;
}
