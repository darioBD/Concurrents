using System.Collections.Concurrent;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

            int totalItems = 1000;
            int expectedItemCount = totalItems;

            // Agrega elementos a ConcurrentStack
            for (int i = 0; i < totalItems; i++)
            {
                concurrentStack.Push(i);
            }

            // Realiza operaciones de concurrencia con ConcurrentStack
            Parallel.ForEach(concurrentStack, item =>
            {
                concurrentStack.TryPop(out int result);
            });

            // Verifica que todos los elementos hayan sido eliminados
            Assert.Equal(0, concurrentStack.Count);

        }

        [Fact]
        public void Test2()
        {
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

            int totalItems = 1000;
            int expectedItemCount = totalItems;

            // Agrega elementos a ConcurrentQueue
            for (int i = 0; i < totalItems; i++)
            {
                concurrentQueue.Enqueue(i);
            }

            // Realiza operaciones de concurrencia con ConcurrentQueue
            Parallel.ForEach(concurrentQueue, item =>
            {
                concurrentQueue.TryDequeue(out int result);
            });

            // Verifica que todos los elementos hayan sido eliminados
            Assert.Equal(0, concurrentQueue.Count);
        }
    
    }
}