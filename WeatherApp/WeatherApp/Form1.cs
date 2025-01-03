using System.Globalization;
using System.Resources;
using System.Xml.Linq;
using WeatherApp.Properties;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        
        public Form1() //construct
        {
            InitializeComponent();
        }


        // City name vs di�er de�i�kenlere fonksiyonun d���nda tan�mla ama fonksiyonun i�inde de�i�tir bunu dene
        public void Form1_Load(object sender, EventArgs e)
        {
            string[] Citys = {"Adana", "Ad�yaman", "Afyonkarahisar", "A�r�", "Aksaray", "Amasya",
            "Ankara", "Antalya", "Ardahan", "Artvin", "Ayd�n", "Bal�kesir",
            "Bart�n", "Batman", "Bayburt", "Bilecik", "Bing�l", "Bitlis", "Bolu",
            "Burdur", "Bursa", "�anakkale", "�ank�r�", "�orum", "Denizli", "Diyarbak�r",
            "D�zce", "Edirne", "Elaz��", "Erzincan", "Erzurum", "Eski�ehir", "Gaziantep",
            "Giresun", "G�m��hane", "Hakkari", "Hatay", "I�d�r", "Isparta", "�stanbul",
            "�zmir", "Kahramanmara�", "Karab�k", "Karaman", "Kastamonu", "Kayseri", "Kilis",
            "Kocaeli", "Konya", "K�tahya", "Malatya", "Manisa", "Mardin", "Mersin",
            "Mu�la", "Mu�", "Nev�ehir", "Ni�de", "Ordu", "Osmaniye", "Rize", "Sakarya",
            "Samsun", "Siirt", "Sinop", "Sivas", "�anl�urfa", "��rnak", "Tekirda�", "Tokat",
            "Trabzon", "Tunceli", "U�ak", "Van", "Yalova", "Yozgat", "Zonguldak" , "Yakutsk" ,
                "Moskova","Londra","Paris","Bak�","Astana","Tokyo","Washington","Berlin","Oslo","Ottawa","NewYork"
                ,"Helsinki","Stockholm","Amsterdam","Roma","Kiev"}; // kullan�c�ya yazd�rmak riskli o y�zden 81 ili combobox i�inde yazan array
            CityCombo.DataSource = Citys; // comboboxun verileri hangi arrayden �ekece�ini s�yl�yor
            CityCombo.SelectedItem = "Ankara"; // default se�ili gelecek �ehir
            veri_cek(); // form y�klendi�inde t�m verileri al�p ilk pencereyi a�mas� i�in

        }

        //combobox de�eri de�i�ti�inde veri �ek fonksiyonunu �a��r�yo
        // veri �ek fonksiyonu da t�m verileri falan g�ncelliyo
        public void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            veri_cek();
        }



        //a�a��daki iki fonksiyonu ai dan ald�m border olmad���nda pencereyi hareket ettirmemizi
        //sa�l�yor farenin konumunu falan al�yo
        private Point _draggingPoint; // pencere hareketi i�in de�i�ken
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _draggingPoint = e.Location;
            }
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            // E�er fare t�klama ger�ekle�mi�se, formu ta��yoruz
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Left + e.X - _draggingPoint.X,
                    this.Top + e.Y - _draggingPoint.Y);
            }
        }

        //close tu�u yapmak i�in
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // uygulaman�n ana fonskiyonu sayabiliriz t�m i�ler burada yap�l�yor
        public void veri_cek()
        {
            DateTime NowDate = DateTime.Today; // pc den tarih bilgisini al�yor

            //�ehir ad�n� comboxdan al�yoruz
            string cityName = CityCombo.SelectedItem.ToString();

            //api sa�lay�c�sn�n verdi�i key
            string apiKey = "523bac46a718c50e5596db9d73ba7cc2";

            //burda da verilerin al�naca�� linki giriyoruz istedi�imiz �ehrin verisini vermesi i�in
            //cityName de�i�kenini linkin i�ine yaz�yoruz sonuna ise api �al��mas� i�in key yaz�yoruz
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&mode=xml&lang=tr&units=metric&appid=" + apiKey;

            //verilerin al�naca�� xml dosyas�na ba�lan�yor san�r�m burada biraz kopya �ektim
            XDocument Air�nfo = XDocument.Load(connection);

            //ihtiyac�m�z olan verileri �eker
            var Temparature = Air�nfo.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var WeatherStatus = Air�nfo.Descendants("weather").ElementAt(0).Attribute("value").Value;
            var Status�con = Air�nfo.Descendants("weather").ElementAt(0).Attribute("icon").Value;

            //pc den al�nan tarihi yazd�r�r
            DateLabel.Text = NowDate.ToString("yyyy/MM/dd");

            //�ehir ismini ayarlar
            CityNameLabel.Text = cityName;

            // s�cakl�k label�na s�cakl��� yazd�r�r ve sonuna derece sembollerini ekler
            string TemparatureSTR = Temparature.ToString();
            double TemparatureFlt = Double.Parse(TemparatureSTR, System.Globalization.CultureInfo.InvariantCulture);
            int roundedTemparature = (int)Math.Round(TemparatureFlt);
            TemparatureLabel.Text = roundedTemparature.ToString() + "\u00B0" + "C";

            //hava durumu yazs�n� String bir de�i�kende tutar
            string WeatherStatusSTR = WeatherStatus.ToString();

            TextInfo textInfo = new CultureInfo("tr-TR", false).TextInfo; // TR yaz� tipine uyum i�in

            //hava durumu yaz�s�n� ayarlar ilk harflerini b�y�k yapar
            WeatherStatusLabel.Text =textInfo.ToTitleCase(WeatherStatusSTR.ToLower());

            // uygulamadan gelen gece g�nd�z verisini al�r bu veri icon verisi ile bilrikte geliyor
            //o y�zden son harfi al�r sonra d ise g�nd�z foto�raf�n� n ise gece foto�raf�n� koyar
            string DayOrNight = Status�con.Substring(2);
            if (DayOrNight == "d")
            {
                DNPictureBox.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Day.png");
            }
            else if (DayOrNight == "n")
            {
                DNPictureBox.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Night.png");
            }

            // alttaki ko�ulu test etmek i�in gelen verinin ilk iki harifni al�r
            string iconFirstTwo = Status�con.Substring(0, 2);

            //ikonlar� d�zenleyen if else bloklar�
            // gelen verileri grupland�r�p veriye g�re foto�raf koyar
            string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources");

            if (iconFirstTwo == "01")
            {
                StatusPictureBox.ImageLocation = Path.Combine(resourcesPath, "SunnyDog.png");
            }
            else if (iconFirstTwo == "02" || iconFirstTwo == "03" || iconFirstTwo == "04")
            {
                StatusPictureBox.ImageLocation = Path.Combine(resourcesPath, "CloudyDog.png");
            }
            else if (iconFirstTwo == "09" || iconFirstTwo == "10")
            {
                StatusPictureBox.ImageLocation = Path.Combine(resourcesPath, "RainyDog.png");
            }
            else if (iconFirstTwo == "11")
            {
                StatusPictureBox.ImageLocation = Path.Combine(resourcesPath, "ThunderDog.png");
            }
            else if (iconFirstTwo == "13")
            {
                StatusPictureBox.ImageLocation = Path.Combine(resourcesPath, "SnowyDog.png");
            }
            else if (iconFirstTwo == "50")
            {
                StatusPictureBox.ImageLocation = Path.Combine(resourcesPath, "FoggyDog.png");
            }

        }
    }
}
