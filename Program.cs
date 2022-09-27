using System.Diagnostics.Metrics;
using System.IO.Compression;
using System.Security.Cryptography;

namespace SystemIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CurrencyServices Using
            // 1) not recommended
            //CurrencyServices currencyService = new CurrencyServices();
            //var result = currencyService.GetCurrencies();
            //currencyService.Dispose();
            //Console.WriteLine(result);

            //2) recommended
            //CurrencyServices currencyServices = null;
            //try
            //{
            //    currencyService = new CurrencyServices();
            //    var result = currencyServices.GetCurrencies();
            //    Console.WriteLine(result);

            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Error");
            //}
            //finally
            //{
            //    currencyServices?.Dispose(); 
            //}

            // 3) more recommended  using with blocks to dispose everything inside the blocks (.net framework 2+)
            //using (CurrencyServices currencyServices = new CurrencyServices())
            //{
            //    var result = currencyServices.GetCurrencies();
            //    Console.WriteLine($"{result} \n\n\n\n\n\n=========================================================");
            //}

            // 4) using with no blocks c# 8.0
            //using CurrencyServices currencyService = new CurrencyServices();
            //var result = currencyServices.GetCurrencies();
            //Console.WriteLine(result);
            #endregion






            #region FileStreamTesting Using
            //string path = "Hello.txt";
            //string newpath = "Hello1.txt";
            //FileStreamTesting.Example01(path);
            //FileStreamTesting.Example02(path, newpath);

            //string createpath = "Hi.txt";
            //FileStreamTesting.Example03(createpath);

            //string Example04path = "Hello04.txt";
            //FileStreamTesting.Example04(Example04path);
            //FileStreamTesting.Example05(Example04path);
            //FileStreamTesting.Example06(Example04path);

            //string Example07path = "Hello07.txt";
            //FileStreamTesting.Example07(Example07path);
            //FileStreamTesting.Example10(Example07path);

            //string Example08path = "Hello08.txt";
            //FileStreamTesting.Example08(Example08path);
            //FileStreamTesting.Example09(Example08path);
            #endregion






            #region StreamDecorator
            using (var stream = File.Create("data.bin"))
            {
                using (var ds = new DeflateStream(stream, CompressionMode.Compress))
                {
                    string name = "69 104 97 112 32 65 122 122 97 122 105";
                    var Letters = name.Split(' ');
                    foreach (var letter in Letters)
                    {
                        ds.WriteByte(Convert.ToByte(letter));
                    }
                }
            }

            using (var stream = File.OpenRead("data.bin"))
            {
                using (var ds = new DeflateStream(stream, CompressionMode.Decompress))
                {
                    string name = "";
                    for (int i = 0; i < stream.Length - 2; i++)
                    {
                        name += (char)ds.ReadByte();
                    }
                    Console.Write(name);
                    using (var sw = new StreamWriter("data.txt"))
                    {
                        sw.Write(name);
                    }
                }
            }

            #endregion






            Console.ReadKey();
        }
    }
}
