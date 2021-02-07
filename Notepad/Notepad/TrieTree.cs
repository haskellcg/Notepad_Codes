using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Notepad
{
    public class TrieTree
    {
        private BranchNode rootNode;
        private List<string> wordDic;

        public TrieTree()
        {
            this.rootNode = new BranchNode(NodeType.Root,null,null);

            wordDic = new List<string>();

            string Dic = System.Configuration.ConfigurationManager.AppSettings["Dic"];
            StreamReader fileReader = new StreamReader(Dic, Encoding.GetEncoding("gb2312"));
            while (!fileReader.EndOfStream)
            {
                string tempLine = fileReader.ReadLine();
                int FirstTabIndex = tempLine.IndexOf('\t');
                string wordInFile = tempLine.Substring(0, FirstTabIndex);
                wordInFile = wordInFile.Trim().ToLower();
                if (!wordDic.Contains(wordInFile))
                {
                    wordDic.Add(wordInFile);
                }

            }
        }

        #region  私有辅助函数
        /// <summary>
        /// 根据深度为当前分支节点添加子节点
        /// </summary>
        /// <param name="node">当前的分支节点</param>
        /// <param name="searchDepth">搜索深度,最开始是0</param>
        /// <param name="wordList">当前的所搜集合</param>
        private void BuildBranch(Node node,List<string> wordList,int searchDepth)
        {
            char searchChar='a';
            while (searchChar <= 'z')
            {
                List<string> nowList = GetGroup(wordList,searchDepth,searchChar);
                if (nowList.Count == 1)
                {
                    Node nowLeaf = new LeafNode(nowList[0],node);
                    if (node.GetFirstChildNode() != null)
                    {
                        Node tempNode = node.GetFirstChildNode();
                        while (tempNode.GetBrotherNode() != null)
                        {
                            tempNode = tempNode.GetBrotherNode();
                        }
                        tempNode.SetBrother(nowLeaf);
                    }
                    else
                        node.SetChild(nowLeaf);
                }
                else if (nowList.Count > 1)
                {
                    List<string> nextList = new List<string>();
                    foreach (string word in nowList)
                    {
                        char[] wordArray = word.ToCharArray();
                        if (searchDepth == (wordArray.Length-1))
                        {
                            Node nowLeaf = new LeafNode(word, node);
                            if (node.GetFirstChildNode() != null)
                            {
                                Node tempNode = node.GetFirstChildNode();
                                while (tempNode.GetBrotherNode() != null)
                                {
                                    tempNode = tempNode.GetBrotherNode();
                                }
                                tempNode.SetBrother(nowLeaf);
                            }
                            else
                                node.SetChild(nowLeaf);
                        }
                        else
                        {
                            nextList.Add(word);
                        }

                    }
                    if (nextList.Count > 1)
                    {
                        Node nowBranch = new BranchNode(NodeType.Branch, node, searchChar.ToString());
                        if (node.GetFirstChildNode() != null)
                        {
                            Node tempNode = node.GetFirstChildNode();
                            while (tempNode.GetBrotherNode() != null)
                            {
                                tempNode = tempNode.GetBrotherNode();
                            }
                            tempNode.SetBrother(nowBranch);
                        }
                        else
                            node.SetChild(nowBranch);
                        BuildBranch(nowBranch, nextList, searchDepth + 1);
                    }
                    else if (nextList.Count == 1)
                    {
                        Node nowLeaf = new LeafNode(nextList[0], node);
                        if (node.GetFirstChildNode() != null)
                        {
                            Node tempNode = node.GetFirstChildNode();
                            while (tempNode.GetBrotherNode() != null)
                            {
                                tempNode = tempNode.GetBrotherNode();
                            }
                            tempNode.SetBrother(nowLeaf);
                        }
                        else
                            node.SetChild(nowLeaf);
                    }
                }

                searchChar++;
            }
        }


        /// <summary>
        /// 返回字符串列表
        /// </summary>
        /// <param name="wordList">需要搜索的原列表</param>
        /// <param name="index">指定的位置</param>
        /// <param name="wordLetter">搜索的字符</param>
        /// <returns></returns>
        private List<string> GetGroup(List<string> wordList, int index, char wordLetter)
        {
            List<string> subWordList = new List<string>();
            foreach (string word in wordList)
            {
                if (index <= word.Length - 1 && word.ToCharArray()[index] == wordLetter)
                {
                    subWordList.Add(word);
                }
            }

            return subWordList;
        }

        /// <summary>
        /// 使用递归获得当前的节点的蕴含的单词
        /// </summary>
        /// <param name="node">当前节点</param>
        /// <returns></returns>
        private string GetWordValue(Node node)
        {
            if (node.GetNodeType() == NodeType.Root)
            {
                return node.GetValue();
            }

            return GetWordValue(node.GetParentNode())+node.GetValue();
        }

        /// <summary>
        /// 检测当前节点的子节点是否存在该单词
        /// </summary>
        /// <param name="node"></param>
        /// <param name="letter"></param>
        /// <returns></returns>
        private bool wordExists(Node node, string letter,int index)
        {
            Node child = node.GetFirstChildNode();
            char[] letterArray = letter.ToCharArray();
            
            while (child != null)
            {
                if (child.GetNodeType() == NodeType.Leaf)
                {
                    if (child.GetValue().Equals(letter))
                        return true;
                    else
                        child = child.GetBrotherNode();

                }
                else
                {
                    if (child.GetValue().Equals(letterArray[index].ToString()))
                        break;
                    else
                        child = child.GetBrotherNode();
                }
            }

            if (child == null)
                return false;
            else
                return wordExists(child,letter,index+1);
        }

        #endregion
        /// <summary>
        /// 建立TrieTree树   待优化
        /// </summary>
        public void BuildTree()
        {
            this.BuildBranch(rootNode,wordDic,0);
        }


        /// <summary>
        /// 传入一个字符串，检测是否在树中存在
        /// </summary>
        /// <param name="wordArray">需要检测的字符串</param>
        /// <returns>是否存在</returns>
        public bool CheckExists(string word)
        {
            return wordExists(rootNode,word,0);
        }
        
    }


    //枚举节点类型
    public enum NodeType { Root,Branch,Leaf}

    //抽象节点
    public interface Node
    {
        /// <summary>
        /// 获得该节点的第一个子节点
        /// </summary>
        /// <returns></returns>
        Node GetFirstChildNode();

        /// <summary>
        /// 获得该节点的兄弟节点
        /// </summary>
        /// <returns></returns>
        Node GetBrotherNode();

        /// <summary>
        /// 获得父节点
        /// </summary>
        /// <returns></returns>
        Node GetParentNode();

        /// <summary>
        /// 获得该节点的值
        /// </summary>
        /// <returns></returns>
        string GetValue();

        /// <summary>
        /// 获得节点类型
        /// </summary>
        /// <returns></returns>
       NodeType GetNodeType();

        /// <summary>
       /// 设置兄弟节点
        /// </summary>
        /// <param name="brother"></param>
       void SetBrother(Node brother);

        /// <summary>
       /// 设置子节点
        /// </summary>
        /// <param name="firstChild"></param>
       void SetChild(Node firstChild);

    }

    //叶节点类
    public class LeafNode:Node
    {
        private string value;
        private Node parent;
        private Node brother;

        public LeafNode(string value, Node parent)
        {
            this.value = value;
            this.parent = parent;
            this.brother = null;
        }

        public Node GetFirstChildNode()
        {
            return null;
        }

        public Node GetBrotherNode()
        {
            return this.brother;
        }

        public Node GetParentNode()
        {
            return this.parent;
        }

        public string GetValue()
        {
            return this.value;
        }

        public NodeType GetNodeType()
        {
            return NodeType.Leaf;
        }

        public void SetBrother(Node brother)
        {
            this.brother = brother;
        }

        public void SetChild(Node firstChild)
        {
 
        }
    }

    //分支节点
    public class BranchNode:Node
    {
        private NodeType type;
        private string value;
        private Node parent;
        private Node brother;
        private Node firstChild;

        public BranchNode(NodeType type,Node parent,string value)
        {
            this.value = value;
            this.parent = parent;
            this.type = type;

            this.brother = null;
            this.firstChild = null;
        }
   
        public void SetBrother(Node brother)
        {
            this.brother=brother;
        }

        public void SetChild(Node firstChild)
        {
            this.firstChild = firstChild;
        }



        public Node GetFirstChildNode()
        {
            return this.firstChild;
        }

        public Node GetBrotherNode()
        {
            return this.brother;
        }

        public Node GetParentNode()
        {
            return this.parent;
        }

        public string GetValue()
        {
            return this.value;
        }

        public NodeType GetNodeType()
        {
            return this.type;
        }
    }
}
