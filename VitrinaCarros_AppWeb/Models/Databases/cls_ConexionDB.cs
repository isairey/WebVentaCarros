using System;
using System.Data.SqlClient;

namespace VitrinaCarros_AppWeb.Models.Databases
{
    public class cls_ConexionDB
    {
        SqlConnection conn = new SqlConnection("Data Source = DANIELLE; " +
                "Initial Catalog = BDVitrinaCarros; " +
                "User Id = sa; " +
                "password = sA123456");
     
        #region "Metodos Publicos" 

        //Metodo Conectar. Este metodo Retorna un dato tipo sqlConnection
        //Instaciamos la cadena de conexion pasando unos parametros y Abrimos la conexion
        public SqlConnection Conectar()
        {
        
            try
                {
                    conn.Open();
                    Console.WriteLine("Conexion Exitosa");
                    return conn;
                }
                catch (SqlException)
                {
                    return null;
                }
            
            }

            //Metodo para cerrar al conexion que recibe como paremetro un objeto de tipo SqlConnection
            public void CerrarConexion()
            {
                try
                {
                    conn.Close();//Con el objeto referenciado. Cerramos la conexion.
                }
                catch (SqlException)
                {
                    throw;
                }
            }

            //Metodo para ejecutar de las instrucciones delete, insert, update
            //las instrucciones SQL que retorna una cantidad de filas afectadas.
            public int operaracion(string conSQL)
            {
                int num = 0;

                try
                {
                    //variable comando tipo SqlCommand le pasamos el Query(puede ser insert, delete o update) 
                    //Junto con el objeto conectar.
                    SqlCommand comando = new SqlCommand(conSQL, conn);
                    num = comando.ExecuteNonQuery();//Ejecutamos el comando
                    return num;//Retorna el numero de filas afectadas.
                }
                catch (SqlException)
                {
                    return num;
                    throw;
                }
                
            }

            public SqlDataReader Consulta(string conSQL)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(conSQL, conn);
                    SqlDataReader datos = comando.ExecuteReader();
                    return datos;
                }
                catch (SqlException e)
                {
                    return null;
                    throw e;
                }
                
            }

        #endregion
    }
}