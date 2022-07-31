using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Ruta
    {

        private int _id_ruta;
        private String _nombre_ruta;
        private bool _disponible;

        public int Id_ruta { get => _id_ruta; set => _id_ruta = value; }
        public string Nombre_ruta { get => _nombre_ruta; set => _nombre_ruta = value; }
        public bool Disponible { get => _disponible; set => _disponible = value; }
    }
}
