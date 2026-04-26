using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using VitrinaCarros_AppWeb.Models;

namespace VitrinaCarros_AppWeb.Models.Databases
{
    public class SQLHelpers
    {

        public string Sql_insertarVehiculo(Cls_vehiculo objv) => "insert into tbl_vehiculo " +
                "values ('" + objv.getModelo() + "', '" + objv.getFecha() + "', " + objv.getPrecio() + ")";

        
      
        public string Sql_consultarVehiculos() => "select * from tbl_vehiculo;";


    }
}