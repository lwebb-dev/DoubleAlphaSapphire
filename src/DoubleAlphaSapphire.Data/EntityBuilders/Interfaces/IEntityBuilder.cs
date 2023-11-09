using Microsoft.EntityFrameworkCore;

namespace DoubleAlphaSapphire.Data.EntityBuilders
{
    internal interface IEntityBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
