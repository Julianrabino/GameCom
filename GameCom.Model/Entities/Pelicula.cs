namespace GameCom.Model.Entities
{
    public class Pelicula: Producto
    {
        public virtual string Productora { get; set; }

        public virtual string Resenia { get; set; }

        public virtual int? DuracionMinutos { get; set; }
    }
}
