using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using TransformX.Transform.Xslt.Base;

namespace TransformX.Transform.Xslt;
internal class SaxonTransformer : BaseTransformer
{
    public override string Transform(XmlReader xml, XmlReader schema)
    {
        throw new NotImplementedException("Saxon");
    }
}
