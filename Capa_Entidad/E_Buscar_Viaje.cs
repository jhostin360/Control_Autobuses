using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Buscar_Viaje
    {

        private int _id_Viaje;
        private string _chofer_Viaje;
        private string _autobuses_Viaje;
        private string _ruta_Viaje;

        public int Id_Viaje { get => _id_Viaje; set => _id_Viaje = value; }
        public string Chofer_Viaje { get => _chofer_Viaje; set => _chofer_Viaje = value; }
        public string Autobuses_Viaje { get => _autobuses_Viaje; set => _autobuses_Viaje = value; }
        public string Ruta_Viaje { get => _ruta_Viaje; set => _ruta_Viaje = value; }
    }
}
