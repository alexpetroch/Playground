using System.Collections.Generic;
using System.Linq;
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


        public bool IsCyclic(int startValue)
        {
            bool[] visited = new bool[vertices];
            System.Collections.Generic.Queue<GraphNode> queue = new System.Collections.Generic.Queue<GraphNode>();

            int index = startValue;
            queue.Enqueue(adjLists[index]);

            while (queue.Count > 0)
            {
                var graphNode = queue.Dequeue();

                // print value graphNode.value
                for (int i = 0; i < graphNode.Edges.Count; i++)
                {
                    int adjIndex = graphNode.Edges[i];
                    if (!visited[adjIndex])
                    {                        
                        queue.Enqueue(adjLists[adjIndex]);
                    }
                    else
                        return true;
                }

                visited[index] = true;
            }

            return false;
        }
    }
}
