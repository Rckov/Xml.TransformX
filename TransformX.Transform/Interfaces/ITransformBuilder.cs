using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using TransformX.Transform.Enums;

namespace TransformX.Transform.Interfaces;
public interface ITransformBuilder
{
    void Create(EngineType engineType);

    Task<string> TransformAsync(XmlReader xml, XmlReader schema);
}
