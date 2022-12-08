using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordSearch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> wordList = new List<string>();
            List<string> puzzle = new List<string>();
            Console.WriteLine(File.Exists("DATA1.txt"));
            String[] lines = File.ReadAllLines("DATA1.txt");
            String[] rowcolumns = lines[0].Split(' ');
            int rows = Int32.Parse((rowcolumns[0]));
            int columns = Int32.Parse(rowcolumns[1]);
            int wordAmountIndex = columns + 1;
            int wordCount = Int32.Parse(File.ReadAllLines("DATA1.txt")[wordAmountIndex]);
            Console.WriteLine(wordCount);
            for (int i = 0; i < columns; i++)
            {
                puzzle.Add(lines[i + 1]);
            }

            for (int i = 0; i < puzzle.Count; i++)
            {
                Console.WriteLine(puzzle[i]);
            }

            for (int i = 0; i < wordCount; i++)
            {
                wordList.Add(File.ReadAllLines("DATA1.txt")[i+2+columns]);
            }

            for (int i = 0; i < wordList.Count; i++)
            {
                Console.WriteLine(wordList[i]);
            }

            for (int i = 0; i < wordList.Count; i++)
            {
                wordList[i] = wordList[i].Replace(" ","");
            }

            for (int i = 0; i < columns; i++)
            {
                for (int t = 0; t < wordList.Count; t++)
                {
                    // Console.WriteLine(wordList[t].ToCharArray().Reverse().ToArray());
                    if (puzzle[i].ToUpper().Contains(wordList[t]))
                    {
                        for (int x = 0; x < wordList[t].Length; x++)
                        {
                            puzzle[i] = puzzle[i].Replace(wordList[t], wordList[t].ToLower());
                        }
                    }
                    if (puzzle[i].ToUpper().Contains(new String(wordList[t].ToCharArray().Reverse().ToArray())))
                    {
                        Console.WriteLine("It DOES!");
                        Console.WriteLine(wordList[t]);
                        for (int x = 0; x < wordList[t].Length; x++)
                        {
                            puzzle[i] = Regex.Replace(puzzle[i],
                                new String(wordList[t].ToCharArray().Reverse().ToArray()),
                                new String(wordList[t].ToCharArray().Reverse().ToArray()).ToLower(),RegexOptions.IgnoreCase);
                        }
                    }

                }
            }
            
            
            for (int i = 0; i < puzzle.Count; i++)
            {
                Console.WriteLine(puzzle[i]);
            }

            for (int i = 0; i < rows; i++)
            {
                string topDownString = "";
                for (int t = 0; t < columns; t++)
                {
                    topDownString += (puzzle[t][i].ToString());
                }
                for (int t = 0; t < wordList.Count; t++)
                {
                    // Console.WriteLine(wordList[t].ToCharArray().Reverse().ToArray());
                    if (topDownString.ToUpper().Contains(wordList[t]))
                    {
                        Console.WriteLine(wordList[t]);
                        for (int x = 0; x < wordList[t].Length; x++)
                        {
                            topDownString = Regex.Replace(topDownString,
                                new String(wordList[t].ToCharArray().ToArray()),
                                new String(wordList[t].ToCharArray().ToArray()).ToLower(),RegexOptions.IgnoreCase);
                        }
                    }
                    if (puzzle[i].ToUpper().Contains(new String(wordList[t].ToCharArray().Reverse().ToArray())))
                    {
                        
                        Console.WriteLine(wordList[t]);
                        for (int x = 0; x < wordList[t].Length; x++)
                        {
                            topDownString = Regex.Replace(topDownString,
                                new String(wordList[t].ToCharArray().Reverse().ToArray()),
                                new String(wordList[t].ToCharArray().Reverse().ToArray()).ToLower(),RegexOptions.IgnoreCase);
                        }
                    }

                }

                for (int x = 0; x < columns; x++)
                {
                    puzzle[x] = puzzle[x].Remove(i,1).Insert(i, topDownString[x].ToString());
                    
                }
                
            }
            
            for (int i = 0; i < puzzle.Count; i++)
            {
                Console.WriteLine(puzzle[i]);
            }
        }
        
        



        
        
    }
}