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


        // City name vs diðer deðiþkenlere fonksiyonun dýþýnda tanýmla ama fonksiyonun içinde deðiþtir bunu dene
        public void Form1_Load(object sender, EventArgs e)
        {
            string[] Citys = {"Adana", "Adýyaman", "Afyonkarahisar", "Aðrý", "Aksaray", "Amasya",
            "Ankara", "Antalya", "Ardahan", "Artvin", "Aydýn", "Balýkesir",
            "Bartýn", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu",
            "Burdur", "Bursa", "Çanakkale", "Çankýrý", "Çorum", "Denizli", "Diyarbakýr",
            "Düzce", "Edirne", "Elazýð", "Erzincan", "Erzurum", "Eskiþehir", "Gaziantep",
            "Giresun", "Gümüþhane", "Hakkari", "Hatay", "Iðdýr", "Isparta", "Ýstanbul",
            "Ýzmir", "Kahramanmaraþ", "Karabük", "Karaman", "Kastamonu", "Kayseri", "Kilis",
            "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin",
            "Muðla", "Muþ", "Nevþehir", "Niðde", "Ordu", "Osmaniye", "Rize", "Sakarya",
            "Samsun", "Siirt", "Sinop", "Sivas", "Þanlýurfa", "Þýrnak", "Tekirdað", "Tokat",
            "Trabzon", "Tunceli", "Uþak", "Van", "Yalova", "Yozgat", "Zonguldak" , "Yakutsk" ,
                "Moskova","Londra","Paris","Bakü","Astana","Tokyo","Washington","Berlin","Oslo","Ottawa","NewYork"
                ,"Helsinki","Stockholm","Amsterdam","Roma","Kiev"}; // kullanýcýya yazdýrmak riskli o yüzden 81 ili combobox içinde yazan array
            CityCombo.DataSource = Citys; // comboboxun verileri hangi arrayden çekeceðini söylüyor
            CityCombo.SelectedItem = "Ankara"; // default seçili gelecek þehir
            veri_cek(); // form yüklendiðinde tüm verileri alýp ilk pencereyi açmasý için

        }

        //combobox deðeri deðiþtiðinde veri çek fonksiyonunu çaðýrýyo
        // veri çek fonksiyonu da tüm verileri falan güncelliyo
        public void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            veri_cek();
        }



        //aþaðýdaki iki fonksiyonu ai dan aldým border olmadýðýnda pencereyi hareket ettirmemizi
        //saðlýyor farenin konumunu falan alýyo
        private Point _draggingPoint; // pencere hareketi için deðiþken
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _draggingPoint = e.Location;
            }
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            // Eðer fare týklama gerçekleþmiþse, formu taþýyoruz
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Left + e.X - _draggingPoint.X,
                    this.Top + e.Y - _draggingPoint.Y);
            }
        }

        //close tuþu yapmak için
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // uygulamanýn ana fonskiyonu sayabiliriz tüm iþler burada yapýlýyor
        public void veri_cek()
        {
            DateTime NowDate = DateTime.Today; // pc den tarih bilgisini alýyor

            //þehir adýný comboxdan alýyoruz
            string cityName = CityCombo.SelectedItem.ToString();

            //api saðlayýcýsnýn verdiði key
            string apiKey = "523bac46a718c50e5596db9d73ba7cc2";

            //burda da verilerin alýnacaðý linki giriyoruz istediðimiz þehrin verisini vermesi için
            //cityName deðiþkenini linkin içine yazýyoruz sonuna ise api çalýþmasý için key yazýyoruz
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&mode=xml&lang=tr&units=metric&appid=" + apiKey;

            //verilerin alýnacaðý xml dosyasýna baðlanýyor sanýrým burada biraz kopya çektim
            XDocument AirÝnfo = XDocument.Load(connection);

            //ihtiyacýmýz olan verileri çeker
            var Temparature = AirÝnfo.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var WeatherStatus = AirÝnfo.Descendants("weather").ElementAt(0).Attribute("value").Value;
            var StatusÝcon = AirÝnfo.Descendants("weather").ElementAt(0).Attribute("icon").Value;

            //pc den alýnan tarihi yazdýrýr
            DateLabel.Text = NowDate.ToString("yyyy/MM/dd");

            //Þehir ismini ayarlar
            CityNameLabel.Text = cityName;

            // sýcaklýk labelýna sýcaklýðý yazdýrýr ve sonuna derece sembollerini ekler
            string TemparatureSTR = Temparature.ToString();
            double TemparatureFlt = Double.Parse(TemparatureSTR, System.Globalization.CultureInfo.InvariantCulture);
            int roundedTemparature = (int)Math.Round(TemparatureFlt);
            TemparatureLabel.Text = roundedTemparature.ToString() + "\u00B0" + "C";

            //hava durumu yazsýný String bir deðiþkende tutar
            string WeatherStatusSTR = WeatherStatus.ToString();

            TextInfo textInfo = new CultureInfo("tr-TR", false).TextInfo; // TR yazý tipine uyum için

            //hava durumu yazýsýný ayarlar ilk harflerini büyük yapar
            WeatherStatusLabel.Text =textInfo.ToTitleCase(WeatherStatusSTR.ToLower());

            // uygulamadan gelen gece gündüz verisini alýr bu veri icon verisi ile bilrikte geliyor
            //o yüzden son harfi alýr sonra d ise gündüz fotoðrafýný n ise gece fotoðrafýný koyar
            string DayOrNight = StatusÝcon.Substring(2);
            if (DayOrNight == "d")
            {
                DNPictureBox.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Day.png");
            }
            else if (DayOrNight == "n")
            {
                DNPictureBox.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "Night.png");
            }

            // alttaki koþulu test etmek için gelen verinin ilk iki harifni alýr
            string iconFirstTwo = StatusÝcon.Substring(0, 2);

            //ikonlarý düzenleyen if else bloklarý
            // gelen verileri gruplandýrýp veriye göre fotoðraf koyar
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
