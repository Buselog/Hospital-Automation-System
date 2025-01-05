using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneSistemOtomasyonu
{
    internal class TransparentButton : Button
    {

        public TransparentButton()
        {
            // Butonun varsayılan arka plan rengini saydam yap
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat; // Düz görünüm
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Butonun varsayılan arka planını çizmeyi devre dışı bırakıyoruz
            base.OnPaint(e);

            // Kenar çizgilerini çiz
            using (Pen borderPen = new Pen(Color.Black, 1)) // Siyah kenarlık
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            }

            // Buton metnini çiz
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

       
    }
}
