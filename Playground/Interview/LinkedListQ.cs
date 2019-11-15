using System;
using Playground.DataStructure;

namespace Playground.Interview
{
    public class LinkedListQ<T> where T : IComparable
    {
        private LinkedList<T> _linkedList;
        private LinkedList<T>.Node _head;
        private LinkedList<T>.Node _tail;

        public LinkedListQ (LinkedList<T> linkedList)
        {
            _linkedList = linkedList;
            _head = _linkedList.Head;
            _tail = _linkedList.Tail;
        }

        public LinkedList<T> LinkedList => _linkedList;

        public LinkedList<T>.Node Head => _head;

        public LinkedList<T>.Node Tail => _tail;

        public void Reverse()
        {           
            var node = _head;
            LinkedList<T>.Node prev = null;

            _tail = _head;
            while (node != null)
            {
                var next = node.Next;
                node.Next = prev;
                prev = node;
                node = next;

                if (node != null)
                {
                    _head = node;
                }
            }
        }

        public void HalfReverse()
        {
            // define middle by fast pointer
            var slow = _head;
            var fast = _head;
            LinkedList<T>.Node prev = null;

            while (fast != null && fast.Next != null)
            {
                prev = slow;
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            prev.Next = Reverse(slow);
        }

        /// <summary>
        /// Reverse list starting from "start" node
        public LinkedList<T>.Node Reverse(LinkedList<T>.Node startNode)
        {
            var node = startNode;
            LinkedList<T>.Node prev = null;

            while (node != null)
            {
                var next = node.Next;
                node.Next = prev;

                prev = node;
                node = next;
            }

            return prev;
        }


        public void ReverseRecursive()
        {
            var node = _head;
            _tail = _head;
            ReverseRecursive(node, null);
        }

        private LinkedList<T>.Node ReverseRecursive(LinkedList<T>.Node node, LinkedList<T>.Node prev)
        {
            if (node == null)
            {
                _head = prev;
                return prev;
            }

            ReverseRecursive(node.Next, node);
            node.Next = prev;
            return prev;
        }

        public LinkedList<T>.Node ReverseBetween(int start, int end)
        {
            if (start > end)
            {
                return Head;
            }

            /*
            start from head. 
            calculate steps before B
            find first element and mark it as endTail
            do reversal and count iterations
            when find the last one mark it as head and linked
            endTail wit previos element 
            */

            int len = 0;
            LinkedList<T>.Node temp = Head;
            while (temp != null)
            {
                temp = temp.Next;
                len++;
            }

            if (end > len)
            {
                return Head;
            }

            LinkedList<T>.Node node = Head;
            LinkedList<T>.Node prevNoRecursive = null;

            int iter = 1;

            LinkedList<T>.Node endReverse = null;

            while (node != null)
            {
                if (iter == start)
                {
                    endReverse = node;
                    break;
                }

                prevNoRecursive = node;
                node = node.Next;
                iter++;
            }

            if (endReverse == null)
            {
                return Head;
            }

            // do reverse
            LinkedList<T>.Node prev = null;
            while (node != null && iter <= end)
            {
                LinkedList<T>.Node next = node.Next;
                node.Next = prev;

                prev = node;
                node = next;

                iter++;
            }

            // the latest things
            if (prevNoRecursive != null)
            {
                prevNoRecursive.Next = prev;
            }

            if (node != null)
            {
                endReverse.Next = node;
            }

            return prevNoRecursive == null ? prev : Head;
        }

        public LinkedList<T>.Node ReverseListInGivenSize(int k)
        {
            var node = Head;

            int current = 1;
            LinkedList<T>.Node prevTail = null;
            LinkedList<T>.Node currHead = Head;
            LinkedList<T>.Node newHead = null;
            while (node != null)
            {
                if (current == k)
                {
                    var nextKthNode = node.Next;
                    var it = currHead.Next;
                    var prev = currHead;
                    while (it != nextKthNode)
                    {
                        var next = it.Next;
                        it.Next = prev;
                        prev = it;
                        it = next;
                    }

                    if (prevTail != null)
                    {
                        prevTail.Next = prev;
                    }
                    else
                    {
                        newHead = node;
                    }

                    current = 1;
                    prevTail = currHead;
                    node = nextKthNode;
                    currHead = nextKthNode;
                    continue;
                }

                node = node.Next;
                current++;
            }

            prevTail.Next = null;
            return newHead;
        }

        public LinkedList<T>.Node ReverseListInGivenSizeRecursive(LinkedList<T>.Node head, int k)
        {
            if (head == null)
            {
                return null;
            }

            LinkedList<T>.Node prev = null;
            LinkedList<T>.Node cur = head;
            LinkedList<T>.Node curHead = head;
            int current = 0;
            while (cur != null && current < k)
            {
                var next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
                current++;
            }

            curHead.Next = ReverseListInGivenSizeRecursive(cur, k);
            return prev;
        }

        public LinkedList<T>.Node RotateRight(int k)
        {
            if (Head == null || Head.Next == null)
            {
                return Head;
            }

            int len = GetLength(_head);
            if (k % len == 0)
            {
                return Head;
            }

            k = k % len;
            int begin = len - k;

            LinkedList<T>.Node prev = null;
            LinkedList<T>.Node newHead = Head;
            int temp = begin;
            while (temp-- > 0)
            {
                prev = newHead;
                newHead = newHead.Next;
            }

            var findLast = newHead;
            while (findLast.Next != null)
            {
                findLast = findLast.Next;
            }

            findLast.Next = Head;
            prev.Next = null;
            return newHead;
        }

        private static int GetLength(LinkedList<T>.Node node)
        {
            if (node == null)
            {
                return 0;
            }

            int len = 0;
            var cur = node;
            while (cur != null)
            {
                cur = cur.Next;
                len++;
            }

            return len;
        }

        public static LinkedList<T>.Node GetIntersectionNode(LinkedList<T>.Node a, LinkedList<T>.Node b)
        {

            if (a == null || b == null)
            {
                return null;
            }

            int aLen = GetLength(a);
            int bLen = GetLength(b);

            int diff = aLen - bLen > 0 ? aLen - bLen : bLen - aLen;

            if (aLen < bLen)
            {
                LinkedList<T>.Node temp = b;
                b = a;
                a = temp;
            }

            while (diff > 0)
            {
                a = a.Next;
                diff--;
            }

            while (a != null && b != null)
            {
                if (a.Value.Equals(b.Value))
                {
                    return a;
                }

                a = a.Next;
                b = b.Next;
            }

            return null;
        }

        public LinkedList<T>.Node DetectCycle()
        {
            LinkedList<T>.Node slow = Head;
            LinkedList<T>.Node fast = Head;
            LinkedList<T>.Node head = Head;
            bool detect = false;

            while (slow != null && fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    detect = true;
                    break;
                }
            }

            if (detect)
            {
                LinkedList<T>.Node node = slow;
                int cycleLen = 1;
                while (node.Next != slow)
                {
                    node = node.Next;
                    cycleLen++;
                }

                LinkedList<T>.Node farFromHead = head;
                int jump = 0;
                while (farFromHead != null && jump != cycleLen)
                {
                    farFromHead = farFromHead.Next;
                    jump++;
                }

                node = head;
                while (node != farFromHead)
                {
                    node = node.Next;
                    farFromHead = farFromHead.Next;
                }

                return node;

                /*          
                // Without cycle len detection
                var node = slow;
                while (node.next != slow.next) 
                {
                    node = node.next;
                    slow = slow.next;
                }

                return node;            
               */
            }

            return null;
        }

