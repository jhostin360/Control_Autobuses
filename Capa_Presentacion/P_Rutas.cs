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
    public partial class P_Rutas : Form
    {
        private String idruta;
        private bool editar = false;

        E_Ruta objEntidad = new E_Ruta();
        N_Rutas objNegocio = new N_Rutas();

        public P_Rutas()
        {
            InitializeComponent();
        }

        //metodos
        #region metodos
        public void MostrarTabla(String buscar)
        {

            N_Rutas objNegocio = new N_Rutas();
            DGV.DataSource = objNegocio.ListarAgenda(buscar);

        }
        public void Limpiar()
        {

            editar = false;
            TxtRuta.Text = "";
        }
        #endregion

        //eventos
        #region eventos
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objEntidad.Nombre_ruta = TxtRuta.Text;

                    objNegocio.Insertar(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    MostrarTabla("");
                    Limpiar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo guardar");
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (editar == true)
            {
                try
                {
                    objEntidad.Id_ruta = Convert.ToInt32(idruta);
                    objEntidad.Nombre_ruta = TxtRuta.Text;

                    objNegocio.Editar(objEntidad);

                    MessageBox.Show("Se edito el registro");
                    MostrarTabla("");
                    Limpiar();
                    editar = false;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo editar");
                }
            }
        }

        private void BtnSelecRuta_Click(object sender, EventArgs e)
        {
            editar = true;
            if (DGV.SelectedRows.Count > 0)
            {
                idruta = DGV.CurrentRow.Cells[0].Value.ToString();
                TxtRuta.Text = DGV.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione una fila si desea editarla");
            }
        }

        private void TxtBuscarRuta_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(TxtBuscarRuta.Text);
        }

        private void P_Rutas_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnChofer_Click(object sender, EventArgs e)
        {
            P_Chofer chofer = new P_Chofer();
            chofer.Show();
        }

        private void BtnAutobuses_Click(object sender, EventArgs e)
        {
            P_Autobuses bus = new P_Autobuses();
            bus.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //mover form con panel *Experimental*
        #region experimental
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
