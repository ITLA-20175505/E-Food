using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace E_Food.Models
{
    public class MantenimientoTipoAB
    {
        SqlCommand cmd = new SqlCommand(
        "Ten Most Expensive Products", Conexion.getConnection());

        // 2. set the command object so it knows
        // to execute a stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        
    }
}