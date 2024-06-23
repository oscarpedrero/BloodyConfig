using System;
using System.Drawing;
using System.Windows.Forms;

namespace BloodyConfig
{
    public partial class BloodyConfig : Form
    {

        private Button botonSeleccionado;
        private Panel bordeInferior;

        public BloodyConfig()
        {
            InitializeComponent();
            bordeInferior  = new Panel();
            bordeInferior.Size = new Size(230,2);
            panelBtns.Controls.Add(bordeInferior);
            ActivarBoton(BloodyBoss);
            vistaBloodyBoss fp = new vistaBloodyBoss();
            aplicarFiltros(fp);
        }

        private void ActivarBoton(object boton)
        {
            if(boton != null)
            {
                DeshabilitarBoton();
                botonSeleccionado = (Button)boton;
                botonSeleccionado.ForeColor = Color.Red;
                bordeInferior.BackColor = Color.Red;
                bordeInferior.Location = new Point(botonSeleccionado.Location.X,53);
                bordeInferior.Visible = true;
                bordeInferior.BringToFront();
            }
        }

        private void DeshabilitarBoton()
        {
            if( botonSeleccionado != null)
            {
                botonSeleccionado.ForeColor = Color.Black;
            }
        }

        private void aplicarFiltros(UserControl filtro)
        {
            filtro.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(filtro);
            filtro.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar el formulario para que no se pueda redimensionar ni maximizar
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BloodyBoss_Click(object sender, EventArgs e)
        {
            
        }

        private void BloodyWallet_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            panelContenedor.Controls.Clear();
        }
    }
}
