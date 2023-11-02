using ICSharpCode.TextEditor;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformX.Controls.ICSharpCode.Extensions;
internal static class Extension
{
    public static int InRange(this int x, int lo, int hi) => x < lo ? lo : (x <= hi ? x : hi);

    public static bool IsInRange(this int x, int lo, int hi) => x >= lo && x <= hi;

    public static Color HalfMix(this Color one, Color two)
    {
        return Color.FromArgb(
            (one.A + two.A) >> 1,
            (one.R + two.R) >> 1,
            (one.G + two.G) >> 1,
            (one.B + two.B) >> 1);
    }

    public static void ShowScrollBars(this TextAreaControl textAreaControl, Orientation orientation, bool isVisible)
    {
        if (orientation == Orientation.Vertical)
        {
            textAreaControl.VScrollBar.Visible = isVisible;
        }
        else
        {
            textAreaControl.HScrollBar.Visible = isVisible;
        }
    }
}
