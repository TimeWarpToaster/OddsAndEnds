//Rtb RichTextBox Windows Forms Helper
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Rtb_RichTextBox_WFA_Helper
{
    public class Compendium
    {
        /*
         * You do not need to use a compendium. It is a glossary like structure,
         * {
         *     "Topic 1": { "Paragraph 1", "Paragraph 2", ... },
         *     "Topic Heading 2": {"Paragraph 1"}
         * }
         * Where the list of headings and paragraphs are produced with appropriate formatting.
         * Note:  headings must be unique as Dictionary keys, duplicates will throw exception.
         */
        public Font headingFont = null;
        public Font itemFont = null;
        public int lineBreaksBefore = 0;
        public int lineBreaksAfter = 2;
        public Dictionary<string, List<string>> subjects = new Dictionary<string, List<string>>();
    }

    public class Rtb
    {
        public const string CLASSNAME = "Rtb";

        private RichTextBox rtb { get; set; }
        public bool isRtbSet => this.rtb != null;


        public int indentSize = 20;



        public Rtb(RichTextBox rtbIn)
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                if (!this.init(rtbIn))
                {
                    L.err(location, "Failed to initialize RichTextBox helper.");
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }


        public bool init(RichTextBox rtbIn)
        {
            const string location = CLASSNAME + ".init";
            bool retVal = false;
            try
            {
                if (rtbIn == null)
                {
                    L.err(location, "Input rtb was null.");
                    return retVal;
                }
                this.rtb = rtbIn;

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        // Align most recently added text (should be a line, for alignment)
        public bool align(int length, HorizontalAlignment alignment)
        {
            const string location = CLASSNAME + ".align(i,a)";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (length == 0)
                {
                    return true;
                }

                L.l(location, "Aligning text length (" + length + ") (" + alignment.ToString() + ").");

                // Aligning text clears selection font, save and restore
                Font selectionFont = this.rtb.SelectionFont;

                // Select text and align
                HorizontalAlignment alignmentStart = this.rtb.SelectionAlignment;
                this.rtb.Select(this.rtb.Text.Length - length, length);
                this.rtb.SelectionAlignment = alignment;

                // Restore caret position to end of entry, set starting alignment
                this.rtb.Select(this.rtb.Text.Length, 0);
                this.rtb.SelectionAlignment = alignmentStart;
                this.rtb.SelectionFont = selectionFont;

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // Append line and align
        public bool align(string text, HorizontalAlignment alignment)
        {
            const string location = CLASSNAME + ".align(s,a)";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (text == null)
                {
                    L.err(location, "Input text was null.");
                    return retVal;
                }
                if (text.Length == 0)
                {
                    retVal = true;
                    return retVal;
                }

                L.l(location, "Appending text (" + text + ") as (" + alignment.ToString() + ").");
                //this.append(text);
                //retVal = this.align(text.Length, alignment);



                // Aligning text clears selection font, save and restore
                Font selectionFont = this.rtb.SelectionFont;


                int start = this.rtb.Text.Length;
                HorizontalAlignment alignmentStart = this.rtb.SelectionAlignment;
                this.append(text);

                // Select text and align
                this.rtb.Select(start, text.Length);
                this.rtb.SelectionAlignment = alignment;
                this.rtb.AppendText(Environment.NewLine);

                // Restore caret position to end of entry, set starting alignment
                this.rtb.Select(this.rtb.Text.Length, 0);
                this.rtb.SelectionAlignment = alignmentStart;
                this.rtb.SelectionFont = selectionFont;

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        // Append line and align
        public bool alignCenter(string text)
        {
            return this.align(text, HorizontalAlignment.Center);
        }
        public bool alignLeft(string text)
        {
            return this.align(text, HorizontalAlignment.Left);
        }
        public bool alignRight(string text)
        {
            return this.align(text, HorizontalAlignment.Right);
        }

        // Append text, adds words does not add line
        public bool append(string text)
        {
            const string location = CLASSNAME + ".append";
            bool retVal = false;
            try
            {
                if (this.rtb == null || text == null) return retVal;

                Font selectionFont = this.rtb.SelectionFont;

                this.rtb.AppendText(text);

                // Filter for curly braces, they will clear the SelectionFont
                if (text.IndexOf("{") >= 0 || text.IndexOf("}") >= 0)
                { 
                    this.rtb.Select(this.rtb.Text.Length - text.Length, this.rtb.Text.Length);
                    this.rtb.SelectionFont = selectionFont;
                    this.rtb.Select(this.rtb.Text.Length, 0);
                }

                // New line clears selection font, filter and restore
                int idxNewLine = text.IndexOf(Environment.NewLine);
                if (idxNewLine < 0) idxNewLine = text.IndexOf("\n");
                if (idxNewLine < 0) idxNewLine = text.IndexOf("\r");
                if (idxNewLine >= 0)
                {
                    this.rtb.SelectionFont = selectionFont;
                }

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool appendStyle(string text, FontStyle style)
        {
            const string location = CLASSNAME + ".bold(r,s)";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "Input view was null.");
                    return retVal;
                }
                if (text == null)
                {
                    L.err(location, "Input text was null.");
                    return retVal;
                }
                if (text.Length == 0)
                {
                    retVal = true;
                    return retVal;
                }

                // Send text to rtb
                FontStyle priorStyle = this.rtb.SelectionFont.Style;
                int start = this.rtb.Text.Length;
                this.append(text);

                // Select text and bold
                this.rtb.Select(start, text.Length);
                this.rtb.SelectionFont = new Font(this.rtb.SelectionFont, style);

                // Restore caret position to end of entry, set prior style
                this.rtb.Select(this.rtb.Text.Length, 0);
                this.rtb.SelectionStart = this.rtb.Text.Length;
                this.rtb.SelectionLength = 0;
                this.rtb.SelectionFont = new Font(this.rtb.SelectionFont, priorStyle);

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool background(Color color)
        {
            const string location = CLASSNAME + ".background";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "Input view was null.");
                    return retVal;
                }
                if (color == null)
                {
                    L.err(location, "Input color was null.");
                    return retVal;
                }

                this.rtb.BackColor = color;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool bold(string text)
        {
            const string location = CLASSNAME + ".bold(r,s)";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "Input view was null.");
                    return retVal;
                }
                if (text == null)
                {
                    L.err(location, "Input text was null.");
                    return retVal;
                }
                if (text.Length == 0)
                {
                    retVal = true;
                    return retVal;
                }
                L.l(location, "Appending text as bold (" + text + ").");

                // Send text to rtb
                int start = this.rtb.Text.Length;
                this.append(text);

                // Select text and bold
                this.rtb.Select(start, text.Length);
                this.rtb.SelectionFont = new Font(this.rtb.SelectionFont, FontStyle.Bold);

                L.l(location, "Bold start (" + this.rtb.SelectionStart + "), length (" + this.rtb.SelectionLength +
                    "), out of (" + this.rtb.Text.Length + ").");

                // Restore caret position to end of entry, set regular font
                this.rtb.SelectionStart = this.rtb.Text.Length;
                this.rtb.SelectionLength = 0;
                this.rtb.SelectionFont = new Font(this.rtb.SelectionFont, FontStyle.Regular);

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool bullet(int indentLevel, string text)
        {
            const string location = CLASSNAME + ".bulletedList";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "Input view was null.");
                    return retVal;
                }
                if (text == null)
                {
                    L.err(location, "Input list was null.");
                    return retVal;
                }
                // Get our original indent position
                int selectionIndentStart = this.rtb.SelectionIndent;

                // Add bullet point and text
                this.rtb.Select(this.rtb.Text.Length, 0);
                this.rtb.SelectionIndent = indentLevel * this.indentSize;// bullet indent from left
                this.rtb.SelectionBullet = true;
                this.rtb.BulletIndent = 15;// text indent from bullet
                this.append(text + Environment.NewLine);

                // Restore prior document indent
                this.rtb.SelectionIndent = selectionIndentStart;
                this.rtb.SelectionBullet = false;

                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool bulletedList(int indentLevel, List<string> texts)
        {
            const string location = CLASSNAME + ".bulletedList";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "Input view was null.");
                    return retVal;
                }
                if (texts == null)
                {
                    L.err(location, "Input list was null.");
                    return retVal;
                }
                if (texts.Count == 0)
                {
                    retVal = true;
                    return retVal;
                }

                int cntWritten = 0;

                // Get original indent
                int selectionIndentStart = this.rtb.SelectionIndent;

                // Move to end of document, set bullet format
                this.rtb.Select(this.rtb.Text.Length, 0);
                this.rtb.SelectionIndent = indentLevel * this.indentSize;// TODO - Add indent levels and variable
                this.rtb.SelectionBullet = true;
                this.rtb.BulletIndent = 15;

                // Add bullet points
                for (int i = 0; i < texts.Count; i++)
                {
                    this.append(texts[i] + Environment.NewLine);
                    cntWritten++;
                }

                // Restore prior indent
                this.rtb.SelectionIndent = selectionIndentStart;
                this.rtb.SelectionBullet = false;

                retVal = cntWritten == texts.Count;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool compendium(Compendium book)
        {
            const string location = CLASSNAME + ".compendium";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (book == null)
                {
                    L.err(location, "Input was null.");
                    return retVal;
                }
                if (book.subjects == null)
                {
                    L.err(location, "Input subjects were null.");
                    return retVal;
                }
                if (book.subjects.Count == 0)
                {
                    retVal = true;
                    return retVal;
                }

                Font oldFont = this.rtb.SelectionFont;

                Font headingFont = book.headingFont != null ? book.headingFont : oldFont;
                Font itemFont = book.itemFont != null ? book.itemFont : oldFont;
                foreach (KeyValuePair<string, List<string>> kv in book.subjects)
                {
                    // Handle breaks before subject
                    if (book.lineBreaksBefore > 0 && book.lineBreaksBefore < 10)
                    {
                        this.line(book.lineBreaksBefore);
                    }

                    // Add heading
                    this.font(headingFont);
                    this.append(kv.Key);
                    this.font(itemFont);
                    this.line(2);

                    // Loop if there are no items
                    if (kv.Value == null) continue;

                    // Add each paragraph
                    for (int i = 0; i < kv.Value.Count; i++)
                    {
                        this.line(kv.Value[i]);
                        this.line();
                    }

                    // Restore old font
                    this.font(oldFont);

                    // Add breaks after subject
                    if (book.lineBreaksAfter > 0 && book.lineBreaksAfter < 10)
                    {
                        this.line(book.lineBreaksAfter);
                    }
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool font(Font inFont)
        {
            if (this.rtb != null && inFont != null)
            {
                this.rtb.SelectionFont = inFont;
                return true;
            }
            return false;
        }

        public bool font(FontFamily inFontFamily, float inFontSize, FontStyle? inFontStyle)
        {
            const string location = CLASSNAME + ".font(f,f,f)";
            bool retVal = false;
            try
            {
                // Validate input
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (inFontSize < 6 || inFontSize > 200)
                {
                    L.err(location, "Requested font-size (" + inFontSize + ") out of range (6-200).");
                    return retVal;
                }

                this.rtb.SelectionFont = new Font(
                    inFontFamily != null ? inFontFamily : this.rtb.SelectionFont.FontFamily,
                    inFontSize,
                    inFontStyle != null ? (FontStyle)inFontStyle : this.rtb.SelectionFont.Style
                );
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool fontFamily(FontFamily inFontFamily)
        {
            const string location = CLASSNAME + ".fontFamily";
            bool retVal = false;
            try
            {
                // Validate input
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (inFontFamily == null)
                {
                    L.err(location, "Input font-family was null.");
                    return retVal;
                }
                this.rtb.SelectionFont =
                    new Font(inFontFamily, this.rtb.SelectionFont.Size, this.rtb.SelectionFont.Style);
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool fontSize(float inFontSize)
        {
            const string location = CLASSNAME + ".fontSize";
            bool retVal = false;
            try
            {
                // Validate input
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (inFontSize < 6 || inFontSize > 200)
                {
                    L.err(location, "Requested font-size (" + inFontSize + ") out of range (6-200).");
                    return retVal;
                }
                this.rtb.SelectionFont = 
                    new Font(this.rtb.SelectionFont.FontFamily, inFontSize, this.rtb.SelectionFont.Style);
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool fontStyle(FontStyle inFontStyle)
        {
            const string location = CLASSNAME + ".fontStyle";
            bool retVal = false;
            try
            {
                // Validate input
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                this.rtb.SelectionFont = new Font(
                    this.rtb.SelectionFont.FontFamily, 
                    this.rtb.SelectionFont.Size, 
                    inFontStyle
                );
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool foreground(Color color)
        {
            const string location = CLASSNAME + ".foreground";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (color == null)
                {
                    L.err(location, "Input color was null");
                    return retVal;
                }
                this.rtb.ForeColor = color;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool header(string header, float fontSize)
        {
            const string location = CLASSNAME + ".header";
            bool retVal = false;
            try
            {
                // Validate input
                if (this.rtb == null)
                {
                    L.err(location, "View was null.");
                    return retVal;
                }
                if (header == null)
                {
                    L.err(location, "Input text was null.");
                    return retVal;
                }
                if (header.Length == 0)
                {
                    retVal = true;
                    return retVal;// nothing to do
                }
                if (fontSize < 6 || fontSize > 200)
                {
                    L.err(location, "Requested font-size (" + fontSize + ") out of range (6-200).");
                    return retVal;
                }

                Font startFont = this.rtb.SelectionFont;
                Font tempFont = new Font(this.rtb.SelectionFont.FontFamily, fontSize, FontStyle.Bold);
                this.rtb.SelectionFont = tempFont;
                this.append(header);
                this.rtb.SelectionFont = startFont;
                this.append(Environment.NewLine);

                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool highlight(string text, Color color)
        {
            const string location = CLASSNAME + ".highlight";
            bool retVal = false;
            try
            {
                int selectionStart = this.rtb.Text.Length;
                if (!this.append(text))
                {
                    L.err(location, "Failed to append highlight text.");
                    return retVal;
                }
                // Get the current selection back color, default to rtb backcolor if not available
                Color oldColor = this.rtb.SelectionBackColor;
                if (oldColor == null) oldColor = this.rtb.BackColor;

                // Select and highlight
                int selectionEnd = this.rtb.Text.Length;
                this.rtb.Select(selectionStart, selectionEnd);
                this.rtb.SelectionBackColor = color;

                // Move to end, restore backcolor
                this.rtb.Select(this.rtb.Text.Length, 0);
                this.rtb.SelectionBackColor = oldColor;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool indent(int indentLevel, string text)
        {
            const string location = CLASSNAME + ".indent";
            bool retVal = false;
            try
            {
                if (this.rtb == null)
                {
                    L.err(location, "Input view was null.");
                    return retVal;
                }
                if (text == null)
                {
                    L.err(location, "Input list was null.");
                    return retVal;
                }
                // Get original indent level
                int selectionIndentStart = this.rtb.SelectionIndent;

                // Append indented text
                this.rtb.Select(this.rtb.Text.Length, 0);
                this.rtb.SelectionIndent = indentLevel * this.indentSize;
                this.append(text + Environment.NewLine);

                // Restore original indent level
                this.rtb.SelectionIndent = selectionIndentStart;
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public bool italic(string text)
        {
            return this.appendStyle(text, FontStyle.Italic);
        }

        public bool line() 
        {
            return this.append(Environment.NewLine);
        }

        public bool line(int numEmptyLines)
        {
            if (numEmptyLines < 0 || numEmptyLines > 1000) return false;// there shouldn't be an upper limit, 1000 seems reasonable
            string s = "";
            for (int i = 0; i < numEmptyLines; i++) s += Environment.NewLine;
            return this.append(s);
        }

        public bool line(string text)
        {
            return this.append((text == null ? "" : @text) + Environment.NewLine);
        }

        public bool strike(string text)
        {
            return this.appendStyle(text, FontStyle.Strikeout);
        }

        public FontFamily[] supportedFontFamilies()
        {
            return FontFamily.Families;
        }

        public bool underline(string text)
        {
            return this.appendStyle(text, FontStyle.Underline);
        }


    }
}
