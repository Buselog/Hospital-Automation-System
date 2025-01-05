using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneSistemOtomasyonu
{
    public class GradientPanel : Panel
    {
        public Color colorLeft { get; set; }
        public Color colorRight { get; set; }

        public GradientPanel()
        {
            // Panelin arka planını tamamen saydam yap
            //Panelin arka planının saydamlığı desteklemesini sağlar.
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Arka planın varsayılan çizimini devre dışı bırakıyoruz
            // Böylece kendi özel gradyan arka planımızı çizebiliriz.
            //Devre dışı bırakılıyor, çünkü varsayılan olarak bir arka plan rengi veya görüntüsü çizerdi.
            //Biz kendi özel gradyan çizimimizi yapmak için bunu sıfırlıyoruz.
        }


        //OnPaint() -> Panel kontrolü kendi içeriğini (çizim, metin, vb.) çizmek istediğinde çağrılır.
        //Biz, bu metodu override ederek panelin nasıl çizileceğini özelleştiriyoruz.
        protected override void OnPaint(PaintEventArgs e)
        {
            // Gradyan arka plan çizimi
            using (LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, this.colorLeft, this.colorRight, LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(lgb, this.ClientRectangle);
            }

            // Eğer üstüne başka bir şey çizmek istiyorsanız, burada ekleyebilirsiniz
            // Örneğin, panel üzerine metin eklemek gibi.

            base.OnPaint(e); // Varsayılan OnPaint metodunu çağırıyoruz
                             //Bu, kontrol üzerindeki diğer çizimlerin(örneğin çocuk kontrollerin) düzgün çalışmasını sağlar.
        }
    }
}
