using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using TransformX.Transform.Enums;
using TransformX.Transform.Interfaces;
using TransformX.Transform.Xslt;

namespace TransformX.Transform;
internal class Transformer : ITransformBuilder
{
    private ITransform? _transform;

    public XsltUriResolver? XsltUriResolver
    {
        get => _transform?.XsltUriResolver;
        set
        {
            if (_transform is not null)
            {
                _transform.XsltUriResolver = value;
            }
        }
    }

    public void Create(EngineType engineType)
    {
        _transform = engineType switch
        {
            EngineType.Saxon => new SaxonTransformer(),
            EngineType.XslCompiledTransform => new XslCompiledTransformer(),
            _ => throw new NotImplementedException(),
        };
    }

    public Task<string> TransformAsync(XmlReader xml, XmlReader schema)
    {
        if (_transform is null)
        {
            throw new NotImplementedException(nameof(_transform));
        }

        return _transform.TransformAsync(xml, schema);
    }
}
