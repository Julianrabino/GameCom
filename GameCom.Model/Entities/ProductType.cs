using GameCom.Model.Base;

namespace GameCom.Model.Entities
{
    public class ProductType: IEntity<int>
    {
        public virtual int Id { get; set; }

        public virtual string Initials { get; set; }

        public virtual string Description { get; set; }
    }
}
