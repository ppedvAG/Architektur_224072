using System.Runtime.InteropServices;

namespace HalloBuilder
{
    internal class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public Schrankoberfläche Oberfläche { get; private set; }
        public string Farbe { get; private set; } = string.Empty;
        public bool Metallschienen { get; private set; }
        public bool Kleiderstange { get; private set; }

        public class Builder
        {
            private readonly Schrank _schrank = new Schrank();
            public Schrank Create()
            {
                return _schrank;
            }

            public Builder SetTüren(int anzTüren)
            {
                if (anzTüren < 2 || anzTüren > 7)
                    throw new ArgumentException("Zuviele oder zu wenige Türen, es sind nur 2-7 Türen erlaubt.");

                _schrank.AnzahlTüren = anzTüren;

                return this;
            }

            public Builder SetBöden(int anzBöden)
            {
                if (anzBöden < 2 || anzBöden > 6)
                    throw new ArgumentException("Zuviele oder zu wenige Böden, es sind nur 2-6 Türen erlaubt.");

                _schrank.AnzahlBöden = anzBöden;

                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if (_schrank.Oberfläche != Schrankoberfläche.Lackiert)
                    _schrank.Oberfläche = Schrankoberfläche.Lackiert;
                //throw new ArgumentException("Nur lackierte Schränke können eine Farbe bekommen");

                _schrank.Farbe = farbe;
                return this;
            }

            public Builder SetOberfläche(Schrankoberfläche schrankoberfläche)
            {
                //falls nicht mehr Lackiert auchgewählt wurde, muss die Farbe entfernt werden
                if (_schrank.Oberfläche == Schrankoberfläche.Lackiert && schrankoberfläche != Schrankoberfläche.Lackiert)
                    _schrank.Farbe = string.Empty;

                _schrank.Oberfläche = schrankoberfläche;
                return this;
            }
        }

    }

    public enum Schrankoberfläche
    {
        Unbehandelt,
        Gewachst,
        Lackiert
    }
}
