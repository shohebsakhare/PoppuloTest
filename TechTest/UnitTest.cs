using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechTest
{
    public class Tests : IStoreable
    {
        public string Name { get; set; }
        public IComparable Id { get; set; }

        Repository<Tests> repository = new Repository<Tests>();
        IEnumerable<Tests> expected;

        [Test]
        public void Tst_Repository_All()
        {
            expected = repository.All();
            Assert.IsInstanceOf<IEnumerable<Tests>>(expected);
        }
        [Test]
        public void Tst_Repository_Add()
        {
            Tests addItem = new Tests { Id = 1, Name = "MyTest" };
            repository.Save(addItem);
            expected = repository.All();
            Assert.IsTrue(((IEnumerable<Tests>)expected).Contains(addItem));
        }

        [Test]
        public void Tst_Repository_Delete()
        {
            Tests delExistingItem = new Tests { Id = 1, Name = "MyTest" };

            repository.Save(delExistingItem);
            repository.Delete(1);
            expected = repository.All();

            Assert.IsFalse(((IEnumerable<Tests>)expected).Contains(delExistingItem));
        }
        [Test]
        public void Tst_Repository_FindById()
        {
            Tests Item1 = new Tests { Id = 1, Name = "MyTest1" };
            Tests Item2 = new Tests { Id = 2, Name = "MyTest2" };
            Tests Item3 = new Tests { Id = 3, Name = "MyTest3" };
            repository.Save(Item1);
            repository.Save(Item2);
            repository.Save(Item3);

            Tests expected = repository.FindById(2);

            Assert.AreEqual(Item2, expected);
        }
    }
}