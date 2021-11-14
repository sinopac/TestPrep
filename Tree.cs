using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static class Tree
    {
        /// <summary>
        /// https://leetcode.com/problems/same-tree/
        /// </summary>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p != null && q != null && p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/symmetric-tree/
        /// </summary>
        public static bool IsSymmetric(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return true;

            if (root.left != null && root.right == null)
                return false;

            if (root.left == null && root.right != null)
                return false;

            return isMirror(root.left, root.right);
        }

        private static bool isMirror(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;

            if (p != null && q != null && p.val == q.val)
            {
                return isMirror(p.right, q.left) && isMirror(p.left, q.right);
            }

            return false;
        }

        /// <summary>
        /// https://leetcode.com/problems/binary-tree-level-order-traversal/
        /// </summary>
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            var res = new Dictionary<int, List<int>>();
            res.Add(0, new List<int> { root.val });
            UpdateNodeCollection(res, root, 1);

            return res.Values.ToArray();
        }

        private static void UpdateNodeCollection(Dictionary<int, List<int>> res, TreeNode node, int level)
        {
            if (!res.ContainsKey(level) && (node.left != null || node.right != null))
            {
                res.Add(level, new List<int>());
            }

            if (node.left != null)
            {
                res[level].Add(node.left.val);
                UpdateNodeCollection(res, node.left, level + 1);
            }

            if (node.right != null)
            {
                res[level].Add(node.right.val);
                UpdateNodeCollection(res, node.right, level + 1);
            }
        }
    }
}