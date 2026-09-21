using System;
using System.Windows.Forms;

namespace ImageRegionAnalysis2
{
    public static class Ui
    {
        public const string CLASSNAME = "Ui";



        public static bool Append(ListBox control, string content)
        {
            bool retVal = false;
            if (control == null) return retVal;
            if (content == null) return retVal; ;
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => { retVal = Ui.Append(control, content); }));
            }
            else 
            {
                if (control.Items == null) return retVal;
                control.Items.Add(content);
                retVal = true;
            }
            return retVal;
        }
        public static bool Append(FlowLayoutPanel control, Control[] controls) 
        {
            const string location = CLASSNAME + ".Append(flw)";
            bool retVal = false;
            try
            {
                if (control == null) return retVal;
                if (controls == null) return retVal;
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => { retVal = Ui.Append(control, controls); }));
                }
                else
                {
                    control.Controls.AddRange(controls);
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }
        public static bool Append(RichTextBox control, string content)
        {
            const string location = CLASSNAME + ".Append(rtb)";
            bool retVal = false;
            try
            {
                if (control == null) return retVal;
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => { retVal = Ui.Append(control, content); }));
                }
                else
                {
                    control.AppendText(content);
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


        public static bool Checked(CheckBox control) { return Ui.Checked(control, false); }
        public static bool Checked(CheckBox control, bool logErrors)
        {
            const string location = CLASSNAME + ".Checked(cb)";
            bool retVal = false;
            try
            {
                if (control == null)
                {
                    if (logErrors) L.err(location, "Input control was null.");
                    return retVal;
                }

                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => { retVal = Ui.Checked(control, logErrors); }));
                }
                else 
                {
                    retVal = control.Checked;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }
        public static bool Checked(NumericUpDown control) { return Ui.Checked(control, false); }
        public static bool Checked(NumericUpDown control, bool logErrors)
        {
            const string location = CLASSNAME + ".Checked(num)";
            bool retVal = false;
            try
            {
                if (control == null)
                {
                    if (logErrors) L.err(location, "Input control was null.");
                    return retVal;
                }

                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => { retVal = Ui.Checked(control, logErrors); }));
                }
                else
                {
                    int val = (int)control.Value;
                    retVal = val == 1;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }
        public static bool Checked(RadioButton control) { return Ui.Checked(control, false); }
        public static bool Checked(RadioButton control, bool logErrors)
        {
            const string location = CLASSNAME + ".Checked(rb)";
            bool retVal = false;
            try
            {
                if (control == null)
                {
                    if (logErrors) L.err(location, "Input control was null.");
                    return retVal;
                }

                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => { retVal = Ui.Checked(control, logErrors); }));
                }
                else
                {
                    retVal = control.Checked;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }
        public static bool Checked(TextBox control) { return Ui.Checked(control, false); }
        public static bool Checked(TextBox control, bool logErrors)
        {
            const string location = CLASSNAME + ".Checked(tb)";
            bool retVal = false;
            try
            {
                if (control == null)
                {
                    if (logErrors) L.err(location, "Input control was null.");
                    return retVal;
                }

                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => { retVal = Ui.Checked(control, logErrors); }));
                }
                else
                {
                    string value = control.Text.Trim().ToUpper();
                    retVal = "TRUE" == value;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }



        public static bool Clear(FlowLayoutPanel flowLayoutPanel)
        {
            const string location = CLASSNAME + ".Clear";
            bool retVal = false;
            try
            {
                if (flowLayoutPanel == null) return retVal;
                if (flowLayoutPanel.InvokeRequired)
                {
                    flowLayoutPanel.Invoke(new Action(() => { retVal = Ui.Clear(flowLayoutPanel); }));
                }
                else 
                {
                    flowLayoutPanel.Controls.Clear();
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool Clear(DataGridView control, bool clearHeaders)
        {
            const string location = CLASSNAME + ".Clear(dgv)";
            bool retVal = false;
            try
            {
                if (control == null) return retVal;
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => { retVal = Ui.Clear(control, clearHeaders); }));
                }
                else
                {
                    control.Rows.Clear();
                    //if (clearHeaders) control.
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool Clear(ListBox lb)
        {
            const string location = CLASSNAME + ".Clear(lb)";
            bool retVal = false;
            try
            {
                if (lb == null) return retVal;
                if (lb.InvokeRequired)
                {
                    lb.Invoke(new Action(() => { retVal = Ui.Clear(lb); }));
                }
                else
                {
                    lb.Items.Clear();
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool Clear(PictureBox pb)
        {
            const string location = CLASSNAME + ".Clear(pb)";
            bool retVal = false;
            try
            {
                if (pb == null) return retVal;
                if (pb.InvokeRequired)
                {
                    pb.Invoke(new Action(() => { retVal = Ui.Clear(pb); }));
                }
                else
                {
                    pb.Image = null;
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }

        public static bool Clear(RichTextBox rtb)
        {
            const string location = CLASSNAME + ".Clear(rtb)";
            bool retVal = false;
            try
            {
                if (rtb == null) return retVal;
                if (rtb.InvokeRequired)
                {
                    rtb.Invoke(new Action(() => { retVal = Ui.Clear(rtb); }));
                }
                else 
                {
                    rtb.Text = "";
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }



        public static bool Set(RichTextBox rtb, string body)
        {
            const string location = CLASSNAME + ".Set(rtb)";
            bool retVal = false;
            try
            {
                if (rtb == null) return retVal;
                if (rtb.InvokeRequired)
                {
                    rtb.Invoke(new Action(() => {
                        retVal = Ui.Set(rtb, body);
                    }));
                }
                else 
                {
                    rtb.Text = body == null ? "" : body;
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                L.ex(location, ex);
            }
            return retVal;
        }


    }
}
