using System.Collections.Concurrent;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

            int totalItems = 30;
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

            int totalItems = 30;
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

        [Fact]
        public void TestSncronizacion()
        {
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

            int totalItems = 30;
            int itemsAdded = 0;

            // Agrega elementos a ConcurrentStack
            for (int i = 0; i < totalItems; i++)
            {
                concurrentStack.Push(i);
            }

            // Realiza operaciones de lectura y escritura concurrentes
            Parallel.Invoke(
                () =>
                {
                    // Extrae elementos de ConcurrentStack
                    int count = 0;
                    while (concurrentStack.TryPop(out _))
                    {
                        count++;
                    }
                    Assert.Equal(totalItems, count);
                },
                () =>
                {
                    // Espera a que se completen las operaciones de extracci�n de elementos
                    Thread.Sleep(100);

                    // Agrega elementos adicionales a ConcurrentStack
                    for (int i = 0; i < totalItems; i++)
                    {
                        concurrentStack.Push(i);
                        Interlocked.Increment(ref itemsAdded);
                    }
                });

            // Verifica que el recuento final sea correcto
            Assert.Equal(totalItems, concurrentStack.Count);

            // Verifica que todos los elementos hayan sido agregados correctamente
            Assert.Equal(totalItems, itemsAdded);
        }

        [Fact]
        public void TestSncronizacion2()
        {
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

            int totalItems = 30;
            int itemsAdded = 0;

            // Agrega elementos a ConcurrentQueue
            for (int i = 0; i < totalItems; i++)
            {
                concurrentQueue.Enqueue(i);
            }

            // Realiza operaciones de lectura y escritura concurrentes
            Parallel.Invoke(
                () =>
                {
                    // Extrae elementos de ConcurrentQueue
                    int count = 0;
                    int result;
                    while (concurrentQueue.TryDequeue(out result))
                    {
                        count++;
                    }
                    Assert.Equal(totalItems, count);
                },
                () =>
                {
                    // Espera a que se completen las operaciones de extracci�n de elementos
                    Thread.Sleep(100);

                    // Agrega elementos adicionales a ConcurrentQueue
                    for (int i = 0; i < totalItems; i++)
                    {
                        concurrentQueue.Enqueue(i);
                        Interlocked.Increment(ref itemsAdded);
                    }
                });

            // Verifica que el recuento final sea correcto
            Assert.Equal(totalItems, concurrentQueue.Count);

            // Verifica que todos los elementos hayan sido agregados correctamente
            Assert.Equal(totalItems, itemsAdded);
        }

        [Fact]
        public void testContain()
        {
            // Creamos un ConcurrentStack de enteros
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

            // Agregamos algunos elementos a la pila
            concurrentStack.Push(1);
            concurrentStack.Push(2);
            concurrentStack.Push(3);

            Assert.True(concurrentStack.Contains(2));

        }
    }
}