        public bool IsPalindrome()
        {
            bool isPal = true;
            IsPalindromeReverse(Head, ref isPal);
            return isPal;
        }

        public LinkedList<T>.Node IsPalindromeReverse(LinkedList<T>.Node right, ref bool isPalindrome)
        {
            if (right == null)
            {
                return Head;
            }

            LinkedList<T>.Node left = IsPalindromeReverse(right.Next, ref isPalindrome);

            // we are in or after middle -> done
            if (left == null || left == right || !isPalindrome)
            {
                left = null;
                return left;
            }

            if (isPalindrome && !left.Value.Equals(right.Value))
            {
                isPalindrome = false;
            }

            return left.Next;
        }

        public LinkedList<T>.Node RemoveNthFromEnd(int NthFromEnd)
        {
            LinkedList<T>.Node node = Head;
            LinkedList<T>.Node follow = null; // len  - B - 1;
            int jump = 0;
            while (node.Next != null)
            {
                jump++;
                node = node.Next;

                if (jump == NthFromEnd)
                {
                    follow = Head;
                }
                else if (jump > NthFromEnd)
                {
                    follow = follow.Next;
                }
            }

            if (follow == null)
            {
                return Head.Next;
            }

            if (follow.Next != null)
            {
                follow.Next = follow.Next.Next;
            }

            return Head;
        }

