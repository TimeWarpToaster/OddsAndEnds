# RichTextBox Helper Class



## Format Wrappers

<br />

## Purpose

This app is intended for entry to mid-level developers, tasked with creating in-app documentation, without the use of a WebView, and really want to markup their formatting, without mixing lots of logic throughout their "document". Documenting is difficult enough, without trying to read and interpret two separate documents simultaneously.

The RichTextBox helper class, wraps basic formatting functionality for several options, including alignment, font styles and sizes, headers, bulleted lists, and indents. This is to help the programmer, focus on the original task of producing documentation, instructions, etcetera.


## Usage

Usage begins, by adding a RichTextBox to your UI (however you choose to do it), and passing it to the Rtb class. Rtb will hang onto the reference, and manage its own commands to it from there. You still have access to the original RichTextBox, for more advanced manipulations you may choose to make on your own. Rtb does not hang onto any prior status, but rather checks the RichTextBox everytime.

To add a Rtb helper to your code, do something like:

<pre>
   public partial class Form1 : Form
   {
       private Rtb rtb = null;

       public Form1()
       {
           rtb = new Rtb(myRichTextBoxControl);
           if (!rtb.isRtbSet)
           {
               L.err(location, "Failed to create RichTextBox helper.");
           }
       }
   }
</pre>



### Align Text

To align text, either pass in the string with an alignment option from HorizontalAlignment, or pass the length of the most recently appended string. For alignment to work properly, it is assumed what is being passed is a line, not a partial line. Manage your line breaks before and after calling align.

When calling align on text that has already been added, using a length, the added text should be terminated with a new-line. If you called bullet(), indent(), or line() to add text, the new-line character is added automatically. If you use append, add a \\n character to your text manually. If you call align, with text, and allow the function to handle append, it will handle the required new-line character automatically.

<pre>
   rtb.line();
   rtb.align("My Centered Title", HorizontalAlignment.Center);
   rtb.line();
</pre>

-or-

<pre>
   rtb.line();
   rtb.append("My Centered Title");
   rtb.align(17, HorizontalAlignment.Center);
   rtb.line();
</pre>

The first option above, has helpers. You can simply call alignCenter(string), alignLeft(string) or alignRight(string).


### Append

Appends a piece of text to the existing line.

<pre>
   rtb.append("The first half ");
   rtb.append("of a sentence.");
</pre>


### Background

Sets the background color of entire RichTextBox control.

<pre>
   rtb.background(Color.Blue);
</pre>


### Bold

Appends a piece of text to the existing line as bold, and restores regular font. All other font properties are preserved.

<pre>
   rtb.bold(text);
</pre>


### Bullet

Bullet points require an indent level, and a line of text (no partial lines). A line break will automatically be added to the end of each bullet-point.

<pre>
   rtb.line("My List:");
   rtb.bullet(1, "First Point");
   rtb.bullet(2, "A sub-point of one.");
   rtb.bullet(1, "Second Point");
</pre>
   

### Bulleted List

A beta-feature. Accepts an indent level, and a list of strings which are all to be bulleted to the same indent. This is primarily for the simplest unordered list. You may indent the entire list at-will.

<pre>
   rtb.bulletedList(1, new List< string >() {
       "First Item",
       "Second Item",
       "Third Item"
   });
</pre>


### Font

Set a font to use.

<pre>
   rtb.font(new Font(
       new FontFamily("Times New Roman"),
       floatFontSize,
       FontStyle.Regular
   ));
</pre>


### Font Family

Set a font-family by font name. Fonts can vary by system. If you are not sure, read the array of supported font families by calling either FontFamily.Families or rtb.supportedFontFamilies(). Many of the preinstalled fonts are there.

<pre>
   FontFamily fontFamily = new FontFamily("Courier New");
   rtb.fontFamily(fontFamily);
</pre>


### Font Size

Sets the current font-size. Supported font-sizes are 6-200. A float value.

<pre>
   rtb.fontSize(18f);
</pre>


### Font Style

Sets the font-style. In most circumstances, it is helpful to call rtb.bold(), .italic(), strike, or underline, and settle for appending. If you expect to strike many items though, you can set the style to remain.

<pre>
   rtb.fontStyle(FontStyle.Strikeout);
</pre>


### Header

Accepts a piece of text and a font-size. Bold is applied automatically, along with a trailing new-line. Expects to start on a new line, but does not require it. If appending to a line with smaller text, the line will slide down to accommodate.

<pre>
   rtb.header("My Medium Header", 14);
</pre>


### Highlight

Accepts a piece of text and a Color. The text is appended to any existing content, with the backcolor set to your choice.

<pre>
   rtb.highlight("Important Text", Color.Yellow);
</pre>

Highlight can be used with append, to highlight keywords within sentences or paragraphs.


### Indent

Accepts an indent level and a piece of text. While useful for general formatting, indent can be used to create an ordered list, assuming you manage your own numbering as part of the string.

<pre>
   rtb.line("An Ordered List");
   rtb.indent(1, "1)  First Item");
   {
       rtb.indent(2, "1)  First sub-item");
       rtb.indent(2, "2)  Second sub-item");
   }
   rtb.indent(1, "2)  Second Item");
</pre>


### Italic

Accepts a string, and appends it as italic text.

<pre>
   rtb.append("Some regular text, next to ");
   rtb.italic("some italic text");
   rtb.append(", with more regular text.");
</pre>


### Line

Line is great alternative to rtb.append(), when you know a block of text finishes with a line-break. There are several ways to call for a line of text, ending with a break.

An empty line:

<pre>
   rtb.line();
</pre>

Multiple empty lines (0-1000):

<pre>
   rtb.line(3);
</pre>

Text with a single line-break:

<pre>
   rtb.line("This sentence will end with a new-line.");
</pre>


### Strike

Accepts a string, and appends as "Strikeout" or strikethrough text.

<pre>
   rtb.strike("Todo item");
</pre>


### Underline

Accepts a string, and appends as underlined text.

<pre>
   rtb.underline("Keyword");
   rtb.append(" in a sentence.");
</pre>

<br />
<br />
<br />
