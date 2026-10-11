using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class ListaVehiculos
    {
        private int idListaVehiculos;
        private int idVehiculo;
        private int idUsuario;

        public int IdListaVehiculos { get => idListaVehiculos; set => idListaVehiculos = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

       

       
    }
}
