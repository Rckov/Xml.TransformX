using ICSharpCode.TextEditor.Document;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransformX.Controls.ICSharpCode.Extensions;

namespace TransformX.Controls.ICSharpCode.Utils;
internal class TextEditorSearcher : IDisposable
{
    private string _lookFor2 = null!;

    private IDocument? _document;
    private TextMarker? _region;

    public IDocument? Document
    {
        get => _document;
        set
        {
            if (_document != value)
            {
                ClearScanRegion();
                _document = value;
            }
        }
    }

    public string? LookFor { get; set; }

    public bool HasScanRegion
        => _region != null;

    public int BeginOffset
        => _region != null ? _region.Offset : 0;

    public int EndOffset
        => _region != null ? _region.EndOffset : _document!.TextLength;

    public bool MatchCase, MatchWholeWordOnly;

    public void SetScanRegion(ISelection sel) => SetScanRegion(sel.Offset, sel.Length);

    public void SetScanRegion(int offset, int length)
    {
        var bkgColor = _document!.HighlightingStrategy.GetColorFor("Default").BackgroundColor;

        _region = new TextMarker(offset, length, TextMarkerType.SolidBlock,
            bkgColor.HalfMix(Color.FromArgb(160, 160, 160)));

        _document.MarkerStrategy.AddMarker(_region);
    }

    public void ClearScanRegion()
    {
        if (_region != null)
        {
            _document?.MarkerStrategy.RemoveMarker(_region);
            _region = null;
        }
    }

    public void Dispose()
    {
        ClearScanRegion();
        GC.SuppressFinalize(this);
    }

    ~TextEditorSearcher()
    {
        Dispose();
    }

    public TextRange? FindNext(int beginAtOffset, bool searchBackward, out bool loopedAround)
    {
        loopedAround = false;

        int startAt = BeginOffset, endAt = EndOffset;
        var curOffs = beginAtOffset.InRange(startAt, endAt);

        _lookFor2 = MatchCase ? LookFor! : LookFor!.ToUpperInvariant();

        TextRange result;

        if (searchBackward)
        {
            result = FindNextIn(startAt, curOffs, true);

            if (result == null)
            {
                loopedAround = true;
                result = FindNextIn(curOffs, endAt, true);
            }
        }
        else
        {
            result = FindNextIn(curOffs, endAt, false);

            if (result == null)
            {
                loopedAround = true;
                result = FindNextIn(startAt, curOffs, false);
            }
        }

        return result;
    }

    private TextRange? FindNextIn(int offset1, int offset2, bool searchBackward)
    {
        offset2 -= LookFor!.Length;

        Func<char, char, bool> matchFirstCh;
        Func<int, bool> matchWord;

        matchFirstCh = MatchCase
            ? ((lookFor, c) => lookFor == c)
            : ((lookFor, c) => lookFor == char.ToUpperInvariant(c));

        matchWord = MatchWholeWordOnly ? IsWholeWordMatch : IsPartWordMatch;

        var lookForCh = _lookFor2[0];

        if (searchBackward)
        {
            for (int offset = offset2; offset >= offset1; offset--)
            {
                if (matchFirstCh(lookForCh, _document!.GetCharAt(offset))
                    && matchWord(offset))
                {
                    return new TextRange(offset, LookFor.Length);
                }
            }
        }
        else
        {
            for (int offset = offset1; offset <= offset2; offset++)
            {
                if (matchFirstCh(lookForCh, _document!.GetCharAt(offset))
                    && matchWord(offset))
                {
                    return new TextRange(offset, LookFor.Length);
                }
            }
        }

        return null;
    }

    private bool IsWholeWordMatch(int offset)
    {
        return IsWordBoundary(offset) && IsWordBoundary(offset + LookFor!.Length) && IsPartWordMatch(offset);
    }

    private bool IsWordBoundary(int offset)
    {
        return offset <= 0 || offset >= _document?.TextLength || !IsAlphaNumeric(offset - 1) || !IsAlphaNumeric(offset);
    }

    private bool IsAlphaNumeric(int offset)
    {
        var c = _document!.GetCharAt(offset);
        return char.IsLetterOrDigit(c) || c == '_';
    }

    private bool IsPartWordMatch(int offset)
    {
        var substr = _document!.GetText(offset, LookFor!.Length);

        if (!MatchCase)
        {
            substr = substr.ToUpperInvariant();
        }

        return substr == _lookFor2;
    }
}