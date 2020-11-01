namespace GameCom.Model.Entities
{
    public class IdLogroProducto
    {
        public virtual Producto Producto { get; set; }

        public virtual string Codigo { get; set; }

        private int? cachedHashCode;

        public override bool Equals(object obj)
        {
            var other = obj as IdLogroProducto;

            if (other == null)
            {
                return false;
            }

            return Producto != null && Producto.Equals(other.Producto) && Codigo != null && Codigo.Equals(other.Codigo);
        }

        public override int GetHashCode()
        {
            if (cachedHashCode.HasValue) return cachedHashCode.Value;

            cachedHashCode = Producto != null && Codigo != null 
                ? (Producto.Id.ToString() + "_" + Codigo.ToString()).GetHashCode() 
                : base.GetHashCode();
            
            return cachedHashCode.Value;
        }
    }
}
