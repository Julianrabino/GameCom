using GameCom.Model.Base;

namespace GameCom.Model.Entities
{
    public class LogroProducto : EntityBase<IdLogroProducto>
    {
        public LogroProducto(string codigo): this()
        {
            this.Id.Codigo = codigo;
        }

        public LogroProducto()
        {
            this.Id = new IdLogroProducto();
        }

        #region indirecciones a ID       
        public virtual Producto Producto
        {
            get { return this.Id.Producto; }
            set { this.Id.Producto = value; }
        }

        public virtual string Codigo
        {
            get { return this.Id.Codigo; }
            set { this.Id.Codigo = value; }
        }
        #endregion

        public virtual string Descripcion { get; set; }
    }
}
