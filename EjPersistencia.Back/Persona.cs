using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjPersistencia.Back
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public void Agregar (string aNombre,
                             string aApellido,
                             string aEdad) 
        {
            Nombre = aNombre;
            Apellido = aApellido;
            Edad = Convert.ToInt32(aEdad);    
        }
    }
}
