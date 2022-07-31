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
    public partial class P_Chofer : Form
    {

        private String idchofer;
        private bool editar = false;

        E_Chofer objEntidad = new E_Chofer();
        N_Chofer objNegocio = new N_Chofer();

        public P_Chofer()
        {
            InitializeComponent();
        }

        //metodos
        #region metodos
        public void MostrarTabla(String buscar)
        {

            N_Chofer objNegocio = new N_Chofer();
            DGV.DataSource = objNegocio.ListarAgenda(buscar);

        }
        public void Limpiar()
        {

            editar = false;
            TxtNombreChofer.Text = "";
            TxtApellidoChofer.Text = "";
            TxtFechaChofer.Text = "";
            TxtCedulaChofer.Text = "";
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
                    objEntidad.Nombre_chofer = TxtNombreChofer.Text;
                    objEntidad.Apellido_chofer = TxtApellidoChofer.Text;
                    objEntidad.Fecha_chofer = TxtFechaChofer.Text;
                    objEntidad.Cedula_chofer = TxtCedulaChofer.Text;

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
                    objEntidad.Id_chofer = Convert.ToInt32(idchofer);
                    objEntidad.Nombre_chofer = TxtNombreChofer.Text;
                    objEntidad.Apellido_chofer = TxtApellidoChofer.Text;
                    objEntidad.Fecha_chofer = TxtFechaChofer.Text;
                    objEntidad.Cedula_chofer = TxtCedulaChofer.Text;

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

        private void P_Chofer_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
        }

        private void BtnSelecChofer_Click(object sender, EventArgs e)
        {
            editar = true;
            if (DGV.SelectedRows.Count > 0)
            {
                idchofer = DGV.CurrentRow.Cells[0].Value.ToString();
                TxtNombreChofer.Text = DGV.CurrentRow.Cells[1].Value.ToString();
                TxtApellidoChofer.Text = DGV.CurrentRow.Cells[2].Value.ToString();
                TxtFechaChofer.Text = DGV.CurrentRow.Cells[3].Value.ToString();
                TxtCedulaChofer.Text = DGV.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione una fila si desea editarla");
            }
        }

        private void TxtBuscarChofer_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(TxtBuscarChofer.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnAutobuses_Click(object sender, EventArgs e)
        {
            P_Autobuses bus = new P_Autobuses();
            bus.Show();
        }

        private void BtnRutas_Click(object sender, EventArgs e)
        {
            P_Rutas rutas = new P_Rutas();
            rutas.Show();
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            P_Asignar asignar = new P_Asignar();
            asignar.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        //mover panel *experimental*
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
