namespace GameCom.Model.Base
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
