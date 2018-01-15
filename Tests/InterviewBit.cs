using NUnit.Framework;
using Playground.DataStructure;
using Playground.Interview;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    [Category("InterviewBit")]
    public class InterviewBit
    {
        [Test]
        public static void SetToZeroRowsColumns()
        {
            int[,] matrix = { { 0, 1, 0 }, { 2, 3, 4 }, { 5, 0, 6 } };
            ArrayQ.SetToZeroRowsColumns(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Assert.That(matrix[i, j] == 0);
                }
            }

            int[,] matrix1 = { { 0, 1, 0 }, { 2, 3, 4 }, { 5, 0, 6 } };
            ArrayQ.SetToZeroRowsColumnsTwoBools(matrix1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Assert.That(matrix1[i, j] == 0);
                }
            }
        }

        //[Test]
        //public static void MissingPositiveNumber()
        //{
        //    int[] array = { 699, 2, 690, 936, 319, 784, 562, 35, 151, 698, 126, 730, 587, 157, 201, 761, 956, 359, 198, 986, 915, 7, 703, 324, 814, 382, 294, 204, 120, 731, 615, 330, 486, 52, 223, 376, 649, 458, 564, 971, 72, 605, 177, 20, 461, 790, 872, 363, 916, 435, 991, 184, 410, 320, 16, 480, 768, 801, 117, 338, 650, 786, 17, 369, 979, 304, 445, 688, 862, 229, 311, 351, 985, 697, 135, 299, 310, 3, 643, 221, 831, 196, 887, 679, 484, 209, 824, 292, 588, 721, 140, 675, 827, 913, 271, 170, 812, 552, 334, 860, 981, 550, 308, 584, 442, 328, 251, 456, 976, 31, 507, 954, 982, 742, 45, 727, 794, 309, 527, 623, 56, 843, 436, 681, 143, 130, 689, 870, 362, 580, 560, 474, 385, 525, 881, 51, 890, 917, 820, 826, 139, 443, 978, 144, 512, 205, 682, 188, 344, 429, 497, 181, 749, 864, 664, 145, 621, 629, 886, 572, 89, 725, 945, 29, 553, 977, 783, 590, 236, 728, 125, 90, 492, 261, 543, 259, 662, 622, 285, 392, 561, 670, 200, 504, 246, 513, 910, 583, 460, 179, 207, 709, 127, 926, 816, 426, 520, 174, 464, 883, 780, 5, 268, 606, 1, 109, 704, 391, 661, 924, 516, 241, 477, 952, 405, 522, 247, 335, 356, 839, 423, 779, 4, 43, 720, 238, 965, 951, 914, 10, 496, 775, 651, 788, 373, 491, 746, 799, 518, 93, 86, 774, 652, 955, 494, 252, 781, 946, 412, 202, 741, 719, 612, 673, 896, 1000, 289, 554, 69, 424, 980, 506, 593, 889, 25, 959, 28, 736, 8, 969, 865, 657, 567, 434, 9, 167, 357, 929, 645, 250, 565, 94, 928, 473, 509, 823, 313, 762, -1, 208, 903, 922, 655, 948, 326, 485, 150, 73, 505, 225, 122, 129, 648, 838, 811, 972, 735, 78, 428, 740, 782, 632, 316, 440, 737, 297, 873, 281, 479, 654, 0, 633, 212, 152, 154, 470, 866, 79, 722, 958, 732, 900, 832, 278, 58, 842, 745, 540, 169, 347, 592, 438, 882, 462, 53, 34, 519, 489, 85, 757, 919, 701, 15, 211, 667, 637, 74, 573, 240, 559, -2, 472, 203, 112, 162, 776, -4, 155, 837, 99, 98, 64, 101, 983, 366, 853, 970, 482, 40, 921, 374, 758, 413, 339, 705, 771, 360, 734, 282, 219, 766, 535, 133, 532, 254 };
        //    Assert.That(ArrayQ.FirstMissingPositive(array) == 6);

        //    int[] array1 = { 1, 1, 1 };
        //    Assert.That(ArrayQ.FirstMissingPositive(array1) == 2);
        //}

        [Test]
        public static void Fibonacchi()
        {
            Assert.That(ArrayQ.Fibonacci(0) == 0);
            Assert.That(ArrayQ.Fibonacci(1) == 1);
            Assert.That(ArrayQ.Fibonacci(2) == 1);
            Assert.That(ArrayQ.Fibonacci(3) == 2);
            Assert.That(ArrayQ.Fibonacci(8) == 21);
        }

        [Test]
        public static void ConvertToTitle()
        {
            Assert.That(MathQ.ConvertToTitleBaseSymbol(943566) == "BAQTZ");
        }

        [Test]
        public static void isPalindrome()
        {
            Assert.That(MathQ.isPalindrome(2147447412) == 1);
            Assert.That(MathQ.isPalindrome2(2147447412) == 1);
        }

        [Test]
        public static void Pow()
        {
            Assert.That(MathQ.Pow(2, 5) == 32);
            Assert.That(MathQ.Pow(2, 6) == 64);

            Assert.That(MathQ.PowWithoutRecursion(2, 0) == 1);
            Assert.That(MathQ.PowWithoutRecursion(2, 1) == 2);
            Assert.That(MathQ.PowWithoutRecursion(2, 2) == 4);
            Assert.That(MathQ.PowWithoutRecursion(2, 3) == 8);
            Assert.That(MathQ.PowWithoutRecursion(2, 4) == 16);
            Assert.That(MathQ.PowWithoutRecursion(2, 5) == 32);
            Assert.That(MathQ.PowWithoutRecursion(2, 6) == 64);

            Assert.That(MathQ.PowMod(2, 4, 2) == 0);
            Assert.That(MathQ.PowMod(2, 3, 3) == 2);
            Assert.That(MathQ.PowMod(2, 7, 5) == 3);
        }

        [Test]
        public static void ExtraBrackets()
        {
            StackQueueQ stackQueue = new StackQueueQ();
            Assert.That(stackQueue.Braces("(a+b)") == 0);
            Assert.That(stackQueue.Braces("((a+b))") == 1);
            Assert.That(stackQueue.Braces("((a+b)+c}") == 0);
            Assert.That(stackQueue.Braces("(a)") == 1);
        }

        [Test]
        public static void RotateMatrix()
        {
            int[,] matrix0 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrix2 = { { 31, 32, 228, 333 }, { 79, 197, 241, 246 }, { 77, 84, 126, 337 }, { 110, 291, 356, 371 } };

            ArrayQ.RotateMatrix(matrix2);
            ArrayQ.RotateMatrix(matrix1);
        }
        [Test]
        public static void WordBreak()
        {
            DynamicQ dyn = new DynamicQ();
            string str = "myinterviewtrainer";
            string[] input = { "trainer", "my", "interview" };
            List<string> dic = new List<string>(input);
            Assert.That(dyn.WordBreak(str, dic) == 1);

            string str1 = "babbbbaabbaabaabaabaaabaababaaaabbbbbabbaabbabbbbababaabbabbbabbbaaabaababaaaababbbbabbbbbbaaaabaaabaabbbaaaabaaabbbaabababbbaaaabbabbbabaaabbbabaaabbbaaaaaabaabbabbaabbbbbaababbbbabbabbaabbbabaababaaaabbaabbbaabaabbbbbbaabbbaaaabbaaaaaabaabbaababbbabbbbbbaabbaabbbabbbaabbbaaaabbbaaaabbbabbaababaaabbababbaabbabbabaabbbbaaaabbaababababbbbbabbbbabbaaabbaabaaaaabbaaaaaaaaaaababaaabbbaababbbbbbbabbababbaabbaaaababbbabbaaabbbbbabbbaabbaaaaabbbbbbabbbbbabbabbbabbabbababbabaabaabbabababbababaababbaababbabaabbaaaabbbaa";
            string[] input1 = { "bbba", "aaaa", "abaa", "aba", "aabaaa", "baabbaab", "bbbabbbaaa", "abaabbbbba", "abaa", "aba", "bbabbbbabb", "aab", "baaabbbaaa", "b", "baba", "aaba", "baaba", "abb", "aaaa", "baaabbbaa", "ab" };
            List<string> dic1 = new List<string>(input1);
            Assert.That(dyn.WordBreak(str1, dic1) == 0);

            Assert.That(dyn.WordBreakAddSpace(str, dic).Equals("my interview trainer"));
            Assert.That(dyn.WordBreakAddSpace(str1, dic) == null);
        }

        [Test]
        public static void RotateRight()
        {
            Playground.DataStructure.LinkedList<int> list = new Playground.DataStructure.LinkedList<int>();
            list.Add(91);
            list.Add(34);
            list.Add(18);
            list.Add(83);
            list.Add(38);
            list.Add(82);
            list.Add(21);
            list.Add(69);

            LinkedListQ<int> listQ = new LinkedListQ<int>(list);
            var node = listQ.RotateRight(89);


            Assert.That(node.Value == 69);
        }

        [Test]
        public static void Subset()
        {
            BackTrackingQ track = new BackTrackingQ();
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var result = track.Subsets(list);

            string set = "abc";
            List<string> results = track.GetSubsets(set);
            Assert.That(results.Count == 8);
        }

        [Test]
        public static void GetIntersectionNode()
        {
            Playground.DataStructure.LinkedList<int> list = new Playground.DataStructure.LinkedList<int>();
            list.Add(4);
            list.Add(5);

            Playground.DataStructure.LinkedList<int> list1 = new Playground.DataStructure.LinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            var node = LinkedListQ<int>.GetIntersectionNode(list.Head, list1.Head);
            Assert.That(node.Value == 4);
        }

        [Test]
        public void Combine()
        {
            BackTrackingQ track = new BackTrackingQ();
            track.Combine(3, 2);
        }

        [Test]
        public static void MaxProduct()
        {
            List<int> list = new List<int>() { -2, -3, -3, 0, 1 };
            Assert.That(MathQ.MaxProduct(list) == 9);
        }

        [Test]
        public static void ReverseListInKRange()
        {
            Playground.DataStructure.LinkedList<int> list = new Playground.DataStructure.LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            LinkedListQ<int> listQ = new LinkedListQ<int>(list);

            Assert.That(listQ.ReverseListInGivenSize(2).Value == 2);

            Playground.DataStructure.LinkedList<int> list1 = new Playground.DataStructure.LinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list1.Add(6);
            listQ = new LinkedListQ<int>(list1);
            Assert.That(listQ.ReverseListInGivenSizeRecursive(listQ.Head, 2).Value == 2);
        }

        [Test]
        public static void ThreeSumClosest()
        {
            List<int> list = new List<int>() { -1, 2, 1, -4 };
            Assert.That(MathQ.ThreeSumClosest(list, 1) == 2);
        }

        [Test]
        public static void BitsReverse()
        {
            Assert.That(Bits.Reverse(3) == 3221225472);
            Assert.That(Bits.Reverse(4294967295) == 4294967295);
        }

        [Test]
        public static void TreeIsBalanced()
        {
            BST<int> bst = new BST<int>(int.MinValue, int.MaxValue)
            {
                Root = new Tree<int>.Node(10)
                {
                    Left = new Tree<int>.Node(5)
                    {
                        Left = new Tree<int>.Node(2),
                        Right = new Tree<int>.Node(7)
                        {
                            Left = new Tree<int>.Node(6)
                        },
                    },
                    Right = new Tree<int>.Node(15)
                    {
                        Left = new Tree<int>.Node(12)
                        {
                            Right = new Tree<int>.Node(13)
                        },
                        Right = new Tree<int>.Node(17)
                    }
                }
            };

            int test = bst.isBalanced(bst.Root);
        }

        [Test]
        public static void DetectCycle()
        {
            Playground.DataStructure.LinkedList<int> list = new Playground.DataStructure.LinkedList<int>();
            list.Add(1);
            var node2 = list.Add(2);
            list.Add(3);
            var node4 = list.Add(4);
            node4.Next = node2;

            LinkedListQ<int> listQ = new LinkedListQ<int>(list);
            Assert.That(listQ.DetectCycle() == node2);            
        }

        [Test]
        public static void ClimbStairs()
        {
            Assert.That(DynamicQ.ClimbStairs(2) == 2);
            Assert.That(DynamicQ.ClimbStairs(4) == 5);            
        }

        [Test]
        public void RestoreIpAddresses()
        {
            var list1 = StringQ.RestoreIpAddresses("0100100");
            Assert.That(list1.Count == 2);

            var list = StringQ.RestoreIpAddresses("25525511135");
            Assert.That(list.Count == 2);            
        }

        [Test]
        public void SortedArrayToBST()
        {
            List<int> list = new List<int>() { 1, 2 };
            var root = Tree<int>.SortedArrayToBST(list);
        }

        [Test]
        public void BuildTreeFromInAndPostOrder()
        {
            List<int> inOrder = new List<int>() { 2, 1, 3 };
            List<int> postOrder = new List<int>() { 2, 3, 1 };
            var root = Tree<int>.BuildTreeFromInAndPostOrder(inOrder, postOrder);
        }

        [Test]
        public void LongestPalindrome()
        {
            Assert.That(StringQ.LongestPalindrome("abbcccbbbcaaccbababcbcabca") == "bbcccbb");
        }

        [Test]
        public void MaximumGap()
        {
            Assert.That(ArrayQ.MaximumGap(new List<int>() { 3, 5, 4, 2 }) == 2);
        }

        [Test]
        public void FullJustify()
        {
            BackTrackingQ back = new BackTrackingQ();
            List<string> words = new List<string>() { "This", "is", "an", "example", "of", "text", "justification." };
            List<string> lines = back.FullJustify(words, 16);
            Assert.That(lines.Count == 3);

            words = new List<string>() { "What", "must", "be", "shall", "be." };
            lines = back.FullJustify(words, 12);
            Assert.That(lines.Count == 2);
        }

        [Test]
        public void PrevSmaller()
        {
            //Input: A: [4, 5, 2, 10, 8]
            //Return: [-1, 4, -1, 2, 2]
            var res = StackQueueQ.PrevSmaller(new List<int>() { 4, 5, 2, 10, 8 });
            Assert.That(res[2] == -1);
            Assert.That(res[3] == 2);
            Assert.That(res[4] == 2);
        }

        [Test]
        public void Flatten()
        {
            Tree<int> tree = new Tree<int>
            {
                Root = new Tree<int>.Node(1)
                {
                    Left = new Tree<int>.Node(2)
                    {
                        Left = new Tree<int>.Node(3),
                        Right = new Tree<int>.Node(4),
                    },
                    Right = new Tree<int>.Node(5)
                    {
                        Right = new Tree<int>.Node(6)
                    }
                }
            };

            var root = tree.Flatten();
        }

        [Test]
        public void InsertionSortLinkedList()
        {
            Playground.DataStructure.LinkedList<int> list = new Playground.DataStructure.LinkedList<int>();
            //3-> 5-> 66-> 68-> 42-> 73-> 25-> 84-> 63-> 72-> 20-> 77-> 38-> 8-> 99
            list.Add(3);
            list.Add(5);
            list.Add(66);
            list.Add(68);
            list.Add(42);
            list.Add(73);
            list.Add(25);
            list.Add(84);
            list.Add(63);
            list.Add(72);
            list.Add(20);
            list.Add(77);
            list.Add(38);
            list.Add(8);
            list.Add(99);

            LinkedListQ<int> listQ = new LinkedListQ<int>(list);
            var node = listQ.InsertionSortList();
        }

        [Test]
        public static void RainWaterTrap()
        {
            List<int> traps = new List<int>() { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Assert.That(ArrayQ.RainWaterTrap(traps) == 6);
            Assert.That(ArrayQ.RainWaterTrap2(traps) == 6);
        }

        [Test]
        public static void Permute()
        {
            List<int> list = new List<int>() { 1, 2, 3 };
            Assert.That(BackTrackingQ.Permute(list).Count == 6);
            Assert.That(BackTrackingQ.Permute2(list).Count == 6);
        }

        [Test]
        public static void GetListAnagrams()
        {
            List<string> input = new List<string>() { "cat", "dog", "god", "tca" };
            var res = StringQ.GetListAnagrams(input);
            Assert.That(res.Count == 2);
        }

        [Test]
        public void ZigZag()
        {
            Tree<int> tree = new Tree<int>
            {
                Root = new Tree<int>.Node(1)
                {
                    Left = new Tree<int>.Node(2)
                    {
                        Left = new Tree<int>.Node(3),
                        Right = new Tree<int>.Node(4),
                    },
                    Right = new Tree<int>.Node(5)
                    {
                        Right = new Tree<int>.Node(6)
                    }
                }
            };

            var res = tree.ZigzagLevelOrder();
        }

        [Test]
        public void LengthOfLongestSubstring()
        {
            var len1 = StringQ.LengthOfLongestSubstring("adcdef");
            Assert.That(len1 == 4);

            var len = StringQ.LengthOfLongestSubstring("Wnb9z9dMc7E8v1RTUaZPoDNIAXRlzkqLaa97KMWLzbitaCkRpiE4J4hJWhRcGnC8H6mwasgDfZ76VKdXhvEYmYrZY4Cfmf4HoSlchYWFEb1xllGKyEEmZOLPh1V6RuM7Mxd7xK72aNrWS4MEaUmgEn7L4rW3o14Nq9l2EN4HH6uJWljI8a5irvuODHY7A7ku4PJY2anSWnfJJE1w8p12Ks3oZRxAF3atqGBlzVQ0gltOwYmeynttUmQ4QBDLDrS4zn4VRZLosOITo4JlIqPD6t4NjhHThOjJxpMp9fICkrgJeGiDAwsb8a3I7Txz5BBKV9bEfMsKNhCuY3W0ZHqY0MhBfz1CbYCzwZZdM4p65ppP9s5QJcfjadmMMi26JKz0TVVwvNA8LP5Vi1QsxId4SI19jfcUH97wmZu0pbw1zFtyJ8GAp5yjjQTzFIboC1iRzklnOJzJld9TMaxqvBNBJKIyDjWrdfLOY8FGMOcPhfJ97Dph35zfxYyUf4DIqFi94lm9J0skYqGz9JT0kiAABQZDazZcNi80dSSdveSl6h3dJjHmlK8qHIlDsqFd5FMhlEirax8WA0v3NDPT8vPhwKpxcnVeu14Gcxr3h1wAXXV0y7Xy9qqB2NQ5HQLJ7cyXAckEYHsLCPSy28xcdNJatx1KLWohOQado4WywJbGvsFR17rKmvOPABweXnFD3odrbSMD4Na4nuBBswvMmFRTUOcf7jZi4z5JnJqXz6hitaPnaEtjoSEBq82a52nvqYy7hhldBoxen2et2OMadVEHeTYLL7GLsIhTP6UizHIuzcJMljo4lFgW5AyrfUlIBPAlhwaSiJtTvcbVZynDSM6RO1PqFKWKg2MHIgNhjuzENg2oFCfW7z5KJvEL9qWqKzZNc0o3BMRjS04NCHFvhtsteQoQRgz84XZBHBJRdekCdcVVXu9c01gYRAz7oIAxN3zKZb64EFKssfQ4HW971jv3H7x5E9dAszA0HrKTONyZDGYtHWt4QLhNsIs8mo4AIN7ecFKewyvGECAnaJpDn1MTTS4yTgZnm6N6qnmfjVt6ZU51F9BxH0jVG0kovTGSjTUkmb1mRTLQE5mTlVHcEz3yBOh4WiFFJjKJdi1HBIBaDL4r45HzaBvmYJPlWIomkqKEmQ4rLAbYG7C5rFfpMu8rHvjU7hP0JVvteGtaGn7mqeKsn7CgrJX1tb8t0ldaS3iUy8SEKAo5IZHNKOfEaij3nI4oRVzeVOZsH91pMsA4jRYgEohubPW8ciXwVrFi1qEWjvB8gfalyP60n1fHyjsiLW0T5uY1JzQWHKCbLVh7QFoJFAEV0L516XmzIo556yRH1vhPnceOCjebqgsmO78AQ8Ir2d4pHFFHAGB9lESn3OtJye1Lcyq9D6X93UakA3JKVKEt6JZDLVBMp4msOefkPKSw59Uix9d9kOQm8WCepJTangdNSOKaxblZDNJ5eHvEroYacBhd9UdafEitdF3nfStF7AhkSfQVC61YWWkKTNdx96OoJGTnxuqt4oFZNFtO7aMuN3IJAkw3m3kgZFRGyd3D3wweagNL9XlYtvZwejbjpkDOZz33C0jbEWaMEaUPw6BG49XqyQoUwtriguO0yvWyaJqD4ye3o0E46huKYAsdKAq6MLWMxF6tfyPVaoqOGd0eOBHbAF89XXmDd4AIkoFPXkAOW8hln5nXnIWP6RBbfEkPPbxoToMbV");
            Assert.That(len == 27);
        }

        [Test]
        public void FeedbackSortingByTrie()
        {
            TrieQ trieQ = new TrieQ();
            string goodWords = "cool_ice_wifi";
            List<string> feedback = new List<string>() { "water_is_cool", "cold_ice_drink", "cool_wifi_speed" };
            var res = trieQ.SortFeedbacks(goodWords, feedback);

            Assert.That(res[0] == 2);
            Assert.That(res[1] == 0); 
            Assert.That(res[2] == 1);
        }
    }
}
