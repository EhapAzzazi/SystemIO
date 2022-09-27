namespace SystemIO
{
    class FileStreamTesting
    {
        public static void Example01(string path)
        {
            if (File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    Console.WriteLine($"Length: {fs.Length} Byte(s)");
                    Console.WriteLine($"Position: {fs.Position}"); // the position of Cursor
                    Console.WriteLine($"CanRead: {fs.CanRead}");
                    Console.WriteLine($"CanWrite: {fs.CanWrite}");
                    Console.WriteLine($"CanSeek: {fs.CanSeek}");
                    Console.WriteLine($"CanTimeout: {fs.CanTimeout}");

                    //Console.WriteLine($"======================");
                    //fs.WriteByte(65);// Letter A
                    //Console.WriteLine($"Position: {fs.Position}");

                    //Console.WriteLine($"======================");
                    //fs.WriteByte(66);// Letter B
                    //Console.WriteLine($"Position: {fs.Position}");

                    //Console.WriteLine($"======================");
                    //fs.WriteByte(13);// Press Enter
                    //Console.WriteLine($"Position: {fs.Position}");

                    Console.WriteLine($"======================");
                    for (byte i = 65; i < 123; i++)
                    {
                        if (i >= 91 && i <= 96) // To pass [\]^_`
                            continue;
                        fs.WriteByte(i);// WriteDown form A-z
                    }
                    Console.WriteLine($"Position: {fs.Position}");


                    Console.WriteLine("=========================================================");
                }
            }
        }
        public static void Example02(string path, string newpath)
        {
            if (File.Exists(path))
            {
                
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] Data = new byte[fs.Length];
                    int NumsBytesToRead = (int)fs.Length;
                    int NumsBytesRead = 0;
                    while (NumsBytesToRead > 0)
                    {
                        int n =

                        fs.Read(Data, NumsBytesRead, NumsBytesToRead);

                        if (n != 0)
                        {
                            NumsBytesToRead -= n;
                            NumsBytesRead += n;
                        }
                        else
                            break;
                    }
                    using (var fw = new FileStream(newpath, FileMode.Create, FileAccess.Write))
                    {
                        fw.Write(Data, 0, Data.Length);
                    }
                    foreach (var b in Data)
                    {
                        Console.WriteLine(((char)b));
                    }

                    Console.WriteLine("=========================================================");
                }
               
            }
        }
        public static void Example03(string createpath)
        {
            using (FileStream fs = new FileStream(createpath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Seek(20, SeekOrigin.Begin);
                fs.WriteByte(65);
                fs.Position = 0; // TO MAKE THE READING PROCESS WORKS SUCCESSFULLY
                for (int i = 0; i < fs.Length; i++)
                {
                    Console.WriteLine(fs.ReadByte());
                } 
                Console.WriteLine("=========================================================");
            }

        }

        public static void Example04(string path)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("C#");
                sw.WriteLine("Is");
                sw.WriteLine("Amazing");
                sw.WriteLine("!");

                // if we are not using keyword 'using' we would have written sw.Close(); 
            }

        }
        public static void Example05(string path)
        {
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() > 0)
                {
                    Console.Write((char)sr.Read());
                }
                Console.WriteLine("=========================================================");
                // if we are not using keyword 'using' we would have written sw.Close(); 
            }

        }
        public static void Example06(string path)
        {
            using (var sr = new StreamReader(path))
            {
                string? line;
                while ((line = sr.ReadLine()) is not null )
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("=========================================================");
                // if we are not using keyword 'using' we would have written sw.Close(); 
            }

        }
        public static void Example07(string path)
        {
            string[] lines =
           {
                "C#",
                "Is",
                "Amazing",
                "!"
            };
            File.WriteAllLines(path, lines);
        }
        public static void Example08(string path)
        {
            string txt ="C# Is Amazing!";
            File.WriteAllText(path, txt);
        }
        public static void Example09(string path)
        {
            string txt = File.ReadAllText(path);
            Console.WriteLine(txt);
        }
        public static void Example10(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            Console.WriteLine(line);
        }
    }
}
