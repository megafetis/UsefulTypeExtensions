namespace SharedClasses
{
    public abstract class BaseEntity<TId>:IEntity<TId>
    {
        public TId Id { get; set; }
    }

    public abstract class BaseIntIdEntity : BaseEntity<int>
    {

    }
}
