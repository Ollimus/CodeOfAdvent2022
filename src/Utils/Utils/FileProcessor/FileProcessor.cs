using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.FileProcessor;

public static class FileProcessor
{
    public static string[] ReadAllLines(string filePath, string fileName = "PuzzleInput.dat")
    {
        string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));

        return input;
    }

    public static ICollection<T> ProcessFileByLine<T>(string filePath, Func<string, T> processLineResult, string fileName = "PuzzleInput.dat")
    {
        ICollection<T> result = new List<T>();

        foreach (string line in File.ReadLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
        {
            result.Add(processLineResult(line));
        }

        return result;
    }
}

