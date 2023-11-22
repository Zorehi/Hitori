using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class DuplicateNode
    {
        private List<Node> _duplicateRow;
        private bool _resolvedRow;

        public DuplicateNode(Graph graph, Node node, bool inRow)
        {
            _duplicateRow = new List<Node>();
            _resolvedRow = false;

            for (int i = 0; i < graph.Nodes.Length; i++)
            {
                Node nodeTemp;
                if (inRow)
                {
                    nodeTemp = graph.Nodes[node.Xpos, i];
                } 
                else
                {
                    nodeTemp = graph.Nodes[i, node.Ypos];
                }

                if (nodeTemp.Box.State == State.Black || nodeTemp.Box.State == State.Gray)
                {
                    if (nodeTemp.Box.Value == node.Box.Value)
                    {
                        _duplicateRow.Add(nodeTemp);
                    }
                }
            }
        }

        public List<Node> NodesRow { get => _duplicateRow; set => _duplicateRow = value; }
        public bool ResolvedRow { get => _resolvedRow; set => _resolvedRow = value; }
    }
}
