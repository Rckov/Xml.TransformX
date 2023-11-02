using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

using TransformX.Transform.Xslt.Base;

namespace TransformX.Transform.Xslt;
internal class XslCompiledTransformer : BaseTransformer
{
    private readonly XsltSettings _settings;
    private readonly XslCompiledTransform _transform;

    private readonly StringBuilder _stringBuilder = new();

    public XslCompiledTransformer()
    {
        _settings = new(true, true);

        _transform = new(false);
        _transform.OutputSettings!.Async = true;
    }

    public override string Transform(XmlReader xml, XmlReader schema)
    {
        _stringBuilder.Clear();

        try
        {
            using var xmlWriter = XmlWriter.Create(_stringBuilder, _transform.OutputSettings);
            _transform.Load(schema, _settings, XsltUriResolver ?? new XmlUrlResolver());
            _transform.Transform(xml, null, xmlWriter, XsltUriResolver ?? new XmlUrlResolver());
        }
        catch (Exception ex) when (ex.InnerException is null)
        {
            _stringBuilder.AppendLine(ex.Message);
        }
        catch (Exception ex) when (ex.InnerException is not null)
        {
            _stringBuilder.AppendLine($"{ex.Message}\n{ex.InnerException.Message}");
        }

        return _stringBuilder.ToString();
    }
}
