using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjPersistencia.Back
{
    public class Personas
    {
        public DataTable ListaDT { get; set; } = new DataTable();

        public Personas()
        {
            ListaDT.TableName = "ListaPersonas";
            ListaDT.Columns.Add("Id", typeof(int));
            ListaDT.Columns.Add("Nombre");
            ListaDT.Columns.Add("Apellido");
            ListaDT.Columns.Add("Edad",typeof(int));
            LeerArchivo();
        }

        public void LeerArchivo()
        {
            if(System.IO.File.Exists("Personas.xml"))
            {
                ListaDT.ReadXml("Personas.xml");
            }
        }

        public void InsertPersona(Persona aPersona)
        {
            int id = NuevoId();

            ListaDT.Rows.Add(); //agrego renglon vacio
            int NuevoRenglon = ListaDT.Rows.Count - 1;
            ListaDT.Rows[NuevoRenglon]["Id"]=id;
            ListaDT.Rows[NuevoRenglon]["Nombre"] = aPersona.Nombre;
            ListaDT.Rows[NuevoRenglon]["Apellido"] = aPersona.Apellido;
            ListaDT.Rows[NuevoRenglon]["Edad"] = aPersona.Edad;

            ListaDT.WriteXml("Personas.xml");
        }

        private int NuevoId()
        {
            int NuevoId = 0;

            foreach (DataRow fila in ListaDT.Rows)
            {
                if (NuevoId < Convert.ToInt32(fila["Id"]))
                {
                    NuevoId = Convert.ToInt32(fila["Id"]);
                }
            }

            NuevoId ++;
            return NuevoId;
        }

        public Persona Buscar(string aId)
        {
            int id = Convert.ToInt32(aId);

            Persona per = new Persona();

            //for(int i = 0; i < ListaDT.Rows.Count; i++)
            //{
            //    if (Convert.ToInt32(ListaDT.Rows[i]["Id"])  == id)
            //    {
            //        per.Id = Convert.ToInt32(ListaDT.Rows[i]["Id"]);
            //        per.Nombre = Convert.ToString(ListaDT.Rows[i]["Nombre"]);
            //        per.Apellido = ListaDT.Rows[i]["Apellido"].ToString();
            //        per.Edad = Convert.ToInt32(ListaDT.Rows[i]["Edad"]);
            //        break;
            //    }
            //}

            foreach (DataRow fila in ListaDT.Rows)
            {
                if (Convert.ToInt32(fila["Id"]) == id)
                {
                    per.Id = Convert.ToInt32(fila["Id"]);
                    per.Nombre = Convert.ToString(fila["Nombre"]);
                    per.Apellido = fila["Apellido"].ToString();
                    per.Edad = Convert.ToInt32(fila["Edad"]);
                    break;
                }
            }


            return per;
        }
    }
}
