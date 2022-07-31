using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocios
{
    public class N_Asignar
    {

        D_Asignar objDato = new D_Asignar();
        public List<E_Buscar_Viaje> Listar(string buscar)
        {

            return objDato.Listar(buscar);


        }

        public void Insertar(E_Asignar asin)
        {

            objDato.Insertar(asin);

        }

    }
}
