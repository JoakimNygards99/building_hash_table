using HashTable;
using HashTable.HashmapDifferentDatastructures;

namespace HashTableTest
{
    using HashTable;
    using HashTable.HashmapDifferentDatastructures;

    namespace HashTableTest
    {
        public class HashTableArrayTest
        {
            [Fact]
            public void TestHashMapArrayThrowsUserNotExistsException()
            {
                HashMapArray hmaparray = new HashMapArray();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaparray.Add(pontus.UserName, pontus);

                var caughtException = Assert.Throws<Exception>(() => hmaparray.Add(pontus.UserName, pontus));

                Assert.Equal($"Key '{pontus.UserName}' already exists in the hashtable", caughtException.Message);
            }
            [Fact]
            public void TestHashMapArrayGetReturnsCorrectObject()
            {
                HashMapArray hmaparray = new HashMapArray();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaparray.Add(pontus.UserName, pontus);

                object testStudent = hmaparray.Get(pontus.UserName);

                Assert.Equal(testStudent, pontus);
            }
            [Fact]
            public void TestHashMapArrayAfterRemoveReturnsEmpty()
            {
                HashMapArray hmaparray = new HashMapArray();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaparray.Add(pontus.UserName, pontus);

                hmaparray.Remove(pontus.UserName);

                Assert.Equal(0, hmaparray.ReturnCount());
            }
        }
        public class HashTableLinkedListTest
        {
            [Fact]
            public void HashMapLinkedListThrowsUserNotExistsException()
            {
                HashMapLinkedList hmaplinkedlist = new HashMapLinkedList();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaplinkedlist.Add(pontus.UserName, pontus);

                var caughtException = Assert.Throws<Exception>(() => hmaplinkedlist.Add(pontus.UserName, pontus));

                Assert.Equal($"Key '{pontus.UserName}' already exists in the hashtable", caughtException.Message);
            }
            [Fact]
            public void HashMapLinkedListGetReturnsCorrectObject()
            {
                HashMapLinkedList hmaplinkedlist = new HashMapLinkedList();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaplinkedlist.Add(pontus.UserName, pontus);

                object testStudent = hmaplinkedlist.Get(pontus.UserName);

                Assert.Equal(testStudent, pontus);
            }
            [Fact]
            public void TestHashMapLinkedListAfterRemoveReturnsEmpty()
            {
                HashMapLinkedList hmaplinkedlist = new HashMapLinkedList();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaplinkedlist.Add(pontus.UserName, pontus);

                hmaplinkedlist.Remove(pontus.UserName);

                Assert.Equal(0, hmaplinkedlist.ReturnCount());
            }
        }
        public class HashTableListTest
        {
            [Fact]
            public void HashMapListThrowsUserNotExistsException()
            {
                HashMapList hmaplist = new HashMapList();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaplist.Add(pontus.UserName, pontus);

                var caughtException = Assert.Throws<Exception>(() => hmaplist.Add(pontus.UserName, pontus));

                Assert.Equal($"Key '{pontus.UserName}' already exists in the hashtable", caughtException.Message);
            }
            [Fact]
            public void HashMapListGetReturnsCorrectObject()
            {
                HashMapList hmaplist = new HashMapList();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaplist.Add(pontus.UserName, pontus);

                object testStudent = hmaplist.Get(pontus.UserName);

                Assert.Equal(testStudent, pontus);
            }
            [Fact]
            public void TestHashMapListAfterRemoveReturnsEmpty()
            {
                HashMapList hmaplist = new HashMapList();

                student pontus = new student("h21ponag", "pontus", 0725291385, "p.agren@135355.com", "IT");

                hmaplist.Add(pontus.UserName, pontus);

                hmaplist.Remove(pontus.UserName);

                Assert.Equal(0, hmaplist.ReturnCount());
            }
        }
    }
}