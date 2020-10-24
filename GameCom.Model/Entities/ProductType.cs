using GameCom.Model.Base;

namespace GameCom.Model.Entities
{
    public class ProductType: IEntity<int>, IVersionable
    {
        public virtual int Id { get; set; }

        public virtual string Initials { get; set; }

        public virtual string Description { get; set; }
        
        public virtual int Version { get; set; }
    }
}
