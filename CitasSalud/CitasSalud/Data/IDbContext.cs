using System.Data;

namespace CitasSalud.Data
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }
}
