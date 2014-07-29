using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordEncoder
{
    public static class WordTreeBuilder
    {
        public static WordNode BuildTree(string[] wordList)
        {
            uint level = 0;
            WordNode rootNode = null;
            Queue<string> wordQueue = new Queue<string>(wordList);
            List<WordNode> assignedWords = new List<WordNode>();
            string word = wordQueue.Dequeue();
            while (word != null)
            {
                if (rootNode == null)
                {
                    rootNode = new WordNode(null, word, level);
                    assignedWords.Add(rootNode);                    
                }
                else
                {
                    foreach (WordNode node in assignedWords.Where(s => s.Level == level).ToList())
                    {
                        if (wordQueue.Count > 0)
                        {
                            node.Left = new WordNode(node, wordQueue.Dequeue(), level + 1);
                            assignedWords.Add(node.Left);
                        }
                        if (wordQueue.Count > 0)
                        {
                            node.Right = new WordNode(node, wordQueue.Dequeue(), level + 1);
                            assignedWords.Add(node.Right);
                        }
                    }
                    level++;
                }
                word = (wordQueue.Count > 0) ? wordQueue.Dequeue() : null;
            }
            return rootNode;
        }
    }
}
