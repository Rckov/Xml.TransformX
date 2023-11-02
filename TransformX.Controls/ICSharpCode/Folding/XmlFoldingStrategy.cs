using ICSharpCode.TextEditor.Document;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TransformX.Controls.ICSharpCode.Folding;
internal class XmlFoldStart
{
    private readonly string _name, _prefix;

    public XmlFoldStart(string prefix, string name, int line, int col)
    {
        Line = line;
        Column = col;
        _prefix = prefix;
        _name = name;
    }

    public int Column { get; }

    public string FoldText { get; set; } = string.Empty;

    public int Line { get; }

    public string Name => _prefix.Length > 0 ? string.Concat(_prefix, ":", _name) : _name;
}

public class XmlFoldingStrategy : IFoldingStrategyEx
{
    private List<string> _foldingErrors = new();

    public List<string> GetFoldingErrors() => _foldingErrors;

    public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
    {
        _foldingErrors = new List<string>();

        var foldMarkers = new List<FoldMarker>();
        var stack = new Stack();

        try
        {
            var xml = document.TextContent;
            var reader = new XmlTextReader(new StringReader(xml));

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (!reader.IsEmptyElement)
                        {
                            var newFoldStart = CreateElementFoldStart(reader);
                            stack.Push(newFoldStart);
                        }

                        break;

                    case XmlNodeType.EndElement:
                        var foldStart = (XmlFoldStart)stack.Pop();
                        CreateElementFold(document, foldMarkers, reader, foldStart);
                        break;

                    case XmlNodeType.Comment:
                        CreateCommentFold(document, foldMarkers, reader);
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            _foldingErrors.Add(ex.Message);
            return new List<FoldMarker>(document.FoldingManager.FoldMarker);
        }

        return foldMarkers;
    }

    private static string XmlEncodeAttributeValue(string attributeValue, char quoteChar)
    {
        var encodedValue = new StringBuilder(attributeValue);
        encodedValue.Replace("&", "&amp;");
        encodedValue.Replace("<", "&lt;");
        encodedValue.Replace(">", "&gt;");

        _ = quoteChar == '"' ? encodedValue.Replace("\"", "&quot;") : encodedValue.Replace("'", "&apos;");

        return encodedValue.ToString();
    }

    private static void CreateCommentFold(IDocument document, List<FoldMarker> foldMarkers, XmlTextReader reader)
    {
        if (reader.Value != null)
        {
            var comment = reader.Value.Replace("\r\n", "\n");
            var lines = comment.Split('\n');

            if (lines.Length > 1)
            {
                var startCol = reader.LinePosition - 5;
                var startLine = reader.LineNumber - 1;

                var endCol = lines[^1].Length + startCol + 3;
                var endLine = startLine + lines.Length - 1;
                var foldText = string.Concat("<!--", lines[0], "-->");
                var foldMarker = new FoldMarker(document, startLine, startCol, endLine, endCol, FoldType.TypeBody, foldText);
                foldMarkers.Add(foldMarker);
            }
        }
    }

    private static void CreateElementFold(IDocument document, List<FoldMarker> foldMarkers, XmlTextReader reader, XmlFoldStart? foldStart)
    {
        var endLine = reader.LineNumber - 1;

        if (endLine > foldStart?.Line)
        {
            var endCol = reader.LinePosition + foldStart.Name.Length;
            var foldMarker = new FoldMarker(document, foldStart.Line, foldStart.Column, endLine, endCol, FoldType.TypeBody, foldStart.FoldText);
            foldMarkers.Add(foldMarker);
        }
    }

    private XmlFoldStart CreateElementFoldStart(XmlTextReader reader)
    {
        var newFoldStart = new XmlFoldStart(reader.Prefix, reader.LocalName, reader.LineNumber - 1, reader.LinePosition - 2);

        newFoldStart.FoldText = reader.HasAttributes
            ? string.Concat("<", newFoldStart.Name, " ", GetAttributeFoldText(reader), ">")
            : string.Concat("<", newFoldStart.Name, ">");

        return newFoldStart;
    }

    private static string GetAttributeFoldText(XmlTextReader reader)
    {
        var text = new StringBuilder();

        for (int i = 0; i < reader.AttributeCount; ++i)
        {
            reader.MoveToAttribute(i);
            text.Append(reader.Name);
            text.Append("=");
            text.Append(reader.QuoteChar.ToString(CultureInfo.InvariantCulture));
            text.Append(XmlEncodeAttributeValue(reader.Value, reader.QuoteChar));
            text.Append(reader.QuoteChar.ToString(CultureInfo.InvariantCulture));

            // Append a space if this is not the last attribute.
            if (i < reader.AttributeCount - 1)
            {
                text.Append(" ");
            }
        }

        return text.ToString();
    }
}

public interface IFoldingStrategyEx : IFoldingStrategy
{
    List<string> GetFoldingErrors();
}