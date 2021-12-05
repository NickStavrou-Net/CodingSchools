using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start");

            foreach (var item in await FetchItems())
            {
                Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
            }
            #region Async
            //await foreach (var item in FetchItems())
            //{
            //    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
            //}
            #endregion


            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End");
            Console.ReadKey();
        }

        static async Task<IEnumerable<int>> FetchItems()
        {
            List<int> Items = new();
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(1000);
                Items.Add(i);
            }
            return Items;
        }
        #region Async
        //static async IAsyncEnumerable<int> FetchItems()
        //{
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        await Task.Delay(1000);
        //        yield return i;
        //    }
        //}
        #endregion

    }
}

