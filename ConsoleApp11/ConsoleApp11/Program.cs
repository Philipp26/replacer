﻿using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp11
{
    class Program
    {
        static string[] tempReplacer(string [] fileContent) =>
            fileContent
                    .Select(x => x.Replace("with (nolock)".ToUpper(), ""))
                    .Select(y => y.Replace("(nolock)".ToUpper(), ""))
                    .Select(y => y.Replace("at (nolock)", ""))
                    .Select(x => x.Replace("with (nolock)", ""))
                    .Select(y => y.Replace("(nolock)", ""))
                    .ToArray();

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(
                Environment.CurrentDirectory
                .Replace(@"\ConsoleApp11\ConsoleApp11\bin\Debug", ""));

            var files = dir.GetFiles("*.sql", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileContent = File.ReadAllLines(file.FullName, Encoding.Default);

                fileContent = tempReplacer(fileContent);

                File.WriteAllLines(file.FullName, fileContent);
            }
        }
    }
}
