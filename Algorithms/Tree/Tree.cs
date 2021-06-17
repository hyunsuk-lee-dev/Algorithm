using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms.Tree
{
    public class Tree<T>
    {
        public TreeNode<T> rootNode { get; set; }

        public void PrintTree() => PrintTree(rootNode);
        public int GetSize() => GetSize(rootNode);

        private void PrintTree(TreeNode<T> treeNode)
        {
            if(treeNode == null)
            {
                return;
            }

            Console.WriteLine(treeNode.Data);
            foreach(TreeNode<T> childNode in treeNode.Children)
            {
                PrintTree(childNode);
            }
        }

        private int GetSize(TreeNode<T> treeNode)
        {
            if(treeNode == null)
            {
                return 0;
            }

            int size = 1;

            foreach(TreeNode<T> childNode in treeNode.Children)
            {
                size += GetSize(childNode);
            }

            return size; 
        }
    }
}
