using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocios
{
    public class N_Autobuses
    {

        D_Autobuses objDato = new D_Autobuses();
        public List<E_Autobuses> ListarAgenda(string buscar)
        {

            return objDato.ListarAgenda(buscar);

        }

        public void Insertar(E_Autobuses bus)
        {

            objDato.Insertar(bus);

        }

        public void Editar(E_Autobuses bus)
        {

            objDato.Editar(bus);

        }

    }
}
