using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Chofer
    {

        private int _id_chofer;
        private String _nombre_chofer;
        private String _apellido_chofer;
        private String _fecha_chofer;
        private String _cedula_chofer;
        private bool _disponible;

        public int Id_chofer { get => _id_chofer; set => _id_chofer = value; }
        public string Nombre_chofer { get => _nombre_chofer; set => _nombre_chofer = value; }
        public string Apellido_chofer { get => _apellido_chofer; set => _apellido_chofer = value; }
        public string Fecha_chofer { get => _fecha_chofer; set => _fecha_chofer = value; }
        public string Cedula_chofer { get => _cedula_chofer; set => _cedula_chofer = value; }
        public bool Disponible { get => _disponible; set => _disponible = value; }
    }
}
