using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VitrinaCarros_AppWeb.Models.Databases;
using System.Data.SqlClient;

namespace VitrinaCarros_AppWeb.Models
{
    public class Cls_vehiculo
    {

        cls_ConexionDB db = new cls_ConexionDB();
       
        SQLHelpers sql = new SQLHelpers();

        #region "Atributos"
            private int idVehiculo;
            private string modelo;
            private string fecha;
            private int anio;
            private double precio;
        private Cls_marca marca;
        #endregion

        #region "Propiedades"
        [Key]
            public int IdVehiculo { get; set; }

            public string Modelo { get; set; }
            
            public int Anio { get; set; }

            public double Precio { get; set; }

            //public byte[] Ruta { get; set; }
        #endregion

        #region "Contructores"

            public Cls_vehiculo()
            { }

            public Cls_vehiculo(string modelo, int anio, double precio)
            {
                this.Modelo =  modelo;
                this.Anio = anio;
                this.Precio = precio;
            }
        #endregion


        #region "Metodos Publicos"

        public void setIdVehiculo(int idVehiculo)
        {
            this.idVehiculo = idVehiculo;
        }

        public int getIdVehiculo() => this.idVehiculo;

        public void setModelo(string modelo)
        {
            this.modelo = modelo;
        }

        public string getModelo() => this.modelo;

        public int getAnio() => this.anio;

        public void setAnio(int anio)
        {
            this.anio = anio;
        }

        public void setFecha(string fecha)
        {
            this.fecha = fecha; 
        }

        public string getFecha() => this.fecha; 


        public void setPrecio(double precio)
        {
            this.precio = precio;
        }

        public double getPrecio() => this.precio;


        public void setMarca(Cls_marca marca)
        {
            this.marca = marca;
        }

        public Cls_marca getMarca() => this.marca;

        //Metodo para Insertar nuevo registro ala BD
        public int DarAltaVehiculo()
        {
            try
            {
                db.Conectar();
            }
            catch
            {
                throw;
            }

            string query = "insert into tbl_vehiculo " +
                "values ('"+getModelo()+"', '"+getFecha()+"', "+getPrecio()+")";

            int fila = db.operaracion(query);
            
            return fila;
        }
         
        //Metodo que lista todos los vehiculos
        public List<Cls_vehiculo> ListarVehiculos()
        {
            try
            {
                db.Conectar();
            }
            catch (Exception e)
            {              
                throw e;
            }
                    
            List<Cls_vehiculo> datosVehiculos = new List<Cls_vehiculo>();

            string query = "select  int_id_vehiculo, modelo, year(fecha) as anio, precio from tbl_vehiculo";


            SqlDataReader d = db.Consulta(query);

   
            while (d.Read())
            {
                datosVehiculos.Add(new Cls_vehiculo()
                {
                    idVehiculo = Convert.ToInt32(d["int_id_vehiculo"]),
                    modelo = Convert.ToString(d["modelo"]),
                    anio = Convert.ToInt32(d["anio"]),
                    precio = Convert.ToDouble(d["precio"]),
                 
                });
            }

            return datosVehiculos;
        }


        //Metodo que permite buscar por marca en una lista de vehiculoXMarca,
        //Tenemos una consulta cruzada entre dos tablas con un join, que visualiza la informacion que es ingresada.
        public List<Cls_vehiculo> listaBsVehiculosXMarca(string bscMarca)
        {
            try
            {
                db.Conectar();
            }
            catch (Exception e)
            {
                throw e;
            }


            List<Cls_vehiculo> lista = new List<Cls_vehiculo>();

            string query = "select v.int_id_vehiculo as id_vehiculo, v.modelo,year(v.fecha) as anio," +
                " v.precio as precio, m.nombre as marca " +
                "from tbl_vehiculo v inner join tbl_marca m " +
                "on m.int_id_vehiculo = v.int_id_vehiculo " +
                "where m.nombre = '"+bscMarca+"'";

            SqlDataReader leer = db.Consulta(query);


            while (leer.Read())
            {
                Cls_vehiculo objV = new Cls_vehiculo();
                objV.setIdVehiculo(Convert.ToInt32(leer["id_vehiculo"]));
                objV.setModelo(Convert.ToString(leer["modelo"]));
                objV.setAnio(Convert.ToInt32(leer["anio"]));
                objV.setPrecio(Convert.ToInt32(leer["precio"]));

                marca = new Cls_marca();
                marca.Nombre = Convert.ToString(leer["marca"]);

                objV.setMarca(marca);

                lista.Add(objV);

            }

            return lista;

        }

        public List<Cls_vehiculo> ListarVehiculosXMarca()
        {
            try
            {
                db.Conectar();
            }
            catch (Exception e)
            {
                throw e;
            }

            List<Cls_vehiculo> lista = new List<Cls_vehiculo>();

            string query = "select v.int_id_vehiculo as id_vehiculo, v.modelo as modelo,year(v.fecha) as anio, " +
                "v.precio as precio, m.nombre as marca from tbl_vehiculo v innerjoin tbl_marca m " +
                "on m.int_id_vehiculo = v.int_id_vehiculo " +
                "order by m.nombre DESC";


            SqlDataReader leer = db.Consulta(query);


            while (leer.Read())
            {
                Cls_vehiculo objV = new Cls_vehiculo();
                objV.setIdVehiculo(Convert.ToInt32(leer["id_vehiculo"]));
                objV.setModelo(Convert.ToString(leer["modelo"]));
                objV.setAnio(Convert.ToInt32(leer["anio"]));
                objV.setPrecio(Convert.ToInt32(leer["precio"]));

                marca = new Cls_marca();
                marca.Nombre = Convert.ToString(leer["marca"]);

                objV.setMarca(marca);

                lista.Add(objV);

            }

            return lista;
        }

        public List<Cls_vehiculo> ListadoVehiculosXmodelo()
        {

            try
            {
                db.Conectar();
            }
            catch (Exception e)
            {
                throw e;
            }

            List<Cls_vehiculo> datos = new List<Cls_vehiculo>();

            string query = "select int_id_vehiculo, modelo from tbl_vehiculo ";

            SqlDataReader d = db.Consulta(query);

            while (d.Read())
            {
                datos.Add(new Cls_vehiculo()
                {
                    idVehiculo = Convert.ToInt32(d["int_id_vehiculo"]),
                    modelo = Convert.ToString(d["modelo"]),

                });
            }

            return datos;
        }

        #endregion



    }
}