using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FacadePattern
{
    class FileReader
    {
        public string Read(string FileNameSrc)
        {
            Console.WriteLine("读取文件，获取明文：");
            FileStream fs = null;
            StringBuilder sb = new StringBuilder();
            fs = new FileStream(FileNameSrc, FileMode.Open);
            int data;
            while ((data = fs.ReadByte()) != -1)
            {
                sb = sb.Append((char)data);
            }
            fs.Close();
            Console.WriteLine(sb.ToString());
            return sb.ToString();

        }
    }

    class CipherMachine
    {
        public string Encrypt(string plaintext)
        {
            Console.WriteLine("数据加密，将明文转化为密文：");
            string str = " ";
            char[] chars = plaintext.ToCharArray();
            foreach(char ch in chars)
            {
                string s = (ch % 8).ToString();
                str += s;

            }
            Console.WriteLine(str);
            return str;
        }
    }

    class FileWriter
    {
        public void Write(string encryptStr,string filename)
        {
            Console.WriteLine("保存密文，写入文件：");
            FileStream fs = null;
            fs = new FileStream(filename, FileMode.Create);
            byte[] str = Encoding.Default.GetBytes(encryptStr);
            fs.Write(str, 0, str.Length);
            fs.Flush();
            fs.Close();

        }
    }


    class EncryptFacade
    {
        //维持对其他对象的引用
        private FileReader reader;
        private CipherMachine cipher;
        private FileWriter writer;
 
        public EncryptFacade()
        {
            reader = new FileReader();
            cipher = new CipherMachine();
            writer = new FileWriter();
        }
        //调用其他对象的业务方法
        public void FileEncrypt(string fileNameSrc, string fileNameDes)
        {
            string plainStr = reader.Read(fileNameSrc);
            string encryptStr = cipher.Encrypt(plainStr);
            writer.Write(encryptStr, fileNameDes);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EncryptFacade ef = new EncryptFacade();
            ef.FileEncrypt("src.txt", "des.txt");
            Console.Read();
        }
      
        

      
    }
}
