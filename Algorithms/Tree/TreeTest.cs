using Algorithm.Algorithms.Tree;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms
{
    /// <summary>
    /// 
    /// Algorithm.Algorithms.Tree
    /// </summary>
    public class TreeTest
    {

        public static int Solution()
        {
            int answer = 0;

            Tree<int> tree = new Tree<int>();
            tree.rootNode = new TreeNode<int>(1);
            tree.rootNode.AppendChild(new TreeNode<int>(2));
            tree.rootNode.AppendChild(new TreeNode<int>(3));
            tree.rootNode.AppendChild(new TreeNode<int>(4));
            tree.rootNode.GetChild(0).AppendChild(new TreeNode<int>(5));
            tree.rootNode.GetChild(0).AppendChild(new TreeNode<int>(6));
            tree.rootNode.GetChild(1).AppendChild(new TreeNode<int>(7));
            tree.rootNode.GetChild(1).AppendChild(new TreeNode<int>(8));
            tree.rootNode.GetChild(2).AppendChild(new TreeNode<int>(9));


            Console.WriteLine(tree.GetSize());
            tree.PrintTree();

            return answer;
        }
    }
}
