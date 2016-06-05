using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino_Projekat
{
    public enum Zanr { komedija, akcija, romansa, triler, horor, djeciji, scifi, drama };

    public class Filmovi
    {
        public string naziv;
        public string redatelj;
        public string uloge;
        public List<Zanr> zanr;
        public int trajanjeFilma;
        public DateTime datOdrzavanja = new DateTime();
        public int brKarata;
        public int brPreostalihKarata;
        public string sinopsis;
        public int IMDb;
        public int cijena;

        public Filmovi(string _naziv, string _redatelj, string _uloge, List<Zanr> _zanr, string _trajanjeFilma, 
            string _sinopsis, string _IMDb, DateTime _datOdrzavanja, string _brKarata, string _cijena)
        {
            try
            {
                naziv = _naziv;
                redatelj = _redatelj;
                uloge = _uloge;
                zanr = _zanr;
                sinopsis = _sinopsis;
                IMDb = int.Parse(_IMDb);
                if (!int.TryParse(_trajanjeFilma, out trajanjeFilma)) throw new Exception("Polje 'Trajanje' ne smije sadržavati slova!");                
                if (trajanjeFilma < 0) throw new Exception("Trajanje filma  ne može biti negativan broj!");
                if (!int.TryParse(_brKarata, out brKarata)) throw new Exception("Neispravan unos broja karata!");
                if (!int.TryParse(_cijena, out cijena)) throw new Exception("Neispravan unos cijene!");
                brPreostalihKarata = brKarata; // na početku
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Filmovi() { }
    }
}