        public LinkedList<T>.Node InsertionSortList2()
        {
            /*
            Insertion sort
            take second element -> iterate until the end
                start from head until second element
                swap if less than first element
            */

            LinkedList<T>.Node node = Head.Next;
            LinkedList<T>.Node head = Head;
            int elemSorted = 1;

            while (node != null)
            {
                var next = node.Next;

                int i = 0;
                LinkedList<T>.Node it = head;
                LinkedList<T>.Node prev = null;
                while (i < elemSorted)
                {
                    // swap
                    // 1 -> 3 -> 2
                    // 2 - node
                    // 3 - it

                    if (it.Value.CompareTo(node.Value) > 0)
                    {
                        //it.Next = node.Next;
                        var lastSorted = it;
                        int jump = elemSorted - i - 1;
                        while (jump > 0)
                        {
                            lastSorted = lastSorted.Next;
                            jump--;
                        }

                        lastSorted.Next = node.Next;
                        node.Next = it;

                        if (prev == null)
                        {
                            head = node;
                            head.Next = it;
                        }
                        else
                        {
                            prev.Next = node;
                        }
                        break;
                    }

                    prev = it;
                    it = it.Next;
                    i++;
                }

                elemSorted++;
                node = next;
            }

            return head;
        }

        public LinkedList<T>.Node InsertionSortList()
        {
            LinkedList<T>.Node unsortedHead = Head.Next;
            LinkedList<T>.Node sortedHead = Head;
            LinkedList<T>.Node lastSorted = Head;

            while (unsortedHead != null)
            {
                LinkedList<T>.Node cur = sortedHead;
                LinkedList<T>.Node prev = null;

                while (cur != null && cur.Value.CompareTo(unsortedHead.Value) < 0)
                {
                    prev = cur;
                    cur = cur.Next;
                }

                if (cur != unsortedHead)
                {
                    if (prev == null)
                    {
                        sortedHead = unsortedHead;
                    }
                    else
                    {
                        prev.Next = unsortedHead;
                    }

                    LinkedList<T>.Node next = unsortedHead.Next;
                    unsortedHead.Next = cur;
                    lastSorted.Next = next;
                    unsortedHead = next;
                }
                else
                {
                    lastSorted = unsortedHead;
                    unsortedHead = unsortedHead.Next;
                }
            }

            return sortedHead;
        }

        /// <summary>
        /// Merge k sorted linked lists and return it as one sorted list.
        /// </summary>
        public static LinkedList<T>.Node MergeSortedLinkedList(System.Collections.Generic.List<LinkedList<T>.Node> heads)
        {

            // find min -> update it in the array
            // set this node and 
            // repeat node->next until array list has not null elements

            /* alternative approach: define priority queue and take elements from there
             */

            LinkedList<T>.Node head = GetMinNode(heads);
            LinkedList<T>.Node node = head;

            while (node != null)
            {
                node.Next = GetMinNode(heads);
                node = node.Next;
            }

            return head;
        }

        private static LinkedList<T>.Node GetMinNode(System.Collections.Generic.List<LinkedList<T>.Node> lists)
        {
            LinkedList<T>.Node min = null;
            int index = -1;

            for (int i = 0; i < lists.Count; i++)
            {
                LinkedList<T>.Node cur = lists[i];
                if (cur != null)
                {
                    if (min == null || min.Value.CompareTo(cur.Value) > 0)
                    {
                        min = cur;
                        index = i;
                    }
                }
            }

            if (index != -1)
            {
                lists[index] = min.Next;
            }

            return min;
        }

        /// <summary>
        /// Given a sorted linked list, delete all duplicates such that each element appear only once.
        /// </summary>
        public LinkedList<T>.Node DeleteDuplicates(LinkedList<T>.Node head)
        {
            var node = head.Next;
            var noDupNode = head;

            while (node != null)
            {
                if (noDupNode.Value.CompareTo(node.Value) != 0)
                {
                    noDupNode.Next = node;
                    noDupNode = noDupNode.Next;
                }

                node = node.Next;
            }

            noDupNode.Next = null;
            return head;
        }

        /// <summary>
        /// Given 1->2->3->4, you should return the list as 2->1->4->3.
        /// </summary>
        public void SwapNodesInPairs()
        {
            if (Head == null || Head.Next == null)
                return;

            LinkedList<T>.Node prev = null;
            LinkedList<T>.Node cur = Head;
            LinkedList<T>.Node next = Head.Next;

            while (cur != null && next != null)
            {
                var nextNext = next.Next;
                next.Next = cur;

                if (prev != null)
                {
                    prev.Next = next;
                }
                else //first node
                {
                    _head = next;
                }

                prev = cur;
                cur = nextNext;
                next = nextNext != null && nextNext.Next != null ? nextNext.Next : null;
            }

            prev.Next = cur != null ? cur : null;
        }
    }
}
