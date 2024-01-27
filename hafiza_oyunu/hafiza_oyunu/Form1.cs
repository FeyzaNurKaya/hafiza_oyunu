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
            "C:\\Users\\kayaa\\source\\repos\\hafiza_oyunu\\hafiza_oyunu\\Resources\\�eftali.jpg",


        };

        int[] indeksler = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19 };  // resimleri indeks numaralar�na g�re 2 tane var dedik

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
                int sayi = rnd.Next(20);   // 0dan 20ye olan elemanlardan rastgele say� se�
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
            kutu.Refresh();   // kutu �zerindeki elemanlar� �izdirdi.

            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkIndeks = indeksNo;
            }
            else
            {
                System.Threading.Thread.Sleep(1000);

                ilkkutu.Image = null;
                kutu.Image = null;  // null de�erleri vererek a��lan resimler e�lenmezse kapatmas�n� sa�lad�m.

                if (ilkIndeks == indeksNo)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;

                    if (bulunan == 11)
                    {
                        MessageBox.Show("Tebrikler oyunu kazand�n�z.");
                        bulunan = 0; // oyun bittikten sonra s�f�rlad�m.
                        foreach (Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimleriKaristir();   // en sonda da di�er oyunu ba�latt�m.
                    }

                }
                ilkkutu = null;   // bu k�sm�n tamam� resimler e�le�ti�inde resimlerin gitmesini sa�lad�.
            }

        }
    }
}


