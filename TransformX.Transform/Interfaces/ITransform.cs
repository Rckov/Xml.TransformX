using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TransformX.Transform.Interfaces;
internal interface ITransform
{
    XsltUriResolver? XsltUriResolver { get; set; }

    Task<string> TransformAsync(XmlReader xml, XmlReader schema);
}
