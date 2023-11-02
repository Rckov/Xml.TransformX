using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ICSharpCode.TextEditor;

namespace TransformX.Controls.ICSharpCode;
internal class TextEditorControlEx : TextEditorControl
{
    public TextEditorControlEx()
    {
        var findForm = new FindForm();

        editactions[Keys.Control | Keys.F] = new EditFindAction(findForm, this);
        editactions[Keys.Control | Keys.H] = new EditReplaceAction(findForm, this);
        editactions[Keys.Control | Keys.G] = new GoToLineAction();

        editactions[Keys.F3] = new FindAgainAction(findForm, this);
        editactions[Keys.F3 | Keys.Shift] = new FindAgainReverseAction(findForm, this);
    }
}
