using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using TransformX.Transform.Interfaces;

namespace TransformX.Transform.Xslt.Base;
internal abstract class BaseTransformer : ITransform
{
    public XsltUriResolver? XsltUriResolver { get; set; }

    public abstract string Transform(XmlReader xml, XmlReader schema);

    public Task<string> TransformAsync(XmlReader xml, XmlReader schema)
    {
        return Task.Run(() => Transform(xml, schema));
    }
}
