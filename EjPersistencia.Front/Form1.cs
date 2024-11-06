using EjPersistencia.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjPersistencia.Front
{
    public partial class Form1 : Form
    {
        Personas ListaPersonas { get; set; } = new Personas();


        public Form1()
        {
            InitializeComponent();
            dg.DataSource = ListaPersonas.ListaDT;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Persona per = new Persona();
            per.Agregar(txtNombre.Text,
                        txtApellido.Text,
                        txtEdad.Text);

            ListaPersonas.InsertPersona(per);
            txtId.Text = per.Id.ToString();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Persona perF =  ListaPersonas.Buscar(txtId.Text);

            if (perF.Id != 0 )
            {
                txtNombre.Text= perF.Nombre;
                txtApellido.Text= perF.Apellido;
                txtEdad.Text=perF.Edad.ToString();

                txtNombre.Focus();
            }
            else
            {
                txtId.Text = "no existe";
                txtId.SelectAll();
                txtId.Focus();
            }
        }
    }
}
