using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino_Projekat
{
    public class Kupci
    {
        public Sale sala;
        public Paketi paket;
        public Filmovi film;
        public bool hrana;
        public bool pice;
        public bool VIPclan;
        public bool parking;
        public double cijenaKarte = 0;

        const double cijenaHrane = 2;
        const double cijenaPica = 1;
        const double cijenaParkinga = 1;
        const double popustVIP = 0.1; //10% popusta
        const double popustFamily = 1;
        const double popustLadies = 1;
        const double popustSchool = 2;
        const double cijenaOther = 7;

        public Kupci(Sale _sala, Paketi _paket, Filmovi _film, bool _hrana, bool _pice, bool _VIPclan, bool _parking)
        {
            sala = _sala;
            paket = _paket;
            film = _film;
            hrana = _hrana;
            pice = _pice;
            VIPclan = _VIPclan;
            parking = _parking;
            cijenaKarte = IzracunajCijenuKarte(_film, _paket.ToString(), _hrana, _pice, _VIPclan, _parking);
            foreach (var f in Glavna.listaFilmova)
            {
                if (f == film) f.brPreostalihKarata--; break;
            }
        }

        public static double IzracunajCijenuKarte(Filmovi _film, string _paket, bool _hrana, bool _pice, bool _VIPclan, bool _parking)
        {
            double Cijena = _film.cijena;
            if (_paket== "Family") Cijena -= popustFamily;
            else if (_paket == "Ladies night") Cijena -= popustLadies;
            else if (_paket == "School") Cijena -= popustSchool;
            else if (_paket == "Other") Cijena = cijenaOther;
            if (_hrana) Cijena += cijenaHrane;
            if (_pice) Cijena += cijenaPica;
            if (_parking) Cijena += cijenaParkinga;
            if (_VIPclan) Cijena -= Cijena * popustVIP;
            if (_film.datOdrzavanja.Hour > 17) Cijena += 1;
            return Cijena;
        }

    }
}
