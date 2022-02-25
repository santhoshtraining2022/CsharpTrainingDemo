using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace FileHandlingDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // FileSteamDemo filstream = new FileSteamDemo();
            //filstream.WriteFileSteam();
            // filstream.ReadFileStream();


            BinaryFileDemo fileDemo = new BinaryFileDemo();
         //   fileDemo.WriteBinaryFile();
           


            Binary b = new Binary();

         //   b.SerializeMethod();

            b.DeserializeMethod();


        }
    }

    class FileDemo

    {

        public void displayFile()
        {


            try
            {

                Console.WriteLine("File operations");

                string filepath = @"C:\TRN\File\SimpleDemo.txt";
                //if (File.Exists(filepath))
                //{

                //    File.Delete(filepath);

                //}

                //File.Create(filepath);

                // File.WriteAllText(filepath, "sdfwsdfsxzfsxzzcsxvscxvdcx");

                //   File.Move(filepath, @"C:\TRN\File\SimpleDemo2.txt");

                //File.Copy( @"C:\TRN\File\SimpleDemo2.txt", filepath);
                // File.WriteAllText(filepath, "sdfwsdfsxzfsxzzcsxvscxvdcx");

                //    File.AppendAllText(filepath, "sdfwsdfsxzfsxzzcsxvscxvdcx");

                // File.Create(filepath);

                // Console.WriteLine("File created");

                string[] strFileValues = { "fffddf", "dffd", "asxsad" };
                File.WriteAllLines(filepath, strFileValues);

                string[] strFileOutputLines = File.ReadAllLines(filepath);

                foreach (var item in strFileOutputLines)
                {
                    Console.WriteLine(item);

                }



                string DirectPath = @"C:\TRN\File\Test";

                if (Directory.Exists(DirectPath))
                {

                    if (File.Exists(@"C:\TRN\File\Test\Data.txt"))
                    {

                        File.Delete(@"C:\TRN\File\Test\Data.txt");

                    }

                    Directory.Delete(DirectPath);

                }

                Directory.CreateDirectory(DirectPath);
                File.WriteAllText(@"C:\TRN\File\Test\Data.txt", "sdfwsdfsxzfsxzzcsxvscxvdcx");

                Directory.Move(@"C:\TRN\File\Test", @"C:\TRN\FileDemo");

            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }
    }

    class FileSteamDemo
    {
        private FileStream filestream1;

        private FileStream filestream2;

        private StreamWriter sw;

        private StreamReader strReader;

        public void WriteFileSteam()
        {
            filestream1 = new FileStream(@"C:\TRN\FileDemo\Data2.txt", FileMode.OpenOrCreate, FileAccess.Write);

            sw = new StreamWriter(filestream1);

            sw.WriteLine("asdfdaszfdaszfs");
            sw.Write("sasd");
                 sw.WriteLine("we are in file now");

            Console.WriteLine("written to the file");

            sw.Dispose();
            sw.Close();
            filestream1.Close();
        }

        public void ReadFileStream()
        {
            filestream2 = new FileStream(@"C:\TRN\FileDemo\Data2.txt", FileMode.Open, FileAccess.Read);

            strReader = new StreamReader(filestream2);

          string content=  strReader.ReadToEnd();

            Console.WriteLine(content);
            strReader.Close();
            strReader.Dispose();
            filestream2.Close();
        }

    }

    class BinaryFileDemo
    {
        private FileStream filestream1;

        private BinaryWriter binarywriter;

        public void WriteBinaryFile()
        {
            filestream1 = new FileStream(@"C:\TRN\FileDemo\Data2.dat", FileMode.OpenOrCreate, FileAccess.Write);

            binarywriter = new BinaryWriter(filestream1);

            binarywriter.Write(true);

            binarywriter.Write("hello c# developers");
            binarywriter.Write(10001);

            Console.WriteLine("written into binary file");
            binarywriter.Close();
            binarywriter.Dispose();
            filestream1.Close();

        }

        public void ReadBinaryFile()
        {

            // exercise
        }

    }

    class Binary
    {
        private FileStream fs;
        private BinaryFormatter bfr1, bfr2;

        public void SerializeMethod()
        {
            fs = new FileStream(@"C:\TRN\FileDemo\Data3.dat", FileMode.Create, FileAccess.Write);
            
            bfr1 = new BinaryFormatter();

          

            //serialization is done with serialize()
            bfr1.Serialize(fs, "Hi... Welcome to Binary Serialization");
            
            Console.WriteLine("Object Serialized!!!\n");

            fs.Close();
        }
        public void DeserializeMethod()
        {
            fs = new FileStream(@"C:\TRN\FileDemo\Data3.dat", FileMode.Open, FileAccess.Read); bfr2 = new BinaryFormatter();

            ///Deserialization with Deserialize() 
            ///
             string msg = (string)bfr2.Deserialize(fs); 
            
            Console.WriteLine("message:"+msg);
            Console.WriteLine("Object DeSerialized!!!\n");


            List<int> ListInt = new List<int>() { 54, 4545, 676, 55, 54 };
            var ListInt2 = ListInt.LastIndexOf(4545);


            
           

        }


       

       

    }




}
