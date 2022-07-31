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
    public partial class P_Autobuses : Form
    {

        private String idauto;
        private bool editar = false;

        E_Autobuses objEntidad = new E_Autobuses();
        N_Autobuses objNegocio = new N_Autobuses();

        public P_Autobuses()
        {
            InitializeComponent();
        }

        //metodos
        #region metodos
        public void MostrarTabla(String buscar)
        {

            N_Autobuses objNegocio = new N_Autobuses();
            DGV.DataSource = objNegocio.ListarAgenda(buscar);

        }
        public void Limpiar()
        {

            editar = false;
            TxtMarca.Text = "";
            TxtModelo.Text = "";
            TxtPlaca.Text = "";
            TxtColor.Text = "";
            TxtAño.Text = "";
        }
        #endregion

        //eventos
        #region Eventos 
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objEntidad.Marca = TxtMarca.Text;
                    objEntidad.Modelo = TxtModelo.Text;
                    objEntidad.Placa = TxtPlaca.Text;
                    objEntidad.Color = TxtColor.Text;
                    objEntidad.Año = TxtAño.Text;

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
                    objEntidad.Id_Auto = Convert.ToInt32(idauto);
                    objEntidad.Marca = TxtMarca.Text;
                    objEntidad.Modelo = TxtModelo.Text;
                    objEntidad.Placa = TxtPlaca.Text;
                    objEntidad.Color = TxtColor.Text;
                    objEntidad.Año = TxtAño.Text;

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

        private void P_Autobuses_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
        }

        private void BtnSelecAuto_Click(object sender, EventArgs e)
        {
            editar = true;
            if (DGV.SelectedRows.Count > 0)
            {
                idauto = DGV.CurrentRow.Cells[0].Value.ToString();
                TxtMarca.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                TxtModelo.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                TxtPlaca.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                TxtColor.Text = DGV.CurrentRow.Cells[4].Value.ToString();
                TxtAño.Text = DGV.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione una fila si desea editarla");
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void TxtBuscarAuto_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(TxtBuscarAuto.Text);
        }

        private void BtnChofer_Click(object sender, EventArgs e)
        {
            P_Chofer chofer = new P_Chofer();
            chofer.Show();
        }

        private void BtnRutas_Click(object sender, EventArgs e)
        {
            P_Rutas rutas = new P_Rutas();
            rutas.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //mover el form con panel *Experimental*
        #region Experimento
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
