using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;

namespace CSVParsing
{
    public class XmlEmitter : JSONBaseListener
    {
        ParseTreeProperty<string> parseTreePropertyXml = new ParseTreeProperty<string>();

        private IParseTree parseTree;

        // attach the translated string for each subtree to the root of that subtree.
        // methods working on nodes further up the parse tree can grab those values to
        // computer larger strings. The string attached to the root node is then the 
        // complete translation.

        public string Xml()
        {
            // get the top level parseTreePropertyXml.
            return parseTreePropertyXml.Get(parseTree);
        }

        // **********************************************************************************
        // Processing "Atom" labeled values
        // **********************************************************************************
        public override void ExitAtom(JSONParser.AtomContext context)
        {
            // will always return a "value" of an array or object property pair as long 
            // as a value is labeled Atom.
            string contextText = context.GetText();
            SetXml(context, contextText);
            base.ExitAtom(context);
        }

        // **********************************************************************************
        // Processing "String" labeled values
        // **********************************************************************************
        public override void ExitString(JSONParser.StringContext context)
        {
            // strip quotes from the JSON pair "value". GetText() returns the "value" in the key value
            // JSON object pair.
            // returns the "value" because label that we've specified under
            // value
	        //    : STRING	# String
            // will always fall on the left side of the "pair". So the STRING in pair will not fire this event.
            // this includes the rule for the "value" of the pair, and the "value" in the array.
            string contextText = context.GetText();
            SetXml(context, stripQuotes(contextText));
            base.ExitString(context);
        }


        public override void ExitObjectValue(JSONParser.ObjectValueContext context)
        {
            // content.@object() - returns the sub-context relating to the "object" labeled ObjectValue.
            //      copies partial translation for composite element to its own parse tree.
            //      insert it into the parse tree node - parseTreePropertyXml.
            // content.GetText() - returns the entire json object as a string.

            string xml = GetXml(context.@object());
            SetXml(context, xml);
            base.ExitObjectValue(context);
        }

        public override void ExitArrayValue(JSONParser.ArrayValueContext context)
        {
            string xml = GetXml(context.array());
            SetXml(context, xml);
            base.ExitArrayValue(context);
        }

        public override void ExitPair(JSONParser.PairContext context)
        {
            // builds up an <pair>value</pair> xml line from property : value in json.
            // when we ask for context.STRING(), we're getting the value on the left side
            // of what is defined as a "pair", and this is why it picks up the key value
            // and not the "value" value. We'll use the output for the tag.

            // context.STRING() is our key in the json object.
            // context.value() is our value in the json object.
            // The ":" is a literal and so isn't exposed as a rule, but we can see it if
            // we look in context.children

            string txt = context.STRING().GetText();

            // Strip quotes from the JSON Key.
            string tag = stripQuotes(context.STRING().GetText());
            JSONParser.ValueContext valueContext = context.value();

            // GetXml returns the text (without dbl quotes) from the parseTreePropertyXml item
            // associated with the value. We've already annotated the context with this item.
            // the annotation is a type ParseTreeProperty provided by ANTLR framework. Could
            // store any object.

            // XML Tag = context.STRING().GetText()
            // XML Inner Text = context.value()

            string xml = GetXml(valueContext);
            string x = string.Format("<{0}>{1}</{2}>\n", tag, GetXml(valueContext), tag);
            SetXml(context, x);

            base.ExitPair(context);
        }

        // **********************************************************************************
        // Processing Objects
        // **********************************************************************************
        public override void ExitAnObject(JSONParser.AnObjectContext context)
        {
            // builds up an object from the values parsed. This will execute now that we're 
            // exiting an object def.
            // So we expect there will be 0 or more pairs.

            StringBuilder buf = new StringBuilder();
            buf.Append("\n");

            foreach (JSONParser.PairContext pairContext in context.pair())
            {
                // so for each pair, we're going to append the xml.
                // the xml already exists in the parseTreePropertyXml because we've SetXml()'ed
                // it with "ExitPair"
                string xml = GetXml(pairContext);
                buf.Append(GetXml(pairContext));
            }
            SetXml(context, buf.ToString());

            base.ExitAnObject(context);
        }

        public override void ExitEmptyObject(JSONParser.EmptyObjectContext context)
        {
            SetXml(context, "");
            base.ExitEmptyObject(context);
        }
        // **********************************************************************************


        // **********************************************************************************
        // Processing Arrays
        // **********************************************************************************
        public override void ExitArrayOfValues(JSONParser.ArrayOfValuesContext context)
        {
            // P. 132 (147)
            // Same as with "ExitObjectValue" except that we don't need the little @ symbol
            // probably because of a keyword conflict. But if you just pass the context
            // the resulting xml will be null.

            StringBuilder buf = new StringBuilder();
            buf.Append("\n");
            foreach (JSONParser.ValueContext valueContext in context.value()) 
            {
                string xml = GetXml(valueContext);

                buf.Append("<element>"); // conjure up element for valid XML
                buf.Append(GetXml(valueContext));
                buf.Append("</element>");
                buf.Append("\n");
            }
            SetXml(context, buf.ToString());
            base.ExitArrayOfValues(context);
        }

        public override void ExitEmptyArray(JSONParser.EmptyArrayContext context)
        {
            SetXml(context, "");
            base.ExitEmptyArray(context);
        }
        // **********************************************************************************



        // **********************************************************************************
        // Annotate the root of the parse tree.
        // **********************************************************************************
        public override void ExitJson(JSONParser.JsonContext context)
        {
            //string xml = context.GetChild(0);
            SetXml(context, GetXml(context.GetChild(0)));

            IParseTree tree = context.GetChild(0);
            string text = tree.ToStringTree();

            // important, because the tree  contains the top annotated root element.
            this.parseTree = tree;  
            base.ExitJson(context);
        }





        private string GetXml(IParseTree context)
        {
            return parseTreePropertyXml.Get(context);
        }

        private void SetXml(IParseTree context, string s)
        {
            parseTreePropertyXml.Put(context, s);
        }



        private string stripQuotes(string quotedText)
        {
            return quotedText.Replace("\"", "");
        }
        //IParseTree
    }
}
