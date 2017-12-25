namespace Playground.Interview
{
    using System.Collections.Generic;

    public class StackQueueQ
    {
        /// <summary>
        /// https://codility.com/programmers/lessons/7-stacks_and_queues/brackets/
        /// </summary>
        public int CheckBrackets(string S)
        {

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < S.Length; i++)
            {
                // Put ( or { or [ to stack
                if (OpenBracket(S[i]))
                {
                    brackets.Push(S[i]);
                }
                else if (CloseBracket(S[i]))
                {
                    if (brackets.Count == 0 || brackets.Pop() != FindPairBracket(S[i]))
                    {
                        return 0;
                    }
                }
            }


            return brackets.Count == 0 ? 1 : 0;
        }

        /// <summary>
        /// https://www.interviewbit.com/problems/redundant-braces/
        /// </summary>
        public int Braces(string A)
        {

            if (string.IsNullOrEmpty(A))
            {
                return 0;
            }

            Stack<char> stack = new Stack<char>();
            // itetate through string and put brackets into string
            // one close bracket is observed then pop from stack and check next symbol
            // only + - * are allowed only
            for (int i = 0; i < A.Length; i++)
            {
                if (IsOperator(A[i]) || A[i] == '(')
                {
                    stack.Push(A[i]);
                }
                else if (A[i] == ')')
                {
                    if (stack.Peek() == '(')
                    {
                        return 1;
                    }
                    else
                    {
                        while (stack.Count > 0 && stack.Peek() != '(')
                        {
                            stack.Pop();
                        }

                        stack.Pop();
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Given an array, find the nearest smaller element G[i] for every element A[i] in the array such that the element has an index smaller than i.
        /// </summary>
        public static List<int> PrevSmaller(List<int> array)
        {
            if (array == null || array.Count == 0) return null;

            List<int> res = new List<int>();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < array.Count; i++)
            {
                int smallest = -1;
                while (stack.Count > 0)
                {
                    int top = stack.Peek();
                    if (top >= array[i])
                    {
                        stack.Pop();
                    }
                    else
                    {
                        smallest = top;
                        break;
                    }
                }

                stack.Push(array[i]);
                res.Add(smallest);
            }

            return res;
        }

        private bool IsOperator(char symbol)
        {
            return symbol == '*' || symbol == '/' || symbol == '+' || symbol == '-';
        }


        private bool OpenBracket(char ch)
        {
            return ch == '(' || ch == '{' || ch == '[';
        }

        private bool CloseBracket(char ch)
        {
            return ch == ')' || ch == '}' || ch == ']';
        }

        private char FindPairBracket(char ch)
        {
            if (ch == ')')
            {
                return '(';
            }
            if (ch == '}')
            {
                return '{';
            }
            if (ch == ']')
            {
                return '[';
            }

            return ' ';
        }
    }
}
