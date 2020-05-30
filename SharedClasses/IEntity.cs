namespace SharedClasses
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
