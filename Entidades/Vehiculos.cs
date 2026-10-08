using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Vehiculos
    {
        private int idVehiculo;
        private string marca;
        private string capacidad;
        private string modelo;
        private string kilometraje;
        private string estado;
        private int disponibilidad;

        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Capacidad { get => capacidad; set => capacidad = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Kilometraje { get => kilometraje; set => kilometraje = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
    }
}
