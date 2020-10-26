using GameCom.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCom.Model.Entities
{
    public class Usuario : IEntity<int>, IVersionable
    {
        public virtual int Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual string Alias { get; set; }

        public virtual int Version { get; set; }
    }
}
