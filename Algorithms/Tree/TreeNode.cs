using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Algorithms.Tree
{
    public class TreeNode<T>
    {
        public T Data { get; private set; }
        public List<TreeNode<T>> Children { get; private set; }

        public TreeNode(T data)
        {
            Data = data;
            Children = new List<TreeNode<T>>();
        }

        public void AppendChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            if(index < Children.Count)
            {
                return Children[index];
            }
            else
            {
                return null;
            }
        }

        public bool RemoveChild(TreeNode<T> child)
        {
            return Children.Remove(child);
        }
    }
}
