using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class MyButton : Button
    {

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(Brushes.Gray, ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.CadetBlue, ClientRectangle);
        }
    }
}
