namespace GameCom.Model.Entities
{
    public class IdProductoUsuario
    {
        public virtual Usuario Usuario { get; set; }

        public virtual Producto Producto { get; set; }

        private int? cachedHashCode;

        public override bool Equals(object obj)
        {
            var other = obj as IdProductoUsuario;

            if (other == null)
            {
                return false;
            }

            return Producto != null && Producto.Equals(other.Producto) && Usuario != null && Usuario.Equals(other.Usuario);
        }

        public override int GetHashCode()
        {
            if (cachedHashCode.HasValue) return cachedHashCode.Value;

            cachedHashCode = Producto != null && Usuario != null 
                ? (Producto.Id.ToString() + "_" + Usuario.ToString()).GetHashCode() 
                : base.GetHashCode();
            
            return cachedHashCode.Value;
        }
    }
}
