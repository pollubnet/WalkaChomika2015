#region License

/*
 * Written in 2015 by Marcin Badurowicz <m dot badurowicz at pollub dot pl>
 *
 * To the extent possible under law, the author(s) have dedicated
 * all copyright and related and neighboring rights to this
 * software to the public domain worldwide. This software is
 * distributed without any warranty.
 *
 * You should have received a copy of the CC0 Public Domain
 * Dedication along with this software. If not, see
 * <http://creativecommons.org/publicdomain/zero/1.0/>.
 */

#endregion License

using System;

namespace WalkaChomika
{
    /// <summary>
    /// Klasa Zwierzę, reprezentująca zwierzę bojowe
    /// </summary>
    internal abstract class Zwierzę
    {
        public Zwierzę()
        {
            this.HP = 1;
            this.Mana = 0;
            this.Damage = 2;
            this.Agility = 0;

            Licznik = Licznik + 1;
        }

        public static int Licznik = 0;

        /// <summary>
        /// To jest tzw. właściwość. Powinno używać się właściwości zamiast pól, ale dlaczego, to już
        /// kwestia nieco bardziej zaawansowana, więc chwilowo ją pominiemy. To konkretne pole reprezentuje
        /// imię zwierzęcia.
        /// </summary>
        public string Imię { get; set; }

        /// <summary>
        /// To pole jest liczbą, która reprezentuje ile zwierzę ma punktów życia
        /// </summary>
        public int HP;

        /// <summary>
        /// To pole reprezentuje ilość many zwierzęcia
        /// </summary>
        public int Mana;

        /// <summary>
        /// To pole reprezentuje maksymalne obrażenia zadawane przez atak
        /// </summary>
        public int Damage;

        /// <summary>
        /// Nowa cecha dla zwierzęcia - zwinność, która pozwala unikać
        /// mu zagrożeń
        /// </summary>
        public int Agility { get; set; }

        /// <summary>
        /// Ta funkcja zwraca, czy zwierze jeszcze żyje, opierając się na danych z tego samego obiektu.
        /// Funkcje w klasach nazywa się metodami.
        /// </summary>
        /// <returns>Zwraca, czy zwierzę jeszcze żyje</returns>
        public bool CzyŻyje()
        {
            if (HP > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ta funkcja atakuje inne zwierzę - podawane jest jako parametr wykonania tej funkcji.
        /// </summary>
        /// <param name="z">Zwierzę do zaatakowania</param>
        public void Gryź(Zwierzę z)
        {
            // tworzenie generatora liczb losowych
            Random r = new Random();
            // losuje liczbę z zakresu od 0 do maksymalnego ataku obecnego obiektu
            var moc = r.Next(this.Damage);

            // gryzienie powodzi się tylko w sytuacji, kiedy uda nam się wylosować liczbę
            // powyżej wartości zwinności celu
            if (r.NextDouble() * 10 > z.Agility)
                z.HP = z.HP - moc;
        }

        /// <summary>
        /// Zwraca stan gracza (imię i ilość HP) i można ją przeładować w klasach pochodnych,
        /// bo jest wirtualna, więc klasy pochodne mogą stan zwracać nieco inaczej
        /// </summary>
        /// <returns>Łańcuch opisujący stan gracza</returns>
        public virtual string Stan()
        {
            return string.Format("{0} HP: {1}", this.Imię, this.HP);
        }

        /// <summary>
        /// Nadpisanie metody ToString() z klasy System.Object, żeby zamiast
        /// standardowego tekstu pokazywało imię zwierzątka
        /// </summary>
        /// <returns>Imię zwierzęcia</returns>
        public override string ToString()
        {
            return this.Imię;
        }
    }
}