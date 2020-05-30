namespace SharedClasses
{
    public class SomeEntity1:BaseEntity<string>,IHasName
    {
        public string Name { get; set; }
    }

    public class SomeEntity2 : BaseIntIdEntity, IHasName
    {
        public string Name { get; set; }
    }
}
