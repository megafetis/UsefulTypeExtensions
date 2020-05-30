using System;
using NUnit.Framework;
using SharedClasses;
using UsefulTypeExtensions;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InheritsOrImplementsTest()
        {
            Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(IEntity<>)));
            Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(SomeEntity1)));
            Assert.False(typeof(SomeEntity1).InheritsOrImplements(typeof(IEntity<int>)));
            Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(IEntity<string>))); 
            Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(IHasName)));
            Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(BaseEntity<>)));
            Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(BaseEntity<string>)));
            Assert.False(typeof(SomeEntity1).InheritsOrImplements(typeof(BaseEntity<int>)));

            Assert.True(typeof(BaseEntity<>).InheritsOrImplements(typeof(IEntity<>)));

            Assert.True(typeof(BaseEntity<string>).InheritsOrImplements(typeof(IEntity<string>)));

            Assert.True(typeof(BaseEntity<string>).InheritsOrImplements(typeof(IEntity<>)));
            Assert.True(typeof(IEntity<string>).InheritsOrImplements(typeof(IEntity<>)));
            Assert.True(typeof(IEntity<string>).InheritsOrImplements(typeof(IEntity)));
            Assert.True(typeof(IEntity<string>).InheritsOrImplements(typeof(IEntity<string>)));
            Assert.True(typeof(IEntity<>).InheritsOrImplements(typeof(IEntity<>)));

            Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<>)));

            Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity)));
            Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<>)));
            Assert.False(typeof(SomeEntity2).InheritsOrImplements(typeof(BaseEntity<>)));
            Assert.False(typeof(SomeEntity2).InheritsOrImplements(typeof(BaseEntity<int>)));
            Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<int>)));
            Assert.False(typeof(SomeEntity2).InheritsOrImplements(typeof(IEntity<string>)));

            Assert.True(typeof(IEntity).InheritsOrImplements(typeof(IEntity)));
            Assert.False(typeof(IEntity).InheritsOrImplements(typeof(IEntity<>)));
            Assert.True(typeof(IEntity<>).InheritsOrImplements(typeof(IEntity)));

            Assert.False(typeof(BaseEntity<>).InheritsOrImplements(typeof(SomeEntity1)));
            Assert.False(typeof(BaseEntity<string>).InheritsOrImplements(typeof(SomeEntity1)));
            Assert.True(typeof(BaseEntity<string>).InheritsOrImplements(typeof(BaseEntity<>)));
            Assert.False(typeof(BaseEntity<string>).InheritsOrImplements(typeof(BaseEntity<int>)));

            Assert.True(typeof(BaseEntity<>).InheritsOrImplements(typeof(object)));
            Assert.True(typeof(BaseEntity<>).InheritsOrImplements(typeof(Object)));
            Assert.True(typeof(SomeEntity1).InheritsOrImplements(typeof(object)));
            Assert.True(typeof(SomeEntity2).InheritsOrImplements(typeof(object)));

            Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(BaseEntity<>)));
            Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(BaseEntity<int>)));
            Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(BaseIntIdEntity)));
            Assert.True(typeof(BaseIntIdEntity).InheritsOrImplements(typeof(IEntity<int>)));
            Assert.True(typeof(SomeEntity3).InheritsOrImplements(typeof(BaseIntIdEntity)));
            Assert.True(typeof(SomeEntity3).InheritsOrImplements(typeof(IEntity<int>)));

        }

        [Test]
        public void GetDefaultValueTest()
        {
            Assert.Null(typeof(SomeEntity1).GetDefaultValue());
            Assert.Null(typeof(string).GetDefaultValue());
            Assert.AreEqual(typeof(int).GetDefaultValue(),0);
            Assert.AreEqual(typeof(long).GetDefaultValue(),0);
            Assert.AreEqual(typeof(DateTime).GetDefaultValue(),DateTime.MinValue);
        }
    }
}