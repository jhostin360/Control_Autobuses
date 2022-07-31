using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocios;

namespace Capa_Presentacion
{
    public partial class P_Asignar : Form
    {
        //variables e instancias
        #region variables e instancias
        private String idasignar;
        private bool editar = false;

        E_Asignar objEntidad = new E_Asignar();
        N_Asignar objNegocio = new N_Asignar();
        public N_Autobuses objNegocios = new N_Autobuses();
        public N_Chofer objNegocios1 = new N_Chofer();
        public N_Rutas objNegocios2 = new N_Rutas();
        #endregion

        public P_Asignar()
        {
            InitializeComponent();
        }

        //metodos
        #region metodos
        public void MostrarTabla(String buscar)
        {

            N_Asignar objNegocio = new N_Asignar();
            DGV.DataSource = objNegocio.Listar(buscar);

        }

        private void Rellenar_Autobuses() {

            List<E_Autobuses> relleno = objNegocios.ListarAgenda("");

            foreach (E_Autobuses item in relleno)
            {
                if (item.Disponible)
                {
                    CmbAutobuses.Items.Add($"{item.Marca} {item.Placa}");
                }
                
            }

        }

        private void Rellenar_Chofer() {

            List<E_Chofer> relleno = objNegocios1.ListarAgenda("");

            foreach (E_Chofer item in relleno)
            {
                if (item.Disponible)
                {
                    CmbChofer.Items.Add($"{item.Nombre_chofer} {item.Apellido_chofer}");
                }
                
            }

        }

        private void Rellenar_Ruta()
        {

            List<E_Ruta> relleno = objNegocios2.ListarAgenda("");

            foreach (E_Ruta item in relleno)
            {
                if (item.Disponible)
                {
                    CmbRutas.Items.Add($"{item.Nombre_ruta}");
                }
                
            }

        }

        private List<int> Buscar_Propiedades(string nombre, string autobus, string ruta) {
        
            List<E_Chofer> chofers = objNegocios1.ListarAgenda("");

            List<E_Autobuses> autobuses = objNegocios.ListarAgenda("");

            List<E_Ruta> rutas = objNegocios2.ListarAgenda("");

            List<int> retorno = new List<int>();


            foreach (E_Chofer item in chofers)
            {
                string nombre_completo = item.Nombre_chofer + " " + item.Apellido_chofer;

                if (nombre_completo == nombre)
                {
                    retorno.Add(item.Id_chofer);
                }
            }

            foreach (E_Autobuses item in autobuses)
            {
                string auto_completo = item.Marca + " " + item.Placa;

                if (auto_completo == autobus)
                {
                    retorno.Add(item.Id_Auto);
                }
            }

            foreach (E_Ruta item in rutas)
            {

                if (item.Nombre_ruta == ruta)
                {
                    retorno.Add(item.Id_ruta);
                }
            }

            return retorno;
        }
        #endregion

        //eventos
        #region eventos
        private void P_Asignar_Load(object sender, EventArgs e)
        {
            Rellenar_Autobuses();
            Rellenar_Chofer();
            Rellenar_Ruta();
            MostrarTabla("");
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    List<int> ids = Buscar_Propiedades(CmbChofer.Text, CmbAutobuses.Text, CmbRutas.Text);
                    objEntidad.Id_chofer = ids[0];
                    objEntidad.Id_autobuses = ids[1];
                    objEntidad.Id_ruta = ids[2];

                    objNegocio.Insertar(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    MostrarTabla("");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo guardar");
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRutas_Click(object sender, EventArgs e)
        {
            P_Rutas rutas = new P_Rutas();
            rutas.Show();
        }

        private void BtnAutobuses_Click(object sender, EventArgs e)
        {
            P_Autobuses bus = new P_Autobuses();
            bus.Show();
        }

        private void TxtBuscarAsignacion_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(TxtBuscarAsignacion.Text);
        }
        #endregion

        //mover form con panel *experimental*
        #region experimento
        bool move = false;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.Location = Cursor.Position;
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        #endregion
    }
}
