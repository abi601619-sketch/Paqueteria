using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Ruta
    {
        private int idRuta;
        private string nombre;
        private string estado;
        private string zona;
        private string puntoOrigen;
        private string destinoA;
        private string puntoFinal;

        public int IdRuta { get => idRuta; set => idRuta = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Zona { get => zona; set => zona = value; }
        public string PuntoOrigen { get => puntoOrigen; set => puntoOrigen = value; }
        public string DestinoA { get => destinoA; set => destinoA = value; }
        public string PuntoFinal { get => puntoFinal; set => puntoFinal = value; }
    }
}
