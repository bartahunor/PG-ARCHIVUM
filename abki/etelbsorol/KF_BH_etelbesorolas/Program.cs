using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace KF_BH_etelbesorolas
{
    class Etel
    {
        public int cegid;
        public string nutriscore;
        public string nev;

        public Etel(int cegid, string nutriscore, string nev)
        {
            this.cegid = cegid;
            this.nutriscore = nutriscore;
            this.nev = nev;
        }
    }

    class Forgalmazo
    {
        public string nev;
        public string szekhely;
        public int alapitas;

        public Forgalmazo(string nev, string szekhely, int alapitas)
        {
            this.nev = nev;
            this.szekhely = szekhely;
            this.alapitas = alapitas;
        }
    }

    class Tapertek
    {
        public string besorolas;
        public int energia;
        public double tzsir;
        public double cukor;
        public double rost;
        public double feherje;
        public double so;

        public Tapertek(string besorolas, int energia, double tzsir, double cukor, double rost, double feherje, double so)
        {
            this.besorolas = besorolas;
            this.energia = energia;
            this.tzsir = tzsir;
            this.cukor = cukor;
            this.rost = rost;
            this.feherje = feherje;
            this.so = so;
        }
    }
    internal class Program
    {
        static void AddEtel(MySqlConnection c, Etel e)
        {
            string insertString = "INSERT INTO etel(cegid, nutriscore, nev) VALUES(@cegid, @nutriscore, @nev)";
            MySqlCommand utasitas = new MySqlCommand(insertString, c);
            utasitas.Parameters.AddWithValue("@cegid", e.cegid);
            utasitas.Parameters.AddWithValue("@nutriscore", e.nutriscore);
            utasitas.Parameters.AddWithValue("@nev", e.nev);
            int sorok = utasitas.ExecuteNonQuery();
        }

        static void AddForgalmazo(MySqlConnection c, Forgalmazo f)
        {
            string insertString = "INSERT INTO forgalmazo(nev, szekhely, alapitas) VALUES(@nev, @szekhely, @alapitas)";
            MySqlCommand utasitas = new MySqlCommand(insertString, c);
            utasitas.Parameters.AddWithValue("@nev", f.nev);
            utasitas.Parameters.AddWithValue("@szekhely", f.szekhely);
            utasitas.Parameters.AddWithValue("@alapitas", f.alapitas);
            int sorok = utasitas.ExecuteNonQuery();
        }

        static void AddTapertek(MySqlConnection c, Tapertek t)
        {
            string insertString = "INSERT INTO tapertek(besorolas, energia, tzsir, cukor, rost, feherje, so) VALUES(@besorolas, @energia, @tzsir, @cukor, @rost, @feherje, @so)";
            MySqlCommand utasitas = new MySqlCommand(insertString, c);
            utasitas.Parameters.AddWithValue("@besorolas", t.besorolas);
            utasitas.Parameters.AddWithValue("@energia", t.energia);
            utasitas.Parameters.AddWithValue("@tzsir", t.tzsir);
            utasitas.Parameters.AddWithValue("@cukor", t.cukor);
            utasitas.Parameters.AddWithValue("@rost", t.rost);
            utasitas.Parameters.AddWithValue("@feherje", t.feherje);
            utasitas.Parameters.AddWithValue("@so", t.so);
            int sorok = utasitas.ExecuteNonQuery();
        }

        static List<Forgalmazo> GetForgalmazo(MySqlConnection c)
        {
            List<Forgalmazo> forgalmak = new List<Forgalmazo>();
            string getString = "SELECT nev, szekhely, alapitas FROM forgalmazo WHERE alapitas > 1900";
            MySqlCommand utasitas = new MySqlCommand(getString, c);
            MySqlDataReader olvaso = utasitas.ExecuteReader();
            while (olvaso.Read())
            {
                string nev = olvaso.GetString("nev");
                string szekhely = olvaso.GetString("szekhely");
                int alapitas = olvaso.GetInt32("alapitas");
                Forgalmazo f = new Forgalmazo(nev, szekhely, alapitas);
                forgalmak.Add(f);
            }
            return forgalmak;
        }

        static void Main(string[] args)
        {
            string connStr = "server=localhost;user=root;password=;database=etel_besorolas_2";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                Console.WriteLine("***** Sikeres kapcsolat! *****");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\tADATBÁZIS ÉTELEK BESOROLÁSÁHOZ 100g TÖMEG ALAPJÁN");
                Console.WriteLine();

                #region tapertek tabla töltése
                List<Tapertek> tapertekek = new List<Tapertek>
                {

                    new Tapertek("A", 80, 1.0, 5.0, 4.0, 5.0, 0.3),
                    new Tapertek("B", 150, 2.5, 10.0, 3.0, 4.0, 2.5),
                    new Tapertek("C", 250, 4.0, 15.0, 2.0, 3.0, 4.0),
                    new Tapertek("D", 350, 6.0, 20.0, 1.0, 2.0, 6.0),
                    new Tapertek("E", 500, 10.0, 30.0, 0.0, 0.0, 7.0)
                };

                for (int i = 0; i < tapertekek.Count; i++)
                {
                    AddTapertek(conn, tapertekek[i]);
                }

                List<Forgalmazo> forgalmazok = new List<Forgalmazo>
                {
                    new Forgalmazo("CBA", "Alsónémedi", 1992),
                    new Forgalmazo("Mizo", "Szeged", 1993),
                    new Forgalmazo("Nestlé", "Vevey, Svájc", 1866),
                    new Forgalmazo("Unilever", "London, Egyesült Királyság", 1929),
                    new Forgalmazo("PepsiCo", "Purchase, New York, USA", 1965),
                    new Forgalmazo("Kraft Heinz", "Chicago, Illinois, USA", 2015),
                    new Forgalmazo("General Mills", "Minneapolis, Minnesota, USA", 1928),
                    new Forgalmazo("Danone", "Paris, Franciaország", 1919),
                    new Forgalmazo("Mondelez International", "Chicago, USA", 2012),
                    new Forgalmazo("Tyson Foods", "Springdale, Arkansas, USA", 1935),
                    new Forgalmazo("Cargill", "Minnetonka, Minnesota, USA", 1865),
                    new Forgalmazo("Archer Daniels Midland", "Chicago, Illinois, USA", 1902),
                    new Forgalmazo("Mars Inc.", "McLean, Virginia, USA", 1911),
                    new Forgalmazo("Hormel Foods", "Austin, Minnesota, USA", 1891),
                    new Forgalmazo("Conagra Brands", "Chicago, Illinois, USA", 1919),
                    new Forgalmazo("Ferrero", "Alba, Olaszország", 1946),
                    new Forgalmazo("Kellogg's", "Battle Creek, Michigan, USA", 1906),
                    new Forgalmazo("JBS S.A.", "São Paulo, Brazília", 1953),
                    new Forgalmazo("Smithfield Foods", "Smithfield, Virginia, USA", 1936),
                    new Forgalmazo("Bimbo Bakeries", "Mexico City, Mexikó", 1945),
                    new Forgalmazo("Yum! Brands", "Louisville, Kentucky, USA", 1997),
                    new Forgalmazo("McCain Foods", "Florenceville, Kanada", 1957),
                    new Forgalmazo("Maple Leaf Foods", "Mississauga, Ontario, Kanada", 1927),
                    new Forgalmazo("Ajinomoto", "Tokyo, Japán", 1909),
                    new Forgalmazo("Barilla", "Parma, Olaszország", 1877),
                    new Forgalmazo("Tata Consumer Products", "Mumbai, India", 1964),
                    new Forgalmazo("Associated British Foods", "London, UK", 1935),
                    new Forgalmazo("Grupo Bimbo", "Mexico City, Mexikó", 1945),
                    new Forgalmazo("FrieslandCampina", "Amersfoort, Hollandia", 1871),
                    new Forgalmazo("Saputo Inc.", "Montreal, Kanada", 1954),
                    new Forgalmazo("Dean Foods", "Dallas, Texas, USA", 1925),
                    new Forgalmazo("Nestlé Purina", "St. Louis, Missouri, USA", 1894)
                };

                for (int i = 0; i < forgalmazok.Count; i++)
                {
                    AddForgalmazo(conn, forgalmazok[i]);
                }
                #endregion

                #region adat bevitel maualisan

                while (true)
                {
                    Console.WriteLine("FORGALMAZÓ HOZZÁADÁSA             -   1");
                    Console.WriteLine("ÉTEL HOZZÁADÁSA                   -   2");
                    Console.WriteLine("1900 után alapult forgalmazók     -   3");
                    Console.WriteLine("KILÉPÉS                           -   0");
                    Console.Write("\tVálasztás: ");
                    int valasztas = Convert.ToInt32(Console.ReadLine());
                    if (valasztas == 0) break;
                    Console.WriteLine();
                    switch (valasztas)
                    {
                        case 1:
                            Console.WriteLine("-- ÚJ FORGALMAZÓ HOZZÁADÁSA --");
                            Console.Write("\tForgalmazó neve: ");
                            string nev = Console.ReadLine();
                            Console.Write("\tSzekhelye: ");
                            string szekhely = Console.ReadLine();
                            Console.Write("\tAlapítás éve: ");
                            int alapitas = Convert.ToInt32(Console.ReadLine());
                            Forgalmazo ujforg = new Forgalmazo(nev, szekhely, alapitas);
                            AddForgalmazo(conn, ujforg);
                            break;

                        case 2:
                            Console.WriteLine("-- ÚJ ÉTEL HOZZÁADÁSA --");
                            Console.Write("Cég id: ");
                            int cegid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Nutriscore: ");
                            string nutriscore = Console.ReadLine();
                            Console.Write("Étel neve: ");
                            string etelNev = Console.ReadLine();
                            Etel ujetel = new Etel(cegid, nutriscore, etelNev);
                            AddEtel(conn, ujetel);
                            break;
                        case 3:
                            List<Forgalmazo> forgalmak = GetForgalmazo(conn);
                            foreach (var f in forgalmak)
                            {
                                Console.WriteLine($"Név: {f.nev}");
                            }
                            Console.WriteLine();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Hibás választás!");
                            break;
                    }
                }
                #endregion


                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}