using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using arr = InterviewPreparation.ArraysStrings;
using InterviewPreparation.DataStructures;
using InterviewPreparation.Problems;
using static System.Console;
using System.Collections;

namespace InterviewPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree_S theTree = new Tree_S();
            theTree.Insert(20);
            theTree.Insert(25);
            theTree.Insert(45);
            theTree.Insert(15);
            theTree.Insert(67);
            theTree.Insert(43);
            theTree.Insert(16);
            theTree.Insert(80);
            theTree.Insert(33);
            theTree.Insert(67);
            theTree.Insert(19);
            theTree.Insert(9);
            theTree.Insert(99);
            theTree.Insert(91);
            theTree.Insert(23);
            theTree.Insert(14);
            theTree.Insert(17);
            Console.WriteLine("Inorder Traversal : ");
            theTree.Inorder(theTree.root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Traversal : ");
            theTree.Preorder(theTree.root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal : ");
            theTree.Postorder(theTree.root);
            Console.WriteLine(" ");
            Console.ReadLine();

            CustomQueue<int> st = new CustomQueue<int>();
            st.enqueue(1);
            st.enqueue(2);
            st.enqueue(3);
            st.enqueue(4); 
            st.enqueue(5);
            st.enqueue(6);
            st.dequeue();

            //st.POP();
           // st.POPAT(4);

            var sss = arr.StringProblems.FindSubstringIndex("Shrisar prasad", "s!a");

            BinaryTreeV0<int> bTree = new BinaryTreeV0<int>(10);
            bTree.Insert(12);
            bTree.Insert(5);
            bTree.Insert(1);
            bTree.Insert(45);
            bTree.Insert(6);
            bTree.Insert(23);
            bTree.Insert(2);
            bTree.Insert(8);
            bTree.Insert(11);
            bTree.Insert(81);

            bTree.walkTree();
            Console.WriteLine();

            //Console.WriteLine("the binary tree is " + (bTree.isBalanced() ? "" : "not ") + "Balanaced");

            //Console.WriteLine("the binary tree " + (bTree.contains(15) ? "contains" : "does not contain") + " 15");

            bTree.remove(5);
            bTree.walkTree();

            var sssssss33 = arr.DynamicProgramming.LongestPalindromeSubstringEasy("BBABCBCAB");

            BinaryTree<int> btree = new BinaryTree<int>();
            btree.Insert(1);
            btree.Insert(20);
            btree.Insert(30);
            btree.Insert(4);
            btree.Insert(5);
            btree.Insert(6);
            btree.Insert(7);
            btree.Insert(80);
            btree.Insert(9);
            btree.Insert(10);
            btree.Insert(11);

            LinkedList_New node1 = new LinkedList_New();
            //var scc1 = node1.nodeCount();
            //node1.append(new Node(100));
            //node1.append(1);

            //node1.append(3);
            //scc1 = node1.nodeCount();
            ////node1.delete(10);
            //node1.append(1);
            //node1.append(2);
            //node1.deleteNode(node1.FindNthToLastElement(node1.head, 2));
            //scc1 = node1.nodeCount();
            //node1.delete(4);
            //node1.delete(1);
            //scc1 = node1.nodeCount();
            //node1.append(20);
            //scc1 = node1.nodeCount();
            ////node1.remove_duplicates();
            //node1.append(11);
            //node1.append(2);
            //node1.append(12);
            //node1.append(4);
            //node1.append(4);
            //scc1 = node1.nodeCount();
            //node1.remove_duplicates();
            //scc1 = node1.nodeCount();

            var noder1= node1.FindNthToLastElement(node1.head, 4);

            var SpecialChar2 = arr.ArrayAndString.reversestringwithoutSpecialChar2();

            var seeg = arr.ArrayAndString.Segregate0sonleftsideand1sonrightsideofthearray(new int[] { 0, 1, 0, 1, 0, 0, 1, 1, 1, 0 });

            var s1211 = arr.ArrayAndString.findPairSum_unSorted(new int[] { 40, 29, 10, 2, 50, 10, 100 }, 12);
            var ss1311 = s1211;

            var result42 = arr.ArrayAndString.getMaxOccuringChar("stopppwwas");
            String str = "a,b$c";
            char[] charArray = str.ToCharArray();

            var result4344 = arr.ArrayAndString.reversestringwithoutSpecialChar(charArray);

            var s121 = arr.ArrayAndString.findPairDifference(new int[] { 9, 29, 10, 2, 50, 24, 100 }, 50);
            var ss131 = s121;
            
            var s12 = arr.ArrayAndString.MergeTwoSortedArraysIntoOneSortedAArray(new int[] { 1, 5, 7, 12, 18, 32 }, new int[] { 2, 4, 9, 16, 27, 76, 98 });
            var ss13 = s12;

            int[] num1 = new int[] { 102, 5, 7, 9, 12, 15, 21, 25, 30, 34, 1, 1, 2, 39, 45, 45, 55 };
            var cs = arr.StringProblems.GetMaximumConsecutiveRepeatingCharacter("aaaaabbcbbbbbbcbbbbfffffff");

            char[,] carr = new char[3, 3];

            carr[0, 0] = 'X';
            carr[0, 1] = 'O';
            carr[0, 2] = 'X';

            carr[1, 0] = 'X';
            carr[1, 1] = 'X';
            carr[1, 2] = 'O';

            carr[2, 0] = 'O';
            carr[2, 1] = 'X';
            carr[2, 2] = 'X';

            var tictac = arr.StringProblems.ValidTicTacToe(carr, 'X', 'O');
            var ssss = arr.ArrayAndString.FinalSum(new int[] { 1, 5, 7, 9, 10, -1, -2, -3, 20 });
            var s1210 = arr.ArrayAndString.findPairDifference(new int[] { 9, 29, 10, 2, 50, 24, 100 }, 40);
            var s1212 = arr.ArrayAndString.LargestSumContiguousSubarray(new int[]{ -2, -3, 4, -1, -2, 1, 5, -3});
            
            var test22 = arr.StringProblems.CheckParenthesis("[(])");

            LinkedList_New node = new LinkedList_New();
            var scc= node.nodeCount();
            node.append(10);
            node.delete(10);
            node.append(20);
            node.append(20);
            node.append(20);
            node.append(6);
            node.append(7);
            node.append(5);
            node.append(30);
            node.append(30);
            scc = node.nodeCount();
            node.preappend(5);
            scc = node.nodeCount();
            node.remove_duplicates();
            scc = node.nodeCount();
            
           
            //string sample1 ="Amit singh";
            
            //var ssssss =arr.StringProblems.ReverseWords(sample1); ;

            
           
            //var sssss =arr.StringProblems.FibonacciSequence(8);
            //var sample1 = sssss;
            //int min = 0;
            //int max = num1.Length - 1;
            //var re = arr.ArrayAndString.BinarySearchIterativeSorted_Recursive(num1, 34, min, max);
            //var re1 = re;

            //Sorting s12 = new Sorting();
            //s12.mergeSortRecursive(num1);

            var testre = arr.StringProblems.FindAndSecondMinimumElement(num1);
            var res = testre;

            /*
            Console.WriteLine("revsrse words in A boy named amar: " + StringProblems.reverseWordsString("A boy named amar"));
            */
            /*
            Console.WriteLine("asdff" + " is a string with unique characters: " + StringProblems.hasUniqueCharacters("asdff").ToString());
            Console.WriteLine("asdf and dsaf" + " are permutations of each other: " + StringProblems.isPermutation_WithSort("asdf", "dsaf").ToString());
            Console.WriteLine("asdf and dsaf" + " are permutations of each other: " + StringProblems.isPermutation_WithOutSort("asdf", "dsaf").ToString());

            char[] c = new char[12];
            c[0] = 'a';
            c[1] = 's';
            c[2] = ' ';
            c[3] = 'd';
            c[4] = ' ';
            c[5] = 'f';
            Console.WriteLine(" After spaces are replaced in " + c + " : " + StringProblems.replaceSpaces(c, 6));
            Console.WriteLine("Compress string aabccda: " + StringProblems.compressString("aaa"));

            int[,] m = new int[,] { { 1, 0, 1, 1, 1 }, { 1, 0, 1, 1, 1 }, { 0, 1, 1, 1, 1 } };
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("replace 0s" );
            StringProblems.setMatrixRowColumnZeros(m);
            Console.WriteLine();

            int[,] m1 = new int[,] { { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 }, { 1, 2, 3, 4, 5 } };
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m1.GetLength(1); j++)
                {
                    Console.Write(m1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("replace 0s");
            StringProblems.rotateMatrix180(m1, 5);
            */

            //LinkedList lList = new LinkedList();
            //LinkedList lList1 = new LinkedList();
            //LinkedList lList2 = new LinkedList();


            //lList1.insert(1);
            //lList1.insert(2);
            //lList1.insert(3);
            //lList1.insert(4);
            //lList1.insert(5);
            ////Node n = new Node(6);
            ////lList1.insert(n);

            //lList1.insert(5);
            ////lList1.insert(4);
            //lList1.insert(3);
            //lList1.insert(2);
            //lList1.insert(1);

            //Node n1 = new Node(11);
            //n1.Next = n;

            //lList1.insert(n1);

            //lList.printAll();
            //lList1.printAll();

            //Console.WriteLine(lList.deleteNode(lList.kthElementFromLast(0)));
            //lList.partitionX(lList.head, 10);
            //lList.print(lList.addLists(lList.head, lList1.head, 0));
            //lList.printAll();

            //lList2.addListsInReverse(lList.head, lList1.head, null);
            //lList2.printAll();

            //Console.WriteLine(lList1.hasLoop(lList1.head).Value);

            //Console.WriteLine("List id Palindrome" + lList1.isPalindromeRecursive());

            //DataStructures.Stack<int> st = new DataStructures.Stack<int>();

            /*
            SetOfStacks st = new SetOfStacks(5);

            st.push(1);
            st.push(2);
            st.push(3);
            st.push(4);
            st.push(5);
            st.push(6);
            st.push(7);
            st.push(8);
            st.push(9);
            st.push(10);
            st.push(11);
            st.push(12);
            st.push(13);
            st.push(14);
            st.push(15);
            st.push(16);
            st.push(17);
            st.push(18);

            Console.WriteLine(st.pop().data);

            Console.WriteLine(st.popAt(5).data);

            Console.WriteLine(st.pop().data);

            */

            /*
            TowersOfHanoi toh = new TowersOfHanoi(5);
            toh.towers[0].print();
            toh.moveDisks(5, toh.towers[0], toh.towers[2], toh.towers[1]);
            toh.towers[0].print();
            


            char[] word = new char[] { 'c', 'a', 't' };
            JumbleWords jw = new JumbleWords(word);
            Console.WriteLine("Word locs: " + jw.findWords(word).ToString());


            
            BinaryTreeV0<int> bTree = new BinaryTreeV0<int>(10);
            bTree.Insert(12);
            bTree.Insert(5);
            bTree.Insert(1);
            bTree.Insert(45);
            bTree.Insert(6);
            bTree.Insert(23);
            bTree.Insert(2);
            bTree.Insert(8);
            bTree.Insert(11);
            bTree.Insert(81);

            bTree.walkTree();
            Console.WriteLine();

            //Console.WriteLine("the binary tree is " + (bTree.isBalanced() ? "" : "not ") + "Balanaced");

            //Console.WriteLine("the binary tree " + (bTree.contains(15) ? "contains" : "does not contain") + " 15");

            bTree.remove(5);
            bTree.walkTree();
            */
            /*
            Graph<string> air = new Graph<string>(null);
            air.addNode("NY");
            air.addNode("DE");
            air.addNode("LA");
            air.addNode("SF");
            air.addNode("CH");
            air.addNode("MI");
            air.addNode("DA");
            air.addNode("SD");

            air.addDirectedEdge(air.getNode("NY"), air.getNode("MI"), 90);
            air.addDirectedEdge(air.getNode("NY"), air.getNode("DA"), 125);
            air.addDirectedEdge(air.getNode("NY"), air.getNode("CH"), 75);
            air.addDirectedEdge(air.getNode("NY"), air.getNode("DE"), 100);
            air.addDirectedEdge(air.getNode("CH"), air.getNode("SF"), 25);
            air.addDirectedEdge(air.getNode("CH"), air.getNode("DE"), 20);
            air.addDirectedEdge(air.getNode("SF"), air.getNode("LA"), 45);
            air.addDirectedEdge(air.getNode("SD"), air.getNode("LA"), 45);
            air.addDirectedEdge(air.getNode("DA"), air.getNode("SD"), 90);
            air.addDirectedEdge(air.getNode("DA"), air.getNode("LA"), 80);
            air.addDirectedEdge(air.getNode("MI"), air.getNode("DA"), 50);
            air.addDirectedEdge(air.getNode("DE"), air.getNode("SF"), 75);
            air.addDirectedEdge(air.getNode("DE"), air.getNode("LA"), 100);

            ShortestPath sp = new ShortestPath(air);
            sp.buildTables("NY", "LA");
            */

            /*
            BSTFromSortedArray bst = new BSTFromSortedArray();

            int[] arr = new int[] { 1, 3, 5, 6, 8, 12, 13, 23, 24, 35, 45, 46, 64 };
            bst.createMinBSTFromArray(arr);

            bst.head.walkTree();
            */

            /*
            BinarySearchTree<int> bTree = new BinarySearchTree<int>();
            bTree.Insert(12);
            bTree.Insert(5);
            bTree.Insert(1);
            bTree.Insert(45);
            bTree.Insert(6);
            bTree.Insert(23);
            bTree.Insert(2);
            bTree.Insert(8);
            bTree.Insert(11);
            bTree.Insert(81);

            BinarySearchTree<int> bTree1 = new BinarySearchTree<int>();
            bTree1.Insert(12);
            bTree1.Insert(5);
            bTree1.Insert(1);
            bTree1.Insert(45);
            bTree1.Insert(6);
            bTree1.Insert(23);
            bTree1.Insert(2);
            bTree1.Insert(8);
            bTree1.Insert(11);
            bTree1.Insert(81);

            //bTree.InorderTraversal(bTree.head);
            //Console.WriteLine();

            //Console.WriteLine("the binary tree is " + (bTree.isBalanced() ? "" : "not ") + "Balanaced");

            //Console.WriteLine("the binary tree " + (bTree.contains(81) ? "contains" : "does not contain") + " 11");

            //bTree.remove(5);
            //bTree.BFSTraversal();
            //bTree.LevelOrderTraversal();
            //bTree.InorderTraversal(bTree.head);

            //SubTree<int> sbTree = new SubTree<int>();
            //Console.WriteLine("bTree1 is " + (sbTree.containsTree(bTree.head, bTree1.head) ? "" : "not ") + "a subtree of bTree");

            //CommonAncestorBT<int> cABT = new CommonAncestorBT<int>();

            Console.WriteLine("Common ancestor of 2 and 8 is " + (bTree.commonAncestor(bTree.head, 2, 81).data) );
            */

            //BinaryTree<int> bTree = new BinaryTree<int>();

            /*
            BinaryTreeInt bTree = new BinaryTreeInt();
            bTree.Insert(1);
            bTree.Insert(2);
            bTree.Insert(3);
            bTree.Insert(4);
            bTree.Insert(5);
            bTree.Insert(6);
            bTree.Insert(7);
            bTree.Insert(8);
            bTree.Insert(9);
            bTree.Insert(10);
            bTree.Insert(11);
            bTree.Insert(12);

            //bTree.BFSTraversal();

            bTree.findPaths(18);
            */

            /*
            KthValuePrimeFactorslist k = new KthValuePrimeFactorslist();
            Console.WriteLine("kth valus inlist with only 3, 5, 7 as primefactors is: " + k.findKthVlaue(10));
            */

            /*
            ThreeSumAndSortings ts = new ThreeSumAndSortings();
            int[] m = new int[] { -2, 5,10, 8, -6, -3, 12, -25, -10};

            List<List<int>> x = ts.threeSum(m, 5);

            if (x != null)
            {
                foreach (List<int> l in x)
                {
              
            Console.WriteLine("->" + l[0] +","+ l[1] + "," + l[2]);
                }
            }
            */

            /*
            TelephoneNumberPrint t = new TelephoneNumberPrint();
            t.printTelephoneNumbers(new int[] { 4,2,5,9,5,2,9,7,9,8});

            */

            /*
            Trie t = new Trie();
            t.insert("abc");
            t.insert("ab");
            t.insert("abcd");
            */

            //Console.WriteLine("teet er: "+ StringProblems.findFirstNonRepeatedChar("teete r rk x k"));

            //Console.WriteLine("amarender - mar " + "-"  + StringProblems.removeSpecifiedCharsfromString("amarender", "mar") + "-");

            //Console.WriteLine(StringProblems.convertStringToInt("-7567"));

            //StringProblems.permute("abcd");
            //StringProblems.combinations("abcd");

            //NoOfIslands islands = new NoOfIslands();
            //Console.WriteLine("No of Islands: " + islands.countIslands());

            //Console.WriteLine("num to be devided to make: 392 perfect Square is: " + StringProblems.numtoDevideToPerfectSquare(392));

            //Console.WriteLine("Longest Common substring for  " + StringProblems.longestCommonSubstring("ancestor","ancer"));

            //Console.WriteLine("Longest palindrome substring for  " + StringProblems.longestPalindrome("ABCBAHELLOHOWRACECARAREYOUILOVEUEVOLIIAMAIDOINGGOOD"));

            /*
            SortStackUsingStack s = new SortStackUsingStack();
            s.printStack(s.sortStack());
            */

            /*
            AncestorsOfNodeInTree at = new AncestorsOfNodeInTree();
            at.head = new TNode(1);
            at.head.addChild(2);
            at.head.addChild(3);
            at.head.addChild(4);

            at.head.children[0].addChild(8);
            at.head.children[0].addChild(9);

            at.head.children[1].addChild(6);

            at.head.children[2].addChild(5);
            at.head.children[2].addChild(7);

            at.head.children[1].children[0].addChild(10);

            at.printAncestors(at.head, 9);
             */

            /*
            Graph<string> air = new Graph<string>(null);
            air.addNode("A");
            air.addNode("B");
            air.addNode("C");
            air.addNode("D");
            air.addNode("E");
            air.addNode("F");
            air.addNode("X");
            air.addNode("Y");
            air.addNode("Z");
            air.addNode("L");
            air.addNode("M");
            air.addNode("N");
            air.addNode("O");
            air.addNode("P");

            air.addUndirectedEdge(air.getNode("A"), air.getNode("B"), 90);
            air.addUndirectedEdge(air.getNode("A"), air.getNode("C"), 125);
            air.addUndirectedEdge(air.getNode("X"), air.getNode("Y"), 75);
            air.addUndirectedEdge(air.getNode("X"), air.getNode("Z"), 100);
            air.addUndirectedEdge(air.getNode("Z"), air.getNode("L"), 25);
            air.addUndirectedEdge(air.getNode("Z"), air.getNode("M"), 20);
            air.addUndirectedEdge(air.getNode("M"), air.getNode("N"), 45);
            air.addUndirectedEdge(air.getNode("M"), air.getNode("O"), 45);
            air.addUndirectedEdge(air.getNode("M"), air.getNode("P"), 90);
            air.addUndirectedEdge(air.getNode("D"), air.getNode("E"), 80);
            air.addUndirectedEdge(air.getNode("D"), air.getNode("F"), 50);

            Console.Write("X & F are " + (air.DFS(air.getNode("X"), "F")? "": "NOT ") + "related");
            */

            //Sorting s = new Sorting();
            //int[] arr = new int[] { 3, 4, 2, 6, 0, 79, 23, 65, 5};
            //s.mergeSortRecursive(arr);

            //s.quickSorting(arr);
            //s.RadixSort(arr);

            //Console.WriteLine("Min edit Distance of saturday & friday is: " + DynamicProgramming.MinEditDistanceDP("saturday", "friday", 8, 6));

            int[,] c = new int[,] { { 3, 4, 2 },
                                    { 6, 1, 9 },
                                    { 2, 6, 5 } };

            //Console.WriteLine("Min const path is: " + DynamicProgramming.minCostPathinMatrixDP(c, 2, 2));

            //Console.WriteLine("rain water trapped: " + DynamicProgramming.rainWaterTrapped(new int[] { 0, 2, 6,1,5,4,2,0,1,5,6, 4,1 }));

            //Console.WriteLine("coin chnage probs for 10: " + DynamicProgramming.coinChangeDP(new int[] { 5, 4, 3, 2, 1 }, 10));

            //int x = StringProblems.longestIncreasinSequence(new int[] { 30, 10, 22, 9, 33, 21, 50, 41, 60, 75, 43, 56, 60 });
            //int y = StringProblems.longestCommonSequence("ABCDEFG", "BCDGK");

            //Console.WriteLine("LIS of {10, 22, 9, 33, 21, 50, 41, 60}" + y);


            //Console.WriteLine("binomial cofficients of c(4,3): " + DP.binomialCoefficients(4,3));

            //int[] v = new int[]{60, 100, 120};
            //int[] w = new int[]{10, 20, 30};
            //int  wt = 50;
            //Console.WriteLine("Max val in knapsack: " + DP.knapsackDP(v, w, wt, v.Length));

            //Console.WriteLine("Max val in knapsack: " + DP.eggDropTrials(2, 36));
            //Console.WriteLine("Lenth of lonest palin subsequence: " + DP.LongPalinSubSeqDP("GEEKSFORGEEKS"));

            /*
            BinarySearchTree<int> bTree1 = new BinarySearchTree<int>();
            bTree1.Insert(12);
            bTree1.Insert(5);
            bTree1.Insert(1);
            bTree1.Insert(45);
            bTree1.Insert(6);
            bTree1.Insert(23);
            bTree1.Insert(2);
            bTree1.Insert(8);
            bTree1.Insert(11);
            bTree1.Insert(81);

            bTree1.morrisTravesrsal(bTree1.head);
            */

            //List<string> cs = StringProblems.getConsecutiveLettersinString("BCCDE");

            /*
            int[,] m = new int[7, 7] { 
                                        { 1, 2, 3, 4, 5, 6, 7 }, 
                                        { 1, 2, 3, 4, 5, 6, 7 }, 
                                        { 1, 2, 3, 4, 5, 6, 7 }, 
                                        { 1, 2, 3, 4, 5, 6, 7 }, 
                                        { 1, 2, 3, 4, 5, 6, 7 }, 
                                        { 1, 2, 3, 4, 5, 6, 7 },
            { 1, 2, 3, 4, 5, 6, 7 }};

            StringProblems.printMatrixSpirally(m, 7, 7);
             * */
            /*
            MaxPointsOnALine m = new MaxPointsOnALine();
            Point[] pts = new Point[]{new Point(1, 1),new Point(0, 0), new Point(1, 1),new Point(2, 2),new Point(3, 3),new Point(3, 4)};

            int x = m.getMaxPointsonLine(pts);
            */

            /*
            WordDictionary wd = new WordDictionary();
            wd.AddWord("amar");
            wd.AddWord("amarender");
            bool f = wd.Search("ama.");
            */

            /*
            Twitter twr = new Twitter();

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1*i; j < 30; j= j+i)
                {
                    twr.postTweet(i, j);
                }
            }

            twr.follow(3, 1);
            twr.follow(3, 2);
            twr.follow(3, 4);
            twr.follow(3, 5);

            twr.getNewsFeed(3);
            */

            //int x = StringProblems.maxProductSubArray(new int[]{2,3,-2,4, -1, -1, 0, 8,3});

            //string s = StringProblems.removeKDigitsForLeastValue("1410219", 9);

            //int x = MinCoinChange.getMinCoinChange(new int[1], 3);

            //int[] x = Solution.getMinimumUniqueSum(new string[] { "3 9", "17 23" });

            //string s = Solution.getLexNextString("dkhc");

            //DynamicProgramming.DynamicProgramming dp = new DynamicProgramming.DynamicProgramming();

            ////dp.Lis();
            //DynamicProgramming.DynamicProgramming.MinCostPathRecursive();
            //Console.Read();


            //var result = StringProblems.IsAnagram("stop", "opts");
            //result = StringProblems.IsAnagram("sit", "sitt");
            //result = StringProblems.IsAnagram("sit", "sif");
            //result = StringProblems.IsAnagram("Sit", "tis");

            //var result = StringProblems.BubbleSort(new int[]{1, 4, 9, 3, 2, 8, 7});  
            //redivider, deified, noon, civic, radar, level, rotor, kayak, reviver, racecar, redder, madam, and refer
            // var result = arr.StringProblems.longestPalindrome("noon");
            //var result1 = DynamicProgramming.LongPalinSubSeq("BBABCBCAB");
            //var result2 = arr.DynamicProgramming.LongPalinSubSeqDP("BBABCBCAB");
            var sssssss = arr.DynamicProgramming.LongestPalindromeSubstringEasy("BBABCBCAB");
            //print wave pattern of a given string
            var result3 = arr.StringProblems.hasSubstringPattern("abcbcglx", "bcglx");
            ////////////////////////////////////////////////
            string s = "Hellow world!";
            int n = 3;
            var result3Getfun = arr.StringProblems.PrintWavePattern(s, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    Write(result3Getfun[i, j]);
                    Write(" ");
                }
                WriteLine();
            }
            /////////////
            var GCDResult = arr.StringProblems.ReverseWords("My name is Archit Patel");
            var Fib = arr.StringProblems.Fib(6);
            //arr.StringProblems.GetCharacters("mynameisarchitpatel");
            arr.StringProblems.PrintLettersInSortedOrder("shridharPrasad");
            //int[] arr1 = { 5, 7, 1, 2, 3, 3, 3, 4 };
            //int[] arr1 = { 1, 2, 3, 4, 5, 9, 16, 18, 20, 25, 26 };
            int[] arr1 = { 4, 5, 9, 16, 1, 2, 3, 18, 20, 25, 26 };
            //int[] arr1 = { 1, 0, 1, 1 };
            int[] a123 = arr.StringProblems.Findstartend(arr1, 2);
            var result11 = arr.StringProblems.FindDistinctIndices(arr1, 3);
            var result12 = arr.StringProblems.FindAndSecondMinimumElement(arr1);
            var result13 = arr.StringProblems.BinarySearchIterative(arr1, 2);
            var result14 = arr.ArrayAndString.HasuniqueCharacters("abcdef");
            var result1 = arr.ArrayAndString.ReverseString("1234567890 abcdefghij".ToCharArray(), 2, 6);
            var result2 = arr.ArrayAndString.RemoveDuplicateChar("aacaacdr");
            var result4 = arr.ArrayAndString.IsAnagrams("stops", "spots");
            var result5 = arr.ArrayAndString.ReplaceSpaces("Shridhar Prasad Rajeeev   Prasad");
            int[,] a = { { 0, 0, 0, 0, 0 }, { 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2 }, { 3, 3, 3, 3, 3 }, { 4, 4, 4, 4, 4 } };
            int[,] b = { { 1, 0, 0, }, { 1, 1, 1 }, { 1, 0, 1 } };
            //arr.ArrayAndString.rotateMatrix_90(a,3);
            //Console.WriteLine();
            //arr.ArrayAndString.rotateMatrix90WithLAyer(a, 3);
            arr.ArrayAndString.setZeros(b);
            var result6 = arr.ArrayAndString.isRotation("shridhar", "idharshr");

            /////////MyLinkedList/////////////
            //MyLinkedList node = new MyLinkedList();
            //node.append(10);
            //node.append(5);
            //node.append(15);
            //node.append(20);
            //node.delete(5);
            //Console.Write(node.nodeCount());
            int[] input = { 5, 4, 1, 9, 2 };
            var ss = arr.StringProblems.SmallestInt(input);
            var test1 = arr.StringProblems.isPermutation_WithOutSort("abcdad", "abcdad");
            var test2 = arr.StringProblems.BubbleSort(input);
            Console.WriteLine(arr.StringProblems.convertStringToInt("-7567"));
        }
    }
}
