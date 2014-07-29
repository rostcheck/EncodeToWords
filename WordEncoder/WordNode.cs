using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordEncoder
{
    /// <summary>
    /// One node in the tree. Each node represents a series of left/right turns
    /// (1s and 0s) defining a unique path to it, and thus a unique binary value.
    /// The node holds a word, obtained from a unique word list, as its name.
    /// </summary>
    public class WordNode
    {
        public string Name { get; set; }
        public WordNode Parent { get; set;  }
        public WordNode Left { get; set; }
        public WordNode Right { get; set; }
        public uint Level { get; set; }

        public WordNode(WordNode parent, string name, uint level)
        {
            Name = name;
            Parent = parent;
            Level = level;
        }

        public List<string> EncodeToWords(byte[] bytes)
        {
            List<string> returnList = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (byte b in bytes)
                sb.Append(Convert.ToString(b, 2));
            string bitString = sb.ToString();
            int stringIndex = 0;
            char[] bitCharArray = bitString.ToCharArray();
            WordNode currentNode = this;
            while (stringIndex++ < bitString.Length - 1)
            {
                char c = bitCharArray[stringIndex];
                WordNode nextNode = (c == '0') ? currentNode.Left : currentNode.Right;
                if (nextNode == null)
                {
                    returnList.Add(currentNode.Name);
                    currentNode = this;
                }
                else
                    currentNode = nextNode;
            }
            return returnList;
        }
    }
}
