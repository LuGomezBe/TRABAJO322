using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSen
{
    public partial class ActualizarEstadoE_User : Form
    {
        public ActualizarEstadoE_User()
        {
            InitializeComponent();
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.mostrarReporte(dgvReporte);
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWithEllipse,
          int nHeightEllipse

          );
        [DllImport("user32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);
        private void btnEntrega_Click(object sender, EventArgs e)
        {
            if (txtEstado.Text == "FINALIZADO")
            {
                Clases.CReporte objetoReportee = new Clases.CReporte();
                objetoReportee.pordefectoF(txtId, txtDefectoE);
                objetoReportee.mostrarReporte(dgvReporte);
                txtEstado.Text = string.Empty;

                if (cmbEntrega.Text == "FALTA ENTREGAR")
                {
                    Clases.CReporte objetoReporte = new Clases.CReporte();
                    objetoReporte.guardarEntrega(txtId, cmbEntrega);
                    objetoReporte.mostrarReporte(dgvReporte);
                    cmbEntrega.Text = string.Empty;
                }
                if (cmbEntrega.Text == "ENTREGADO")
                {
                    Clases.CReporte objetoReporte = new Clases.CReporte();
                    objetoReporte.guardarEntrega(txtId, cmbEntrega);
                    objetoReporte.mostrarReporte(dgvReporte);
                    cmbEntrega.Text = string.Empty;
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Solo se puede modificar si el trabajo esta finalizado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            if(txtEstado.Text == "FINALIZADO")
            {
                Clases.CReporte objetoReportee = new Clases.CReporte();
                objetoReportee.UpdateEstado(txtId, txtEstado);
                objetoReportee.mostrarReporte(dgvReporte);
                objetoReportee.pordefectoF(txtId, txtDefectoE);
                objetoReportee.mostrarReporte(dgvReporte);
                MessageBox.Show("Se actualizo correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Text = string.Empty;
                txtEstado.Text = string.Empty;
                
                txtDefectoE.Text = string.Empty;
            }
            else
            {
                Clases.CReporte objetoReporte = new Clases.CReporte();
                objetoReporte.UpdateEstado(txtId, txtEstado);
                objetoReporte.mostrarReporte(dgvReporte);
                MessageBox.Show("Se actualizo correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Text = string.Empty;
                txtEstado.Text = string.Empty;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            InicioUsuario user = new InicioUsuario();
            user.ShowDialog();
        }

        private void dgvReporte_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.SelecionEstado(dgvReporte, txtId, txtEstado);
        }

        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            if (cmbEstadoE.Text == "NUEVO")
            {
                Clases.CReporte objetoReporte = new Clases.CReporte();
                objetoReporte.BuscarEstado(dgvReporte, cmbEstadoE);
            }
            if (cmbEstadoE.Text == "PROCESO")
            {
                Clases.CReporte objetoReporte = new Clases.CReporte();
                objetoReporte.BuscarEstado(dgvReporte, cmbEstadoE);
            }
            if (cmbEstadoE.Text == "FINALIZADO")
            {
                Clases.CReporte objetoReporte = new Clases.CReporte();
                objetoReporte.BuscarEstado(dgvReporte, cmbEstadoE);
            }
            else
            {
                cmbEstadoE.Text = "Elija una opcion";
            }
        }

        private void ActualizarEstadoE_User_Load(object sender, EventArgs e)
        {
            IntPtr region1 = CreateRoundRectRgn(0, 0, btnVolver.Width, btnVolver.Height, 30, 30);
            SetWindowRgn(btnVolver.Handle, region1, true);

            IntPtr region2 = CreateRoundRectRgn(0, 0, btnModificar.Width, btnModificar.Height, 30, 30);
            SetWindowRgn(btnModificar.Handle, region2, true);

            IntPtr region3 = CreateRoundRectRgn(0, 0, btnEntrega.Width, btnEntrega.Height, 30, 30);
            SetWindowRgn(btnEntrega.Handle, region3, true);

            IntPtr region4 = CreateRoundRectRgn(0, 0, btnBuscarEquipo.Width, btnBuscarEquipo.Height, 30, 30);
            SetWindowRgn(btnBuscarEquipo.Handle, region4, true);

            IntPtr region5 = CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 30, 30);
            SetWindowRgn(button1.Handle, region5, true);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
