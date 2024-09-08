// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;
namespace SJPkgBuilder
{
    class Builder
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Welcome to SJPKG Builder");
            Console.WriteLine("Ver 0.0.1 Alpha");
            Console.Write("Enter Package Name: ");
            string pkgname = Console.ReadLine();
            Console.Write("Enter Github Raw File URL for your Library: ");
            string url = Console.ReadLine();
            string filename = $"{pkgname}.bat";
            string libname = $@"{pkgname}.sjl";
            string path = @$"libs\{libname}";
            string path2 = $@"Output\{filename}";

            // Package Code (Will be more fleshed out later)
            string Code = $"echo Installing {pkgname}\n@echo off\nmkdir libs\ncurl {url} -o {path}";
            Directory.CreateDirectory("Output");
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }
            File.Create(filename).Dispose();
            using (FileStream fs = File.Create(path2))
            {
                AddText(fs, Code);
            }


        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
