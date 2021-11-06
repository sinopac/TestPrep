using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MyTestPrep
{
    public class BinaryTree
    {
        public enum ErrorCodes { E1 = 1, E2 = 2, E3 = 3, E4 = 4, E5 = 5 }

        Node Root { get; set; }

        List<Node> Nodes = new List<Node>();

        List<string> Errors = new List<string>();

        public void AddNode(string data, string child)
        {
            var childNode = this.Find(child);
            var node = this.Find(data);

            if (!node.Any() && !childNode.Any())
            {
                var newNode = new Node(data);
                var newChildNode = new Node(child);
                newChildNode.ParentNode = newNode;
                newNode.ChildNodes.Add(newChildNode);

                this.Nodes.Add(newNode);
                this.Nodes.Add(newChildNode);
            }
            else if (node.Count() == 1 && !childNode.Any())
            {
                if (node.First().ChildNodes.Count == 2)
                {
                    this.Errors.Add("E3");
                }

                var newChildNode = new Node(child);
                newChildNode.ParentNode = node.First();
                this.Nodes.Add(newChildNode);
                node.First().ChildNodes.Add(newChildNode);

            }
            else if (!node.Any() && childNode.Any())
            {
                this.Errors.Add("E4");
            }
            else if (node.Any() && childNode.Any())
            {
                if (node.First().ChildNodes.Contains(childNode.First()))
                    this.Errors.Add("E2");
                else
                    this.Errors.Add("E5");
            }
        }

        public void SetRoot()
        {
            var rootNodes = this.Nodes.Where(x => x.ParentNode == null);

            if (rootNodes.Count() > 1)
                this.Errors.Add("E4");

            this.Root = rootNodes.FirstOrDefault();
        }

        public void PrintOut()
        {
            this.SetRoot();

            if (this.Errors.Any())
            {
                Console.WriteLine(this.Errors.OrderBy(x => x).First());
            }
            else
            {
                var sp = new StringBuilder();
                this.SExpression(this.Root, sp);
                Console.WriteLine(sp.ToString());
            }
        }

        private void SExpression(Node node, StringBuilder sp)
        {
            sp.Append("(");
            sp.Append(node.Data);

            foreach (var child in node.ChildNodes)
            {
                SExpression(child, sp);
            }

            sp.Append(")");
        }

        private IEnumerable<Node> Find(string data)
        {
            return this.Nodes.Where(x => x.Data == data);
        }
    }

    public class Node
    {
        public string Data { get; set; }

        public List<Node> ChildNodes = new List<Node>();

        public Node ParentNode { get; set; }

        public Node(string data)
        {
            this.Data = data;
        }
    }

    public static class BinaryTreeTest
    {
        public static void BinaryTreeVerify()
        {
            var binaryTree = new BinaryTree();

            binaryTree.AddNode("A", "B");
            binaryTree.AddNode("B", "D");
            binaryTree.AddNode("D", "E");
            binaryTree.AddNode("A", "C");
            binaryTree.AddNode("C", "F");
            binaryTree.AddNode("E", "G");

            binaryTree.PrintOut();
        }
    }
}