using System;
using BiblioPersonas;
using System.Collections;
using System.Windows.Forms;

namespace ClienteG2
{
    public partial class Form1 : Form
    {
        #region Atributos
        private ArrayList personas;
        private int indice;
        #endregion

        #region Propiedades
        public int Indice { get => indice; 
            set => indice = personas.Count > 0 && value < personas.Count ? value : 0;
                /*
            {
                if (personas.Count > 0 && value < personas.Count)
                {
                    indice = value;
                }
                else 
                {
                    indice = 0;
                }
            }
                */
        }
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            personas = new ArrayList();
        }
        #endregion

        #region Metodos
        void Limpiar()
        {
            txtbNombre.Clear();
            txtbTelefono.Clear();
            txtbEdad.Clear();
            txtbDireccion.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
        }
        private void GuardarDatos()
        {
            personas.Add(new Cliente(txtbNombre.Text, txtbTelefono.Text, byte.Parse(txtbEdad.Text), txtbDireccion.Text));
        }
        private void MostrarDatos(int indice)
        {
            Cliente persona = (Cliente)personas[Indice++];

            txtbNombre.Text = persona.Nombre;
            txtbTelefono.Text = persona.Telefono;
            txtbEdad.Text = persona.Edad.ToString();
            txtbDireccion.Text = persona.Direccion;
        }
        #endregion

        #region Eventos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbNombre.Text == "" || txtbTelefono.Text == "" || txtbEdad.Text == "" || txtbDireccion.Text == "")
                    throw new ApplicationException("Las cajas de texto no pueden estar vacias");
                GuardarDatos();
                Limpiar();
            }
            catch (ApplicationException error)
            {
                errorProvider1.SetError(btnGuardar, error.Message);
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarDatos(indice);
                errorProvider2.Clear();
            }
            catch(NullReferenceException error) 
            {
                MessageBox.Show(error.Message);
            }
            catch(ArgumentOutOfRangeException) 
            {
                string errorMessage = "Debes agregar al menos una persona";
                errorProvider2.SetError(btnSiguiente, errorMessage);
            }
        }
        private void txtbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (txtbNombre.Text == "" || txtbTelefono.Text == "" || txtbEdad.Text == "" || txtbDireccion.Text == "")
                        throw new ApplicationException("Las cajas de texto no pueden estar vacias");
                    GuardarDatos();
                    Limpiar();
                    txtbNombre.Focus();
                }
            }
            catch (ApplicationException error)
            {
                errorProvider1.SetError(btnGuardar, error.Message);
            }
        }
        #endregion
    }
}
