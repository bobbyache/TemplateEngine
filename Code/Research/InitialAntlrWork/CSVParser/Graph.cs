using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace CSVParsing
{
    public class Graph
    {
        // OrderedHashSet was retrieved at this link: https://github.com/antlr/antlrcs/blob/master/Antlr3/Misc/OrderedHashSet.cs
        // was actually for Antlr3, but hopefully should work fine.

        public OrderedHashSet<string> nodes = new OrderedHashSet<string>();        // list of functions...
        MultiMap<string, string> edges = new MultiMap<string, string>();    // caller -> callee

        public void Edge(string source, string target)
        {
            edges.Map(source, target);
        }

        public string ToDot()
        {
            // you can download the open-source application that uses DOT here: http://www.graphviz.org/
            // dot guide here: http://www.graphviz.org/pdf/dotguide.pdf

            StringBuilder buf = new StringBuilder();
            buf.Append("digraph G {\n");
            buf.Append(" ranksep=.25;\n");
            buf.Append(" edge [arrowsize=.5]\n");
            buf.Append(" node [shape=circle, fontname=\"ArialNarrow\",\n");
            buf.Append(" fontsize=12, fixedsize=true, height=.45];\n");
            buf.Append(" ");
            foreach (String node in nodes)
            { // print all nodes first
                buf.Append(node);
                buf.Append("; ");
            }
            buf.Append("\n");
            foreach (String src in edges.Keys)
            {
                foreach (String trg in edges[src])
                {
                    buf.Append(" ");
                    buf.Append(src);
                    buf.Append(" -> ");
                    buf.Append(trg);
                    buf.Append(";\n");
                }
            }
            buf.Append("}\n");
            return buf.ToString();

        }
    }
}
