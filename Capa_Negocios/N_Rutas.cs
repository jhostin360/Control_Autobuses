using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocios
{
    public class N_Rutas
    {

        D_Ruta objDato = new D_Ruta();
        public List<E_Ruta> ListarAgenda(string buscar)
        {

            return objDato.ListarAgenda(buscar);

        }

        public void Insertar(E_Ruta ruta)
        {

            objDato.Insertar(ruta);

        }

        public void Editar(E_Ruta ruta)
        {

            objDato.Editar(ruta);

        }

    }
}
