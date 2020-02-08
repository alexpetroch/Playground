using System.Collections.Generic;
using System.Text;

namespace Playground.DataStructure
{
    public class Graph
    {
        int vertices;
        private List<GraphNode> adjLists;

        class GraphNode
        {
            public List<int> Edges = new List<int>();
            public int value;
            public GraphNode(int value)
            {
                this.value = value;
            }
        }

        public Graph(int vertices)
        {
            this.vertices = vertices;
            adjLists = new List<GraphNode>();

            for (int i = 0; i < vertices; i++)
            {
                var node = new GraphNode(i);
                adjLists.Add(node);
            }
        }

        public void AddEdge(int from, int to)
        {
            // convert to indexes
            adjLists[from].Edges.Add(to);
        }

        // level order
        public string BreadthFirstSearch(int startValue)
        {
            bool[] visited = new bool[vertices];
            System.Collections.Generic.Queue<GraphNode> queue = new System.Collections.Generic.Queue<GraphNode>();
            StringBuilder sb = new StringBuilder();

            int index = startValue;
            queue.Enqueue(adjLists[index]);
            visited[index] = true;

            while (queue.Count > 0)
            {
                var graphNode = queue.Dequeue();
                sb.Append(graphNode.value + " ");

                // print value graphNode.value
                for (int i = 0; i < graphNode.Edges.Count; i++)
                {
                    int adjIndex = graphNode.Edges[i];
                    if (!visited[adjIndex])
                    {
                        visited[adjIndex] = true;
                        queue.Enqueue(adjLists[adjIndex]);
                    }
                }
            }

            return sb.ToString();
        }

        public string DepthFirstSearch(int startValue)
        {
            bool[] visited = new bool[vertices];
            System.Collections.Generic.Stack<GraphNode> stack = new System.Collections.Generic.Stack<GraphNode>();
            StringBuilder sb = new StringBuilder();

            int index = startValue;
            stack.Push(adjLists[index]);

            while (stack.Count > 0)
            {
                var graphNode = stack.Pop();

                index = graphNode.value;
                if (!visited[index])
                {
                    sb.Append(graphNode.value + " ");
                    visited[index] = true;
                }

                for (int i = 0; i < graphNode.Edges.Count; i++)
                {
                    int adjIndex = graphNode.Edges[i];
                    if (!visited[adjIndex])
                    {
                        stack.Push(adjLists[adjIndex]);
                    }
                }
            }

            return sb.ToString();
        }

        public string DepthFirstSearchRecurcive(int startValue)
        {
            bool[] visited = new bool[vertices];
            StringBuilder sb = new StringBuilder();

            return DepthFirstSearchRecurciveHelper(startValue, visited, sb);
        }

        private string DepthFirstSearchRecurciveHelper(int startValue, bool[] visited, StringBuilder sb)
        {
            int index = startValue;
            var node = adjLists[index];

            visited[index] = true;
            sb.Append(node.value + " ");

            for (int i = 0; i < node.Edges.Count; i++)
            {
                int adjIndex = node.Edges[i];
                if (!visited[adjIndex])
                {
                    DepthFirstSearchRecurciveHelper(adjIndex, visited, sb);
                }
            }

            return sb.ToString();
        }

        public bool IsCyclic()
        {
            bool[] visited = new bool[vertices];

            // Visit courses from 0 - N, check if there are cycles starting at course i
            for (int i = 0; i < vertices; i++)
            {
                if (IsCycle(visited, i))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCycle(bool[] visited, int index)
        {
            // If we've seen this course before, then there is a cycle
            if (visited[index])
            {
                return true;
            }

            visited[index] = true;

            // Visit the neighbors, if there is a cycle, one of the neighbors
            // will be a course we've visited before
            foreach (var subsequentCourse in adjLists[index].Edges)
            {
                if (IsCycle(visited, subsequentCourse))
                {
                    return true;
                }
            }

            // If we get here that means that for all neighbors of course
            // there are no cycles back to the starting course
            // Clear the visited flag 
            visited[index] = false;

            return false;
        }

        /// <summary>
        /// https://leetcode.com/discuss/interview-question/476340/google-onsite-min-modifications
        /// </summary>
        /// <param name="ways"></param>
        public static int GetMinModifications(char[][] ways)
        {
            if (ways == null || ways.Length == 0 || ways[0].Length == 0)
                return 0;

            bool[][] visited = new bool[ways.Length][];
            int[][] modifications = new int[ways.Length][];

            for (int i = 0; i < ways.Length; i++)
            {
                visited[i] = new bool[ways[i].Length];
                modifications[i] = new int[ways[i].Length];
            }

            for (int i = 0; i < ways.Length; i++)
            {
                for (int j = 0; j < ways[i].Length; j++)
                    modifications[i][j] = int.MaxValue;
            }

            System.Collections.Generic.LinkedList<System.Tuple<int, int>> list = new System.Collections.Generic.LinkedList<System.Tuple<int, int>>();
            modifications[0][0] = 0;
            list.AddFirst(new System.Tuple<int, int>(0, 0));

            while (list.Count > 0)
            {
                var tuple = list.First.Value;
                int row = tuple.Item1;
                int col = tuple.Item2;

                list.RemoveFirst();

                // if reach right bottom element -> return 
                if (row == ways.Length - 1 && col == ways[0].Length - 1)
                    return modifications[row][col];

                visited[row][col] = true;

                // update down point
                if (row + 1 < ways.Length)
                {
                    int modify = ways[row][col] == 'D' ? 0 : 1;
                    modifications[row + 1][col] = System.Math.Min(modifications[row + 1][col], modify + modifications[row][col]);
                    if (!visited[row + 1][col])
                    {
                        if (modify == 0) list.AddFirst(new System.Tuple<int, int>(row + 1, col));
                        else list.AddLast(new System.Tuple<int, int>(row + 1, col));
                    }
                }

                // update right point
                if (col + 1 < ways[0].Length)
                {
                    int modify = ways[row][col] == 'R' ? 0 : 1;
                    modifications[row][col + 1] = System.Math.Min(modifications[row][col + 1], modify + modifications[row][col]);
                    if (!visited[row][col + 1])
                    {
                        if (modify == 0) list.AddFirst(new System.Tuple<int, int>(row, col + 1));
                        else list.AddLast(new System.Tuple<int, int>(row, col + 1));
                    }
                }

                // update up point
                if (row - 1 >= 0)
                {
                    int modify = ways[row][col] == 'U' ? 0 : 1;
                    modifications[row - 1][col] = System.Math.Min(modifications[row - 1][col], modify + modifications[row][col]);
                    if (!visited[row - 1][col])
                    {
                        if (modify == 0) list.AddFirst(new System.Tuple<int, int>(row - 1, col));
                        else list.AddLast(new System.Tuple<int, int>(row - 1, col));
                    }
                }

                // update left point
                if (col - 1 >= 0)
                {
                    int modify = ways[row][col] == 'L' ? 0 : 1;
                    modifications[row][col - 1] = System.Math.Min(modifications[row][col - 1], modify + modifications[row][col]);
                    if (!visited[row][col - 1])
                    {
                        if (modify == 0) list.AddFirst(new System.Tuple<int, int>(row, col - 1));
                        else list.AddLast(new System.Tuple<int, int>(row, col - 1));
                    }
                }
            }

            return 0;
        }
    }
}
