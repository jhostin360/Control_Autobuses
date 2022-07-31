using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Asignar
    {

        private int _id_asignar;
        private int _id_chofer;
        private int _id_autobuses;
        private int _id_ruta;

        public int Id_asignar { get => _id_asignar; set => _id_asignar = value; }
        public int Id_chofer { get => _id_chofer; set => _id_chofer = value; }
        public int Id_autobuses { get => _id_autobuses; set => _id_autobuses = value; }
        public int Id_ruta { get => _id_ruta; set => _id_ruta = value; }
    }
}
