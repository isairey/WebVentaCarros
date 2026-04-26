using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VitrinaCarros_AppWeb.Models;

namespace VitrinaCarros_AppWeb.Controllers
{
    
    public class VehiculoController : Controller
    {

        Cls_vehiculo objv = new Cls_vehiculo();

        Cls_marca objM = new Cls_marca();

        public ActionResult formRegistroVehiculos()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult crearVehiculos()
        {

            //objv.Modelo = Convert.ToString(Request["txtModelo"]);
            //objv.Precio = Convert.ToDouble(Request["precio"]);
            //objv.Anio = Convert.ToInt32(Request["txtAnio"]);

            objv.setModelo(Convert.ToString(Request["txtModelo"]));

            //DateTime fecha = DateTime.Today;

            objv.setFecha(Convert.ToString(Request["dtmFecha"]));

            objv.setPrecio(Convert.ToDouble(Request["txtPrecio"]));

            //String ruta = Convert.ToString(Request["txtRuta"]);
            // byte[] data = System.IO.File.ReadAllBytes(ruta);
            //objv.Ruta = null;

            if (objv.DarAltaVehiculo() != 0)
            {
                List<Cls_vehiculo> objListaVehiculos = objv.ListarVehiculos();
                ViewData["listaVehiculos"] = objListaVehiculos;
                ViewBag.Mensaje = "Datos Guardos Correctamente";
                return View("mostrarAllVehiculos");
            }
            else
            {
                return View("error");
            }

            
        }

        public ActionResult mostrarAllVehiculos()
        {
            List<Cls_vehiculo> objListaVehiculos = objv.ListarVehiculos();
            ViewData["listaVehiculos"] = objListaVehiculos;
            return View();
        }

        [HttpGet]
        public ActionResult ConsultarVehiculosXMarca()
        {
            string marca = Convert.ToString(Request["txtBusMarca"]);
            List<Cls_vehiculo> objListaVehiculosXMarca = objv.listaBsVehiculosXMarca(marca);
            ViewData["listaVehiculosXMarca"] = objListaVehiculosXMarca;
            return View("mostrarVehiculosXMarca");
        }

        [HttpPost]
        public ActionResult MostrarVehiculos()
        {
            //Septiamos los datos nuestra propiedades del objeto (vehiculo)
            objv.setIdVehiculo(Convert.ToInt32(Request["id_vehiculo"]));
            objv.setModelo(Convert.ToString(Request["modelo"]));
            objv.setAnio(Convert.ToInt32(Request["anio"]));
            objv.setPrecio(Convert.ToDouble(Request["precio"]));

            ViewData["ModelVehiculo"] = objv;

            return View("form_mostrarVehiculo");
        }

        public ActionResult formRegistroMarca() 
        {
            List<Cls_vehiculo> objListaVehiculosPorModelo = objv.ListadoVehiculosXmodelo();
            ViewData["listaVehiculosPorModelo"] = objListaVehiculosPorModelo; 
            return View();
        }

      
        [HttpPost]
        public ActionResult crearMarcaVehiculo()
        {
            objM.IdVehiculo = Convert.ToInt32(Request["cbModelo"]);
            objM.Nombre = Convert.ToString(Request["txtNombre"]);


            if (objM.GuadarMarca() == 0)
            {
                return View("Error_Msg1");
            }
            else
            {
                List<Cls_marca> objListaMarcas = objM.ListarMarcas();
                ViewData["listaMarcas"] = objListaMarcas;
                ViewBag.Mensaje = "Datos Guardos Correctamente";
                return View("MostrarMarcas");
            }

           

        }

        public ActionResult MostrarMarcas() 
        {
            List<Cls_marca> objListaMarcas = objM.ListarMarcas();
            ViewData["listaMarcas"] = objListaMarcas;
            return View();
        }
    }
}