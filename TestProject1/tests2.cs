using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class tests2
    {
        [Fact]
        public void test_Push_Enqueue()
        {
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

            // Añadimos un elemento a la cola
            concurrentStack.Push(20);
            concurrentQueue.Enqueue(10);

            // Verificamos que el elemento se haya añadido correctamente
            int result;
            Assert.True(concurrentStack.TryPeek(out result));
            Assert.Equal(20, result);

            Assert.True(concurrentQueue.TryPeek(out result));
            Assert.Equal(10, result);
        }

        [Fact]
        public void Test_TryDequeue_TryPop()
        {
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

            // Añadimos algunos elementos a la cola
            concurrentStack.Push(40);
            concurrentStack.Push(50);
            concurrentStack.Push(60);

            concurrentQueue.Enqueue(10);
            concurrentQueue.Enqueue(20);
            concurrentQueue.Enqueue(30);

            // Elimina y obtiene el primer elemento de la cola
            int result;
            Assert.True(concurrentStack.TryPop(out result));
            Assert.Equal(60, result);
            
            Assert.True(concurrentQueue.TryDequeue(out result));
            Assert.Equal(10, result);

            // Verificamos que el elemento haya sido eliminado correctamente
            Assert.Equal(2, concurrentStack.Count);
            Assert.Equal(2, concurrentQueue.Count);
        }

        [Fact]
        public void Test_CopyTo()
        {
            // Creamos un ConcurrentQueue de enteros
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

            // Añadimos algunos elementos a la cola
            concurrentQueue.Enqueue(10);
            concurrentQueue.Enqueue(20);
            concurrentQueue.Enqueue(30);

            // Creamos una matriz de tamaño suficiente para contener todos los elementos de la cola
            int[] array = new int[concurrentQueue.Count];

            // Copiamos los elementos de la cola a la matriz
            concurrentQueue.CopyTo(array, 0);

            // Verificamos que la matriz contenga los elementos esperados
            Assert.Equal(10, array[0]);
            Assert.Equal(20, array[1]);
            Assert.Equal(30, array[2]);
        }

        [Fact]
        public void Test_GetEnumerator()
        {
            // Creamos un ConcurrentStack de enteros
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

            // Añadimos algunos elementos a la pila
            concurrentStack.Push(10);
            concurrentStack.Push(20);
            concurrentStack.Push(30);

            // Creamos una lista para almacenar los elementos obtenidos del enumerador
            List<int> resultList = new List<int>();

            // Obtenemos el enumerador del ConcurrentStack y recorremos todos los elementos
            var enumerator = concurrentStack.GetEnumerator();
            while (enumerator.MoveNext())
            {
                resultList.Add(enumerator.Current);
            }

            // Verificamos que la lista contenga los elementos esperados
            Assert.Equal(30, resultList[0]);
            Assert.Equal(20, resultList[1]);
            Assert.Equal(10, resultList[2]);
        }

        [Fact]
        public void Test_ToArray()
        {
            // Creamos un ConcurrentStack de enteros
            ConcurrentStack<int> concurrentStack = new ConcurrentStack<int>();

            // Añadimos algunos elementos a la pila
            concurrentStack.Push(10);
            concurrentStack.Push(20);
            concurrentStack.Push(30);

            // Convertimos el ConcurrentStack en un arreglo
            int[] array = concurrentStack.ToArray();

            // Verificamos que el arreglo contenga los elementos esperados
            Assert.Equal(30, array[0]);
            Assert.Equal(20, array[1]);
            Assert.Equal(10, array[2]);
        }
    }
}
