﻿using System.Collections.Generic;

namespace Playground.Interview
{
    public class GraphQ
    {
        /// <summary>
        /// Given N * M field of O's and X's, where O=white, X=black
        /// Return the number of black shapes.A black shape consists of one or more adjacent X's (diagonals not included)
        /// Example:
        /// OOOXOOO
        /// OOXXOXO
        /// OXOOOXO
        /// Return 3
        /// </summary>
        public int Black(List<string> A)
        {
            /*
            Graph connectivity problem
                - define all items as unvisited
                - start with the first item and mark it as visit 
                   if it's X calculate connected number and recurrently repeat it
                   marking nodes as visited
                - do it until iterate all nodes
            */

            if (A == null)
            {
                return 0;
            }

            bool[,] visited = new bool[A.Count, A[0].Length];
            int connected = 0;

            for(int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                {
                    if(!visited[i,j] && A[i][j] == 'X')
                    {
                        DFS(visited, A, i, j);
                        connected++;
                    }
                }
            }           

            return connected;
        }

        private void DFS(bool[,] visited, List<string> list, int rowIndex, int colIndex)
        {
            visited[rowIndex, colIndex] = true;

            int[] rowMove = { 1, -1, 0, 0 };
            int[] colMove = { 0, 0, 1, -1 };

            for (int i = 0; i < rowMove.Length; i++)
            {                
                int newRow = rowIndex + rowMove[i];
                int newCol = colIndex + colMove[i];

                //valid x && valid y && not visited
                if (newCol < list[0].Length && newCol >= 0 && newRow < list.Count && newRow >= 0
                    && !visited[newRow, newCol] && list[newRow][newCol] == 'X')
                    DFS(visited, list, newRow, newCol);
            }          
        }

        public class GraphNode
        {
            public int id;
            public List<GraphNode> dids;
            public GraphNode(int id)
            {
                this.id = id;
                this.dids = new List<GraphNode>();
            }
        }

        public bool IsCyclic(int countCources, List<int> courcesList, List<int> prerList)
        {
            var nodes = new List<GraphNode>();
            for (int i = 1; i <= countCources; i++)
            {
                nodes.Add(new GraphNode(i));
            }

            for (int i = 0; i < courcesList.Count; i++)
            {
                nodes[courcesList[i] - 1].dids.Add(nodes[prerList[i] - 1]);
            }

            foreach (var node in nodes)
            {
                if (BFS(node) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public int BFS(GraphNode g)
        {
            var q = new Queue<GraphNode>();
            q.Enqueue(g);
            var visited = new HashSet<GraphNode>();
            while (q.Count != 0)
            {
                var node = q.Dequeue();
                foreach (var n in node.dids)
                {
                    if (visited.Contains(n))
                    {
                        return 0;
                    }
                    q.Enqueue(n);
                }
                visited.Add(node);
            }
            return 1;
        }       
    }    
}
