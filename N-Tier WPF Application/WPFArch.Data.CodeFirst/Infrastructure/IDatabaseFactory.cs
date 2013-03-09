using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.Infrastructure
{
    public interface IDatabaseFactory
    {
        WPFRealWorldContext Get();
    }
}
