\# RichTextBox Helper Class



\## Format Wrappers



<br />





\## Purpose



This app is intended for entry to mid-level developers, tasked with creating in-app documentation, without the use of a WebView, and really want to markup their formatting, without mixing lots of logic throughout their "document". Documenting is difficult enough, without trying to read and interpret two separate documents simultaneously.



The RichTextBox helper class, wraps basic formatting functionality for several options, including alignment, font styles and sizes, headers, bulleted lists, and indents. This is to help the programmer, focus on the original task of producing documentation, instructions, etcetera.





\## Usage



Usage begins, by adding a RichTextBox to your UI (however you choose to do it), and passing it to the Rtb class. Rtb will hang onto the reference, and manage its own commands to it from there. You still have access to the original RichTextBox, for more advanced manipulations you may choose to make on your own. Rtb does not hang onto any prior status, but rather checks the RichTextBox everytime.



To add a Rtb helper to your code, do something like:



&#x20;   public partial class Form1 : Form

&#x20;   {

&#x20;       private Rtb rtb = null;



&#x20;       public Form1()

&#x20;       {

&#x20;           rtb = new Rtb(myRichTextBoxControl);

&#x20;           if (!rtb.isRtbSet)

&#x20;           {

&#x20;               L.err(location, "Failed to create RichTextBox helper.");

&#x20;           }

&#x20;       }

&#x20;   }







\### Align Text



To align text, either pass in the string with an alignment option from HorizontalAlignment, or pass the length of the most recently appended string. For alignment to work properly, it is assumed what is being passed is a line, not a partial line. Manage your line breaks before and after calling align.



When calling align on text that has already been added, using a length, the added text should be terminated with a new-line. If you called bullet(), indent(), or line() to add text, the new-line character is added automatically. If you use append, add a \\n character to your text manually. If you call align, with text, and allow the function to handle append, it will handle the required new-line character automatically.



&#x20;   rtb.line();

&#x20;   rtb.align("My Centered Title", HorizontalAlignment.Center);

&#x20;   rtb.line();



\-or-



&#x20;   rtb.line();

&#x20;   rtb.append("My Centered Title");

&#x20;   rtb.align(17, HorizontalAlignment.Center);

&#x20;   rtb.line();



The first option above, has helpers. You can simply call alignCenter(string), alignLeft(string) or alignRight(string).





\### Append



Appends a piece of text to the existing line.



&#x20;   rtb.append("The first half ");

&#x20;   rtb.append("of a sentence.");





Background



Sets the background color of entire RichTextBox control.



&#x20;   rtb.background(Color.Blue);





\### Bold



Appends a piece of text to the existing line as bold, and restores regular font. All other font properties are preserved.



&#x20;   rtb.bold(text);





\### Bullet



Bullet points require an indent level, and a line of text (no partial lines). A line break will automatically be added to the end of each bullet-point.



&#x20;   rtb.line("My List:");

&#x20;   rtb.bullet(1, "First Point");

&#x20;   rtb.bullet(2, "A sub-point of one.");

&#x20;   rtb.bullet(1, "Second Point");





\### Bulleted List



A beta-feature. Accepts an indent level, and a list of strings which are all to be bulleted to the same indent. This is primarily for the simplest unordered list. You may indent the entire list at-will.



&#x20;   rtb.bulletedList(1, new List<string>() {

&#x20;       "First Item",

&#x20;       "Second Item",

&#x20;       "Third Item"

&#x20;   });





\### Font



Set a font to use.



&#x20;   rtb.font(new Font(

&#x20;       new FontFamily("Times New Roman"),

&#x20;       floatFontSize,

&#x20;       FontStyle.Regular

&#x20;   ));





\### Font Family



Set a font-family by font name. Fonts can vary by system. If you are not sure, read the array of supported font families by calling either FontFamily.Families or rtb.supportedFontFamilies(). Many of the preinstalled fonts are there.



&#x20;   FontFamily fontFamily = new FontFamily("Courier New");

&#x20;   rtb.fontFamily(fontFamily);





\### Font Size



Sets the current font-size. Supported font-sizes are 6-200. A float value.



&#x20;   rtb.fontSize(18f);





\### Font Style



Sets the font-style. In most circumstances, it is helpful to call rtb.bold(), .italic(), strike, or underline, and settle for appending. If you expect to strike many items though, you can set the style to remain.



&#x20;   rtb.fontStyle(FontStyle.Strikeout);





\### Header



Accepts a piece of text and a font-size. Bold is applied automatically, along with a trailing new-line. Expects to start on a new line, but does not require it. If appending to a line with smaller text, the line will slide down to accommodate.



&#x20;   rtb.header("My Medium Header", 14);





\### Highlight



Accepts a piece of text and a Color. The text is appended to any existing content, with the backcolor set to your choice.



&#x20;   rtb.highlight("Important Text", Color.Yellow);



Highlight can be used with append, to highlight keywords within sentences or paragraphs.





\### Indent



Accepts an indent level and a piece of text. While useful for general formatting, indent can be used to create an ordered list, assuming you manage your own numbering as part of the string.



&#x20;   rtb.line("An Ordered List");

&#x20;   rtb.indent(1, "1)  First Item");

&#x20;   {

&#x20;       rtb.indent(2, "1)  First sub-item");

&#x20;       rtb.indent(2, "2)  Second sub-item");

&#x20;   }

&#x20;   rtb.indent(1, "2)  Second Item");





\### Italic



Accepts a string, and appends it as italic text.



&#x20;   rtb.append("Some regular text, next to ");

&#x20;   rtb.italic("some italic text");

&#x20;   rtb.append(", with more regular text.");





\### Line



Line is great alternative to rtb.append(), when you know a block of text finishes with a line-break. There are several ways to call for a line of text, ending with a break.



An empty line:



&#x20;   rtb.line();



Multiple empty lines (0-1000):



&#x20;   rtb.line(3);



Text with a single line-break:



&#x20;   rtb.line("This sentence will end with a new-line.");





\### Strike



Accepts a string, and appends as "Strikeout" or strikethrough text.



&#x20;   rtb.strike("Todo item");





\### Underline



Accepts a string, and appends as underlined text.



&#x20;   rtb.underline("Keyword");

&#x20;   rtb.append(" in a sentence.");



<br />

<br />

<br />

