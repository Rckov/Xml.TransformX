using ICSharpCode.TextEditor.Document;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformX.Controls.ICSharpCode.Utils;
internal class TextRange : AbstractSegment
{
    public TextRange(int offset, int length)
    {
        this.offset = offset;
        this.length = length;
    }
}