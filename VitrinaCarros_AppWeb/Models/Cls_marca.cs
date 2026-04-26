using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VitrinaCarros_AppWeb.Models.Databases;

namespace VitrinaCarros_AppWeb.Models
{
    public class Cls_marca
    {
        cls_ConexionDB db = new cls_ConexionDB();

        
        #region "Constructores"

            public Cls_marca() { }

            public Cls_marca(int id_vehiculo, string nombre) { }

        #endregion

        #region "Atributos/Propiedades"
            [Key]
            public int IdVehiculo { get; set; } 
            public string Nombre { get; set; }

        #endregion

        #region "Metodos Publicos"

            public int GuadarMarca()
            {
                try
                {
                    db.Conectar(); 
                }
                catch(Exception e)
                {
                    throw e;
                }

                string query = "insert into tbl_marca values (" + IdVehiculo + ", ' " + Nombre + "')";

                int fila = db.operaracion(query);

                return fila;
            }

        public List<Cls_marca> ListarMarcas()
        {
            try
            {
                db.Conectar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

            List<Cls_marca> datos = new List<Cls_marca>();

            string query = "select * from tbl_marca";

            SqlDataReader d = db.Consulta(query);


            while (d.Read())
            {
                datos.Add(new Cls_marca()
                {
                    IdVehiculo = Convert.ToInt32(d["int_id_vehiculo"]),
                    Nombre = Convert.ToString(d["nombre"]),

                });
            }

            return datos;
        }
        #endregion


    }
}