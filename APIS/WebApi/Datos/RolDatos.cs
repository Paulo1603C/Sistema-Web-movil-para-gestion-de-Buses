using Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public static class RolDatos
    {
		public static RolEntidad crearRol(RolEntidad rolEntidad)
		{
            try
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=MovilmitogBuses.mssql.somee.com;Persist Security Info=False; Initial Catalog=MovilmitogBuses; User ID=DIEGOT_SQLLogin_1;Password=a7yml197en ");
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection= sqlConnection;
                cmd.CommandType= CommandType.Text;
                cmd.CommandText = @"INSERT INTO ROL(Nombre, Descripcion,Estado) values(@nombre,@descripcion,'ACT')
                                    SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("@nombre", rolEntidad.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", rolEntidad.Descripcion);
                int id=Convert.ToInt32(cmd.ExecuteScalar());
                rolEntidad.Id = id;
                sqlConnection.Close();
                return rolEntidad;


            }
            catch (global::System.Exception)
            {

                throw;
            }

        }


        
    }
}
