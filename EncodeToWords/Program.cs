using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordEncoder;

namespace EncodeToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] wordList = File.ReadAllLines(@"..\..\..\corncob_lowercase.txt");
            //string[] wordList = File.ReadAllLines(@"..\..\..\mwords\354984si.ngl");
            string[] wordList = File.ReadAllLines(@"..\..\..\mwords\74550com.mon");            
            List<string> allWords = new List<string>();
            allWords.AddRange(wordList);
            allWords.AddRange(File.ReadAllLines(@"..\..\..\mwords\21986na.mes"));
            allWords.AddRange(File.ReadAllLines(@"..\..\..\mwords\10196pla.ces"));

            allWords.OrderByDescending(s => s.Length);
            //Where(s => s.Length < 10).
            WordNode rootNode = WordTreeBuilder.BuildTree(allWords.ToArray());
            Random random = new Random();
            byte[] randomBytes = new byte[20];
            random.NextBytes(randomBytes);
            //randomBytes = Encoding.ASCII.GetBytes("A375B3ABD922257532A855947AAF115D4FF770D2");
            Console.WriteLine("Bytes: " + Convert.ToBase64String(randomBytes));
            List<string> results = rootNode.EncodeToWords(randomBytes);
            foreach (string word in results)
            {
                Console.WriteLine(word);
            }
        }
    }
}
