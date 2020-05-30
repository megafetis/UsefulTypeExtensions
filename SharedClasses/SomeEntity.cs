namespace SharedClasses
{
    public class SomeEntity1:BaseEntity<string>,IHasName
    {
        public string Name { get; set; }
    }

    public class SomeEntity2 : IEntity<int>, IHasName
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class SomeEntity3 : BaseIntIdEntity, IHasName
    {
        public string Name { get; set; }
    }
}
