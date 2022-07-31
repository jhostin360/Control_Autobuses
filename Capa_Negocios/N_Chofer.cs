using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocios
{
    public class N_Chofer
    {

        D_Chofer objDato = new D_Chofer();
        public List<E_Chofer> ListarAgenda(string buscar)
        {

            return objDato.ListarAgenda(buscar);

        }

        public void Insertar(E_Chofer chofer)
        {

            objDato.Insertar(chofer);

        }

        public void Editar(E_Chofer chofer)
        {

            objDato.Editar(chofer);

        }

    }
}
