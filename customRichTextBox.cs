using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace sqlite.cs
{
    class customRichTextBox:RichTextBox
    {
        private string dragText;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_KILLFOCUS = 0x8;

        protected override void OnLeave(EventArgs e)
        {
            if (dragText.Length > 0)
            {
                SelectionStart = Text.IndexOf(dragText);
                SelectionLength = dragText.Length;
                SelectionLength = 0;
            }
            base.OnLeave(e);
        }
        //    (EventArgs e)
        //{

        //    base.OnLostFocus(e);
        //}

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_LBUTTONDOWN))
                dragText = SelectedText;
            base.WndProc(ref m);
            Console.WriteLine(m);
        }
    }
}
