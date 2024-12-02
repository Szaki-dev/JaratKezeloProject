namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        private class Jarat
        {
            public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
            {
                this.JaratSzam = jaratSzam;
                this.RepterHonnan = repterHonnan;
                this.RepterHova = repterHova;
                this.Indulas = indulas;
                this.Keses = 0;
            }
            public string JaratSzam { get; set; }
            public string RepterHonnan { get; set; }
            public string RepterHova { get; set; }
            public DateTime Indulas { get; set; }
            public int Keses { get; set; }

        }

        private List<Jarat> jaratok = new List<Jarat>();

        private Jarat jaratKeres(string jaratszam)
        {
            int i = 0;
            while (i < jaratok.Count && jaratok[i].JaratSzam != jaratszam) i++;
            if (i == jaratok.Count) throw new ArgumentException("Nincs ilyen járat!");
            return jaratok[i];
        }

        public void ujJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratSzam == null || jaratSzam == "") throw new ArgumentException(nameof(jaratSzam));
            if (repterHonnan == null || repterHonnan == "") throw new ArgumentException(nameof(repterHonnan));
            if (repterHova == null || repterHova == "") throw new ArgumentException(nameof(repterHova));
            if (indulas < DateTime.Now) throw new ArgumentException(nameof(indulas));
            jaratok.Add(new Jarat(jaratSzam, repterHonnan, repterHova, indulas));
        }
        public void keses(string jaratSzam, int keses)
        {
            if (jaratSzam == null || jaratSzam == "") throw new ArgumentException(nameof(jaratSzam));
            Jarat jarat = jaratKeres(jaratSzam);
            jarat.Keses += keses;
            if (jarat.Keses < 0) throw new NegativKesesException();
        }

        public DateTime mikorIndul(string jaratSzam)
        {
            if (jaratSzam == null || jaratSzam == "") throw new ArgumentException(nameof(jaratSzam));
            Jarat jarat = jaratKeres(jaratSzam);
            return jarat.Indulas.AddMinutes(jarat.Keses);
        }

        public List<string> jaratokRepuloterrol(string repter)
        {   
            if (repter == null || repter == "") throw new ArgumentException(nameof(repter));
            List<string> jaratokSzama = new List<string>();
            foreach (var jarat in jaratok) if (jarat.RepterHonnan == repter) jaratokSzama.Add(jarat.JaratSzam);
            return jaratokSzama;
        }
    }
}
