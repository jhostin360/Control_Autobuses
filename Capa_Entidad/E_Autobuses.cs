using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Autobuses
    {

        private int _id_Auto;
        private String _marca;
        private String _modelo;
        private String _placa;
        private String _color;
        private String _año;
        private bool _disponible;

        public int Id_Auto { get => _id_Auto; set => _id_Auto = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public string Placa { get => _placa; set => _placa = value; }
        public string Color { get => _color; set => _color = value; }
        public string Año { get => _año; set => _año = value; }
        public bool Disponible { get => _disponible; set => _disponible = value; }
    }
}
