using MySqlConnector;
//using ProyectoSen.Clases;   *simplificar clases
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
    public partial class InicioAdmin : Form
    {
        public InicioAdmin()
        {
            InitializeComponent();
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.mostrarReporte(dgvReporte);
        }
        //desde aqui
        //call the function dll
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
//hata aqui copiar


        private void btnRegistrarT_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tecnico tecnico= new Tecnico();
            tecnico.ShowDialog();
        }

        private void btnRegistrarC_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cliente cliente = new Cliente();
            cliente.ShowDialog();
        }

        private void btnRegistrarE_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipo equipo= new Equipo();
            equipo.ShowDialog();
        }

        private void InicioAdmin_Load(object sender, EventArgs e)
        {
            //this is for login load
           
            panel1.Anchor = AnchorStyles.None;
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));
           // btnRegistrarC.Region = Region.FromHrgn(CreateRoundRectRgn(0,0,btnRegistrarC.Width, btnRegistrarC.Height,30,30));


            IntPtr region = CreateRoundRectRgn(0, 0, btnCSesion.Width, btnCSesion.Height, 30, 30);
            SetWindowRgn(btnCSesion.Handle, region, true);

            IntPtr region1 = CreateRoundRectRgn(0, 0, btnRegistrarT.Width, btnRegistrarT.Height, 30, 30);
            SetWindowRgn(btnRegistrarT.Handle, region1, true);

            IntPtr region2 = CreateRoundRectRgn(0, 0, btnRegistrarC.Width, btnRegistrarC.Height, 30, 30);
            SetWindowRgn(btnRegistrarC.Handle, region2, true);

            IntPtr region3 = CreateRoundRectRgn(0, 0, btnRegistrarE.Width, btnRegistrarE.Height, 30, 30);
            SetWindowRgn(btnRegistrarE.Handle, region3, true);

            IntPtr region4 = CreateRoundRectRgn(0, 0, btnAsignar.Width, btnAsignar.Height, 30, 30);
            SetWindowRgn(btnAsignar.Handle, region4, true);
            

            IntPtr region5 = CreateRoundRectRgn(0, 0, btnTecnico.Width, btnTecnico.Height, 30, 30);
            SetWindowRgn(btnTecnico.Handle, region5, true);

            IntPtr region6 = CreateRoundRectRgn(0, 0, btnEquipo.Width, btnEquipo.Height, 30, 30);
            SetWindowRgn(btnEquipo.Handle, region6, true);

            IntPtr region7 = CreateRoundRectRgn(0, 0, btnCliente.Width, btnCliente.Height, 30, 30);
            SetWindowRgn(btnCliente.Handle, region7, true);

            IntPtr region8 = CreateRoundRectRgn(0, 0, btnBuscarR.Width, btnBuscarR.Height, 30, 30);
            SetWindowRgn(btnBuscarR.Handle, region8, true);

            IntPtr region9 = CreateRoundRectRgn(0, 0, btnBuscar.Width, btnBuscar.Height, 30, 30);
            SetWindowRgn(btnBuscar.Handle, region9, true);
            Clases.Login objetoLogin = new Clases.Login();
            objetoLogin.MostrarDatoEnLabel(lblUsuario);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar sesion?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login equipo = new Login();
                equipo.ShowDialog();
            }
            else
            {
                // Código para la acción negativa o cancelada
                // ...
            }
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text == "TECNICO")
            {
                Clases.CTecnico objetoReporte = new Clases.CTecnico();
                objetoReporte.BuscarTecnico(dgvPrincipal, txtBuscar);

            }

            if (cmbBuscar.Text == "CLIENTE")
            {
                Clases.CCliente objetoReporte = new Clases.CCliente();
                objetoReporte.BuscarCliente(dgvPrincipal, txtBuscar);
            }
            else
            {
                cmbBuscar.Text = "Elija una opcion";
            }
        
    }


        private void btnTecnico_Click(object sender, EventArgs e)
        {
            Clases.CTecnico objetoTecnico = new Clases.CTecnico();
            objetoTecnico.mostrarTecnico(dgvPrincipal);
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            Clases.CEquipo objetoEquipo = new Clases.CEquipo();
            objetoEquipo.mostrarEquipo(dgvPrincipal);
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Clases.CCliente objetoCliente = new Clases.CCliente();
            objetoCliente.mostrarCliente(dgvPrincipal);
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                txtBuscar.Text = "Ingrese DNI";
                txtBuscar.ForeColor = Color.LightSteelBlue;
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Ingrese DNI")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.LightSteelBlue;
            }
        }

        private void txtBuscarR_Leave(object sender, EventArgs e)
        {
            if (txtBuscarR.Text == "")
            {
                txtBuscarR.Text = "Ingrese DNI Tecnico";
                txtBuscarR.ForeColor = Color.LightSteelBlue;
            }
        }

        private void txtBuscarR_Enter(object sender, EventArgs e)
        {
            if (txtBuscarR.Text == "Ingrese DNI Tecnico")
            {
                txtBuscarR.Text = "";
                txtBuscarR.ForeColor = Color.LightSteelBlue;
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            this.Hide();
            AsignarRe admin = new AsignarRe();
            admin.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActualizarEstadoE_Admin admin = new ActualizarEstadoE_Admin();
            admin.ShowDialog();
        }

        private void btnBuscarR_Click(object sender, EventArgs e)
        {
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.BuscarReporte(dgvReporte, txtBuscarR);
        }

        private void btnClienteB_Click(object sender, EventArgs e)
        {
            Clases.CReporte objetoReporte = new Clases.CReporte();
            objetoReporte.BuscarCliente(dgvReporte, txtDni_C);
        }

        private void txtDni_C_Leave(object sender, EventArgs e)
        {
            if (txtDni_C.Text == "")
            {
                txtDni_C.Text = "Ingrese DNI Cliente";
                txtDni_C.ForeColor = Color.LightSteelBlue;
            }
        }

        private void txtDni_C_Enter(object sender, EventArgs e)
        {
            if (txtDni_C.Text == "Ingrese DNI Cliente")
            {
                txtDni_C.Text = "";
                txtDni_C.ForeColor = Color.Black;
            }
        }
    }
}
