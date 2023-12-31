﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TransformX.Transform;
public class XsltUriResolver : XmlUrlResolver
{
    public XsltUriResolver(Uri baseUri) => BaseUri = baseUri;

    public XsltUriResolver(string baseUri) => BaseUri = new Uri(baseUri);

    public Uri? BaseUri { get; set; }

    public override object? GetEntity(Uri absoluteUri, string? role, Type? ofObjectToReturn)
    {
        return base.GetEntity(absoluteUri, role, ofObjectToReturn);
    }

    public override Uri ResolveUri(Uri? baseUri, string? relativeUri)
    {
        return base.ResolveUri(BaseUri ?? baseUri, relativeUri);
    }
}
