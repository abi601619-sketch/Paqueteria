using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Conductor
    {
        private int idUsuario;
        private string dui;
        private string nombre;
        private string apellido;
        private string correo;
        private string contrasena;
        private byte[] fotoPerfil;
        private string zonaEncargada;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public byte[] FotoPerfil { get => fotoPerfil; set => fotoPerfil = value; }
        public string ZonaEncargada { get => zonaEncargada; set => zonaEncargada = value; }
    }
}
