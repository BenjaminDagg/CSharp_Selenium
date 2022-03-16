using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


/*
 * When a file is opened for read/write its called a stream (sequence of bytes passing through communication path)
 * - 2 types of streams: input stream, output stream
 * - input stream: reads data from file
 * - output stream writes data to file
 * 
 * ========= filestream class =========
 * - in System.IO namespace
 * - reads from, writes to, closes files
 * 
 * - streamwritter - writes text to file
 * - filestream writes bytes to a file
 * - binarywritter writes binary data to file
 */
namespace CSharp_tutorial
{
    class Fileio
    {
        static void Main(string[] args)
        {
            string path = "../../../../test.txt";
            int[] nums = new int[10];
            Random rand = new Random();

            using (StreamWriter sq = new StreamWriter(path))
            {
                for(int i = 0; i < 10; i++)
                {
                    sq.Write(rand.Next(10) + " ");
                }
            }

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                   while ((line = sr.ReadLine()) != null)
                    {   
                        string[] numbers = line.Split(' ');
                        for(int i = 0; i < numbers.Length; i++)
                        {
                            nums[i] = Int32.Parse(numbers[i]);
                        }
                        //Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            for(int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine("nums[{0}] = {1}",i,nums[i]);
            }

            //========== Binary .bin file read/write ================
            string binPath = "../../../../bin_test.bin";
            int i2 = 100;
            double d = 3.14;
            bool b = true;
            string s = "string";
            BinaryWriter bw;
            BinaryReader br;

            try
            {
                bw = new BinaryWriter(new FileStream(binPath, FileMode.Open));
                bw.Write(i2);
                bw.Write(d);
                bw.Write(b);
                bw.Write(s);
                bw.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("exception when opening bin file: " + ex);
            }

            try
            {
                br = new BinaryReader(new FileStream(binPath, FileMode.Open));
                int i3 = br.ReadInt32();
                Console.WriteLine("i = " + i3);
                double d2 = br.ReadDouble();
                Console.WriteLine("d = " + d2);
                bool b2 = br.ReadBoolean();
                Console.WriteLine("b = " + b2);
                string s2 = br.ReadString();
                Console.WriteLine("s = " + s2);

            } catch(Exception ex)
            {
                Console.WriteLine("Exception in binary read " + ex.Message);
            }

            // =========== dat file  ===============
            string datPath = "../../../../bin2.dat";
            FileStream fs = new FileStream(datPath, FileMode.Open, FileAccess.ReadWrite);

            //write to dat file
            for(int i = 0; i < 10; i++)
            {
                fs.WriteByte((byte)i);
            }
            fs.Position = 0;
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("reading byte: " + fs.ReadByte());
            }
            fs.Close();


            //============= DirectoryInfo and FileInfo ====================

            string dirPath = @"C:\Users\Ben\Documents\c# tutorial\CSharp tutorial";
            DirectoryInfo dir = new DirectoryInfo(dirPath);

            FileInfo[] files = dir.GetFiles();
            foreach(FileInfo file in files)
            {
                Console.WriteLine("Filename: {0}, File size: {1}", file.Name, file.Length);
            }

            //create a directory
            DirectoryInfo newDir = new DirectoryInfo(dirPath + "\\newDir");
            newDir.Create();

            //create new file
            string newFilePath = dirPath + "\\newDir\\" + "newfile.txt";
            FileInfo newFile = new FileInfo(newFilePath);
            if (!newFile.Exists)
            {
                newFile.Create();
            }

            //write to file
            using(StreamWriter sw = new StreamWriter(newFilePath, true))
            {
                for(int i = 0; i < 10; i++)
                {
                    sw.Write(i + " ");
                }
                sw.WriteLine("End file");
            }

            //delete file
            //newFile.Delete();
        }
    }
}
