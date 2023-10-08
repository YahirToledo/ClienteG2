namespace BiblioPersonas
{
    public class Cliente
    {
        #region Atributos
        private string nombre;
        private string telefono;
        private byte edad;
        private string direccion;
        #endregion

        #region Propiedades

        public string Nombre { get => nombre;
            set => nombre = value == "" ? "Anonimo" : value; 
        }
        public string Telefono { get => telefono; 
            set => telefono = value == "" ? "5564215987" : value; 
        }
        public byte Edad { get => edad; 
            set => edad = value < 13 || value > 100 ? (byte)18 : value; 
        }
        public string Direccion { get => direccion; 
            set => direccion = value == "" ? "CDMX" : value; 
        }
        #endregion

        #region Constructor
        public Cliente(string nombre, string telefono, byte edad, string direccion)
        {
            Nombre = nombre;
            Telefono = telefono;
            Edad = edad;
            Direccion = direccion;
        }
        #endregion

    }
}