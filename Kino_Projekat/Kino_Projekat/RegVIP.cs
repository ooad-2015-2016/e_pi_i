using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino_Projekat
{
    public class RegVIP
    {
        public string imePrez;
        public string brLicneKarte;
        public int brClanskeKarte;
        public int telefon;
        public string mail;
        public bool obavijesti;
        public DateTime datumRodj = new DateTime();

        public RegVIP(string _imePrez, string _brLicneKarte, string _brClanskeKarte, string _telefon, string _mail, bool _obavijesti, DateTime _datumRodj)
        {
            try
            {
                if (_brLicneKarte.Length != 9) throw new Exception("Broj lične karte mora imati 9 znakova!");
                if (!int.TryParse(_brClanskeKarte, out brClanskeKarte)) throw new Exception("Polje 'Članski kod' ne smije sadržavati slova!");
                if (_brClanskeKarte.Length != 5) throw new Exception("Članski kod mora imati tačno 5 brojeva!");
                if (!int.TryParse(_telefon, out telefon)) throw new Exception("Polje 'telefon' ne smije sadržavati slova!");
                if (_telefon.Length != 9 && _telefon.Length != 10) throw new Exception("Polje 'Telefon' mora sadržavati ukupno 9 ili 10 brojeva!");
                if (!_mail.Contains("@live.com") && !_mail.Contains("@hotmail.com") && !_mail.Contains("@etf.unsa.ba")
                    && !_mail.Contains("@yahoo.com") && !_mail.Contains("@gmail.com")) throw new Exception("Neispravan oblik e-maila! E-mail mora imati jedan od sljedećih oblika: "+
                        "nesto@etf.unsa.ba, nesto@hotmail.com, nesto@live.com, nesto@yahoo.com, nesto@gmail.com.");
                if (_datumRodj > new DateTime(DateTime.Today.Year - 18, DateTime.Today.Month, DateTime.Today.Day)) throw new Exception("Osoba ne može biti mlađa od 18 godina!");

                imePrez = _imePrez;
                brLicneKarte = _brLicneKarte;
                mail = _mail;
                obavijesti = _obavijesti;
                datumRodj = _datumRodj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RegVIP() { }
    }
}
