using System;

namespace GameCom.Model.Entities
{
    public class UsuarioDatosPersonales
    {
        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual DateTime? FechaNacimiento { get; set; }
        
        public virtual string Telefono { get; set; }
    }
}
