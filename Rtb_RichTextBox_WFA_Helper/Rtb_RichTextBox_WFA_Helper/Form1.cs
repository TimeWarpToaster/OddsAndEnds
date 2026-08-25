//Rtb RichTextBox Windows Forms Helper
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Rtb_RichTextBox_WFA_Helper
{
    public partial class Form1 : Form
    {
        public const string CLASSNAME = "Form1";


        public Form1()
        {
            const string location = CLASSNAME + ".Constructor";
            try
            {
                InitializeComponent();

                if (!L.logInit(null, rtbLogs, false))
                {
                    L.err(location, "Failed to initialize as UI logging only.");
                }

                // Load instructions
                if (!loadDocument())
                {
                    L.err(location, "Failed to load document.");
                }

                // Load scratchpad for testing
                if (!test1())
                {
                    L.err(location, "Failed to complete test.");
                }

                // Load about tab
                rtbLicense.Text = License.license;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }


        private bool loadDocument()
        {
            const string location = CLASSNAME + ".loadDocument";
            bool retVal = false;
            try
            {
                L.l(location, "Loading document.");

                FontFamily sectionHeadingFontFamily = new FontFamily("Times New Roman");
                FontFamily paragraphFontFamily = new FontFamily("Segoe UI");
                FontFamily codeFontFamily = new FontFamily("Consolas");

                //int codeIndent = 1;

                Rtb rtb = new Rtb(rtbDocument);
                if (!rtb.isRtbSet)
                {
                    L.err(location, "Failed to create RichTextBox helper.");
                    return retVal;
                }
                rtb.fontFamily(new FontFamily("Calibri"));
                rtb.fontSize(12);

                Color bgcolor = SystemColors.Window;
                if (!rtb.background(bgcolor))
                {
                    L.err(location,
                        "Failed to set background to (" + (bgcolor.Name != null ? bgcolor.Name : "") + ").");
                }
                if (!rtb.foreground(Color.FromArgb(0, 50, 50, 50)))
                {
                    L.err(location, "Failed to set foreground color.");
                }

                string title = "RichTextBox Helper Class";
                rtb.header(title, 24f);
                rtb.align(title.Length, HorizontalAlignment.Center);
                rtb.line();
                string subTitle = "Format Wrappers";
                rtb.header(subTitle, 18f);
                rtb.align(subTitle.Length, HorizontalAlignment.Center);
                rtb.line(2);

                rtb.fontFamily(sectionHeadingFontFamily);
                rtb.header("Purpose", 16f);
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();// extra
                rtb.append(
                    "This app is intended for entry to mid-level developers, tasked with " +
                    "creating in-app documentation, without the use of a WebView, and really want " +
                    "to markup their formatting, without mixing lots of logic throughout their " +
                    "\"document\". Documenting is difficult enough, without trying to read and interpret " +
                    "two separate documents simultaneously."
                );
                rtb.line(2);
                rtb.append(
                    "The RichTextBox helper class, wraps basic formatting functionality for several " +
                    "options, including alignment, font styles and sizes, headers, bulleted lists, and " +
                    "indents. This is to help the programmer, focus on the original task of producing " +
                    "documentation, instructions, etcetera."
                );
                rtb.line(3);

                rtb.fontFamily(sectionHeadingFontFamily);
                rtb.header("Usage", 16f);
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();
                rtb.append(
                    "Usage begins, by adding a RichTextBox to your UI (however you choose to do it), " +
                    "and passing it to the Rtb class. Rtb will hang onto the reference, and manage its " +
                    "own commands to it from there. You still have access to the original RichTextBox, " +
                    "for more advanced manipulations you may choose to make on your own. Rtb does not hang " +
                    "onto any prior status, but rather checks the RichTextBox everytime."
                );
                rtb.line(2);
                rtb.append(
                    "To add a Rtb helper to your code, do something like:"
                );
                rtb.line(2);

                rtb.fontFamily(codeFontFamily);
                rtb.line("    public partial class Form1 : Form");
                rtb.line("    {");
                rtb.line("        private Rtb rtb = null;");
                rtb.line();
                rtb.line("        public Form1()");
                rtb.line("        {");
                rtb.line("            rtb = new Rtb(myRichTextBoxControl);");
                rtb.line("            if (!rtb.isRtbSet)");
                rtb.line("            {");
                rtb.line("                L.err(location, \"Failed to create RichTextBox helper.\");");
                rtb.line("            }");
                rtb.line("        }");
                rtb.line("    }");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(3);

                rtb.bold("Align Text");
                rtb.line(2);
                rtb.line(
                    "To align text, either pass in the string with an alignment option from " +
                    "HorizontalAlignment, or pass the length of the most recently appended " +
                    "string. For alignment to work properly, it is assumed what is being passed " +
                    "is a line, not a partial line. Manage your line breaks before and after " +
                    "calling align."
                );
                rtb.line();
                rtb.line(
                    "When calling align on text that has already been added, using a length, " + 
                    "the added text should be terminated with a new-line. If you called bullet(), " + 
                    "indent(), or line() to add text, the new-line character is added automatically. " + 
                    "If you use append, add a \\n character to your text manually. If you call align, " + 
                    "with text, and allow the function to handle append, it will handle the required " +
                    "new-line character automatically."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.line();");
                rtb.line("    rtb.align(\"My Centered Title\", HorizontalAlignment.Center);");
                rtb.line("    rtb.line();");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();
                rtb.line("-or-");
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.line();");
                rtb.line("    rtb.append(\"My Centered Title\");");
                rtb.line("    rtb.align(17, HorizontalAlignment.Center);");
                rtb.line("    rtb.line();");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();
                rtb.line(
                    "The first option above, has helpers. You can simply call alignCenter(string), " +
                    "alignLeft(string) or alignRight(string)."
                );
                rtb.line(2);


                rtb.bold("Append");
                rtb.line(2);
                rtb.line(
                    "Appends a piece of text to the existing line."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.append(\"The first half \");");
                rtb.line("    rtb.append(\"of a sentence.\");");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Background");
                rtb.line(2);
                rtb.line(
                    "Sets the background color of entire RichTextBox control."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.background(Color.Blue);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Bold");
                rtb.line(2);
                rtb.line(
                    "Appends a piece of text to the existing line as bold, and restores regular " + 
                    "font. All other font properties are preserved."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.bold(text);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Bullet");
                rtb.line(2);
                rtb.line(
                    "Bullet points require an indent level, and a line of text (no partial lines). " + 
                    "A line break will automatically be added to the end of each bullet-point."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.line(\"My List:\");");
                rtb.line("    rtb.bullet(1, \"First Point\");");
                rtb.line("    rtb.bullet(2, \"A sub-point of one.\");");
                rtb.line("    rtb.bullet(1, \"Second Point\");");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);

                rtb.line("Output");
                rtb.line("My List:");
                rtb.bullet(1, "First Point");
                rtb.bullet(2, "A sub - point of one.");
                rtb.bullet(1, "Second Point");
                rtb.line(2);


                rtb.bold("Bulleted List");
                rtb.line(2);
                rtb.line(
                    "A beta-feature. Accepts an indent level, and a list of strings which are " + 
                    "all to be bulleted to the same indent. This is primarily for the simplest " + 
                    "unordered list. You may indent the entire list at-will."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.bulletedList(1, new List<string>() {");
                rtb.line("        \"First Item\",");
                rtb.line("        \"Second Item\",");
                rtb.line("        \"Third Item\"");
                rtb.line("    });");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Font");
                rtb.line(2);
                rtb.line(
                    "Set a font to use."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.font(new Font(");
                rtb.line("        new FontFamily(\"Times New Roman\"),");
                rtb.line("        floatFontSize,");
                rtb.line("        FontStyle.Regular");
                rtb.line("    ));");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Font Family");
                rtb.line(2);
                rtb.line(
                    "Set a font-family by font name. Fonts can vary by system. If you are not sure, " + 
                    "read the array of supported font families by calling either FontFamily.Families " + 
                    "or rtb.supportedFontFamilies(). Many of the preinstalled fonts are there."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    FontFamily fontFamily = new FontFamily(\"Courier New\");");
                rtb.line("    rtb.fontFamily(fontFamily);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Font Size");
                rtb.line(2);
                rtb.line(
                    "Sets the current font-size. Supported font-sizes are 6-200. A float value."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.fontSize(18f);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Font Style");
                rtb.line(2);
                rtb.line(
                    "Sets the font-style. In most circumstances, it is helpful to call rtb.bold(), " + 
                    ".italic(), strike, or underline, and settle for appending. If you expect to " + 
                    "strike many items though, you can set the style to remain."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.fontStyle(FontStyle.Strikeout);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Header");
                rtb.line(2);
                rtb.line(
                    "Accepts a piece of text and a font-size. Bold is applied automatically, along " + 
                    "with a trailing new-line. Expects to start on a new line, but does not require " + 
                    "it. If appending to a line with smaller text, the line will slide down to accommodate."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.header(\"My Medium Header\", 14);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Highlight");
                rtb.line(2);
                rtb.line(
                    "Accepts a piece of text and a Color. The text is appended to any existing " + 
                    "content, with the backcolor set to your choice."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.highlight(\"Important Text\", Color.Yellow);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();
                rtb.line("Output");
                rtb.highlight("Important Text", Color.Yellow);
                rtb.line(2);
                rtb.line(
                    "Highlight can be used with append, to highlight keywords within sentences " + 
                    "or paragraphs."
                );
                rtb.line(2);


                rtb.bold("Indent");
                rtb.line(2);
                rtb.line(
                    "Accepts an indent level and a piece of text. While useful for general " + 
                    "formatting, indent can be used to create an ordered list, assuming you " + 
                    "manage your own numbering as part of the string."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.line(\"An Ordered List\");");
                rtb.line("    rtb.indent(1, \"1)  First Item\");");
                rtb.line("    {");
                rtb.line("        rtb.indent(2, \"1)  First sub-item\");");
                rtb.line("        rtb.indent(2, \"2)  Second sub-item\");");
                rtb.line("    }");
                rtb.line("    rtb.indent(1, \"2)  Second Item\");");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();
                rtb.line("Output");
                rtb.line("An Ordered List");
                rtb.indent(1, "1)  First Item");
                rtb.indent(2, "1)  First sub-item");
                rtb.indent(2, "2)  Second sub-item");
                rtb.indent(1, "2)  Second Item");
                rtb.line(2);


                rtb.bold("Italic");
                rtb.line(2);
                rtb.line(
                    "Accepts a string, and appends it as italic text."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.append(\"Some regular text, next to \");");
                rtb.line("    rtb.italic(\"some italic text\");");
                rtb.line("    rtb.append(\", with more regular text.\");");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Line");
                rtb.line(2);
                rtb.line(
                    "Line is great alternative to rtb.append(), when you know a block of text " + 
                    "finishes with a line-break. There are several ways to call for a line of " + 
                    "text, ending with a break."
                );
                rtb.line();
                rtb.line("An empty line:");
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.line();");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();
                rtb.line("Multiple empty lines (0-1000):");
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.line(3);");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line();
                rtb.line("Text with a single line-break:");
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.line(\"This sentence will end with a new-line.\");");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Strike");
                rtb.line(2);
                rtb.line(
                    "Accepts a string, and appends as \"Strikeout\" or strikethrough text."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.strike(\"Todo item\");");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);


                rtb.bold("Underline");
                rtb.line(2);
                rtb.line(
                    "Accepts a string, and appends as underlined text."
                );
                rtb.line();
                rtb.fontFamily(codeFontFamily);
                rtb.line("    rtb.underline(\"Keyword\");");
                rtb.line("    rtb.append(\" in a sentence.\");");
                rtb.fontFamily(paragraphFontFamily);
                rtb.line(2);




                // Finish document
                rtb.line(2);
                rtb.line("This document was formatted using Rtb.");


                // Flag success for completing
                retVal = true;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        private bool test1()
        {
            const string location = CLASSNAME + ".test1";
            bool retVal = false;
            try
            {
                L.l(location, "Starting test.");

                Rtb rtb = new Rtb(rtbMain);
                if (!rtb.isRtbSet)
                {
                    L.err(location, "Failed to create RichTextBox helper.");
                    return retVal;
                }

                // Set document-wide font properties
                rtb.fontFamily(new FontFamily("Segoe Condensed"));
                rtb.fontSize(11);
                Color bgcolor = SystemColors.Window;
                if (!rtb.background(bgcolor))
                {
                    L.err(location, 
                        "Failed to set background to (" + (bgcolor.Name != null ? bgcolor.Name : "") + ").");
                }
                if (!rtb.foreground(Color.FromArgb(0, 50, 50, 50)))
                {
                    L.err(location, "Failed to set foreground color.");
                }

                // Header test
                rtb.header("Some Header", 24);
                rtb.line();// Line break
                rtb.header("Sub Heading", 18);
                rtb.line();
                rtb.header("Small Heading", 14);
                rtb.line(2);// 2 Line breaks

                // Append test
                rtb.append("Some Random ");
                rtb.append("text fjs7fd5hosfd3");
                rtb.append("and 'a' for line 1.");
                rtb.line(2);

                // Bold test
                rtb.append("Start a new line normal, but ");
                if (!rtb.bold("finish bold")) L.err(location, "Failed to set bold.");
                rtb.append(".");
                rtb.line(2);

                // Append a line as text, with line break added by line()
                rtb.line("Finish off with a third line normal.");

                // Single line break
                rtb.line();

                // Center horizontal
                if (!rtb.alignCenter("We should probably align something center."))
                    L.err(location, "Failed to align center.");
                rtb.line();

                // A single-indent bulleted list, set indent level
                List<string> bulletPoints = new List<string>() { "First point...", "A second point.", "And finally." };
                if (!rtb.bulletedList(1, bulletPoints))
                {
                    L.err(location, "Failed to add bulleted list.");
                }
                rtb.line(2);


                // Bulleted list sample 1
                L.l(location, "Building unordered list sample 1.");
                rtb.bullet(1, "First Point");
                rtb.bullet(2, "Sub point one.");
                rtb.bullet(2, "Sub point two.");

                rtb.bullet(1, "Second Point");
                rtb.bullet(2, "Sub point one.");
                rtb.bullet(2, "Sub point two.");
                rtb.bullet(3, "Mini-point on third tier.");
                rtb.bullet(3, "Sometimes, just as important.");
                rtb.bullet(2, "Sub point three.");

                rtb.bullet(1, "Third Point");
                rtb.bullet(1, "Fourth Point");
                rtb.bullet(1, "Fifth Point");
                rtb.bullet(2, "Two");
                rtb.bullet(2, "More");

                rtb.line(2);


                // Bulleted list sample 2 (write like outline, visual levels)
                L.l(location, "Building unordered list sample 2.");
                rtb.bullet(1, "First Point");
                {
                    rtb.bullet(2, "Sub point one.");
                    rtb.bullet(2, "Sub point two.");
                }
                rtb.bullet(1, "Second Point");
                {
                    rtb.bullet(2, "Sub point one.");
                    rtb.bullet(2, "Sub point two.");
                    {
                        rtb.bullet(3, "Mini-point on third tier.");
                        rtb.bullet(3, "Sometimes, just as important.");
                    }
                    rtb.bullet(2, "Sub point three.");
                }
                rtb.bullet(1, "Third Point");
                rtb.bullet(1, "Fourth Point");
                rtb.bullet(1, "Fifth Point");
                {
                    rtb.bullet(2, "Two");
                    rtb.bullet(2, "More");
                }
                rtb.line(2);


                // Numbered list, with numbers in text, written flat
                L.l(location, "Building ordered list, with numbers in text, assembled flat.");
                rtb.indent(1, "1)  First Point");
                rtb.indent(2, "1)  Sub point one.");
                rtb.indent(2, "2)  Sub point two.");

                rtb.indent(1, "2)  Second Point");
                rtb.indent(2, "1)  Sub point one.");
                rtb.indent(2, "2)  Sub point two.");
                rtb.indent(3, "1)  Mini-point on third tier.");
                rtb.indent(3, "2)  Sometimes, just as important.");
                rtb.indent(2, "3)  Sub point three.");

                rtb.indent(1, "3)  Third Point");
                rtb.indent(1, "4)  Fourth Point");
                rtb.indent(1, "5)  Fifth Point");
                rtb.indent(2, "1)  Two");
                rtb.indent(2, "2)  More");
                rtb.line(2);

                // Numbered list, with numbers in text, written outline
                L.l(location, "Building ordered list, numbers in text, outline style.");
                rtb.indent(1, "1)  First Point");
                {
                    rtb.indent(2, "1)  Sub point one.");
                    rtb.indent(2, "2)  Sub point two.");
                }
                rtb.indent(1, "2)  Second Point");
                {
                    rtb.indent(2, "1)  Sub point one.");
                    rtb.indent(2, "2)  Sub point two.");
                    {
                        rtb.indent(3, "1)  Mini-point on third tier.");
                        rtb.indent(3, "2)  Sometimes, just as important.");
                    }
                    rtb.indent(2, "3)  Sub point three.");
                }
                rtb.indent(1, "3)  Third Point");
                rtb.indent(1, "4)  Fourth Point");
                rtb.indent(1, "5)  Fifth Point");
                {
                    rtb.indent(2, "1)  Two");
                    rtb.indent(2, "2)  More");
                }
                rtb.line(2);


                FontFamily[] fontFamilies = rtb.supportedFontFamilies();
                for (int i = 0; i < fontFamilies.Length; i++)
                    L.l(location, "Font Family: " + fontFamilies[i].Name);


                rtb.line("Some code?:");
                Font oldFont = rtbMain.SelectionFont;
                if (!rtb.font(new Font("Cascadia Code", 12, FontStyle.Regular)))
                {
                    L.err(location, "Failed to set the font.");
                }
                rtb.line("try");
                rtb.line("{");
                rtb.line("    rtb.append(\"Some line text.\");");
                rtb.line("}");
                rtb.line("catch (Exception ex)");
                rtb.line("{");
                rtb.line("    L.ex(location, ex.Message);");
                rtb.line("}");
                if (!rtb.font(oldFont))
                {
                    L.err(location, "Failed to restore the font after snippet.");
                }
                rtb.line(2);

                rtb.line("Some text after restoring original font (" + oldFont.Name + ", " + oldFont.Size + ", " + oldFont.Style.ToString() + ").");
                rtb.line(2);

                /*// Horizontal Rule
                L.l(location, "Inserting horizontal rule.");
                if (!rtb.hr(10))
                {
                    L.err(location, "Failed to insert horizontal rule.");
                }
                rtb.line(2);*/

                rtb.append("We should highlight ");
                rtb.highlight("Something", Color.Yellow);
                rtb.append(" here.");
                rtb.line(2);



                rtb.line("And try some different font styles.");
                rtb.line();
                rtb.italic("Some italic text.");
                rtb.line();
                rtb.strike("Strikethrough text.");
                rtb.line();
                rtb.underline("Underlined text.");
                rtb.line(2);


                rtb.line(2);
                rtb.header("My First Book", 18);
                rtb.line();
                rtb.line("A compendium example.");
                rtb.line();
                Compendium book = new Compendium();
                book.lineBreaksBefore = 1;
                book.lineBreaksAfter = 1;
                book.headingFont = new Font(
                    new FontFamily("Helvetica"),
                    16,
                    FontStyle.Bold
                );
                book.itemFont = new Font(
                    new FontFamily("Calibri"),
                    12,
                    FontStyle.Regular
                );
                book.subjects.Add("First Section", new List<string>()
                {
                    "There are three paragraphs about nothing in the first section. This is not " + 
                    "a very long section, but just long enough to prove a point."
                    ,
                    "The second paragraph contains nothing new except the second paragraph contains " +
                    "nothing new and the word except. There are three paragraphs about nothing in " + 
                    "the first section. This is not a very long section, but just long enough to " + 
                    "prove a point."
                    ,
                    "The third paragraph is totally relevant."
                });
                book.subjects.Add("Second Section", new List<string>()
                {
                    "The two paragraphs that follow, are better than before. First, they are " + 
                    "shorter."
                    ,
                    "Second, they make more sense."
                });
                book.subjects.Add("Summary", new List<string>()
                {
                    "To summarize, there was not much content in the first section, and the " + 
                    "second was more for having less of the same; not-with-standing, the " + 
                    "purpose has been served, and there is now enough content to test with."
                });

                rtb.compendium(book);





                L.l(location, "Finishing test.");

                // Flag success for completing
                retVal = true;
                return retVal;
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".exitToolStripMenuItem_Click";
            try
            {
                L.l(location, "App exiting from menu item.");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            const string location = CLASSNAME + ".btnClearLogs_Click";
            try
            {
                long cntLengthCleared = L.clearLogs();
                L.l(location, "Cleared (" + cntLengthCleared + ") log length.");
            }   
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
        }
    }
}
