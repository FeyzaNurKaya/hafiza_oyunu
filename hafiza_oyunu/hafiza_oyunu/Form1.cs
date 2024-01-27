using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace hafiza_oyunu
{
    public partial class Form1 : Form
    {

        List<string> resimler = new List<string>(){
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\ananas.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\cilek.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\elma.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\incir.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\karpuz.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\kiraz.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\muz.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\nar.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\portakal.jpg",
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\þeftali.jpg",


        };

        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19 };  // resimleri indeks numaralarýna göre 2 tane var dedik

        PictureBox ilkkutu;
        int ilkIndeks, bulunan;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resimleriKaristir();
        }

        private void resimleriKaristir()
        {
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                int sayi = rnd.Next(20);   // 0dan 20ye olan elemanlardan rastgele sayý seç
                int gecici = indeksler[i];
                indeksler[i] = indeksler[sayi];
                indeksler[sayi] = gecici;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox kutu = (PictureBox)sender;
            int kutuNo = int.Parse(kutu.Name.Substring(10)) - 1; 
            int indeksNo = indeksler[kutuNo];
            kutu.Image = Image.FromFile(resimler[indeksNo]);
            kutu.Refresh();   // kutu üzerindeki elemanlarý çizdirdi.

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                ilkkutu.Image = null;
                kutu.Image = null;  // null deðerleri vererek açýlan resimler eþlenmezse kapatmasýný saðladým.

                if (ilkIndeks == indeksNo)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;

                    if (bulunan == 11)
                    {
                        MessageBox.Show("Tebrikler oyunu kazandýnýz.");
                        bulunan = 0; // oyun bittikten sonra sýfýrladým.
                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimleriKaristir();   // en sonda da diðer oyunu baþlattým.
                    }

                }
                ilkkutu = null;   // bu kýsmýn tamamý resimler eþleþtiðinde resimlerin gitmesini saðladý.
            }

        }
    }
}


