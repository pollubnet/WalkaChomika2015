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

namespace WalkaChomika.Models
{
    /// <summary>
    /// Delegat, który określa jakie funkcje będą mogły
    /// (jakiego typu) odbierać zdarzenie, o tym, że zwierzę umarło
    /// </summary>
    public delegate void ZwierzęMartweDelegate(Zwierzę sender);

    /// <summary>
    /// Klasa Zwierzę, reprezentująca zwierzę bojowe
    /// </summary>
    public abstract class Zwierzę
    {
        /// <summary>
        /// Zdarzenie, że zwierzę jest martwe, które będziemy
        /// mogli zasubskrybować.
        /// </summary>
        public event ZwierzęMartweDelegate ZwierzęMartwe;

        /// <summary>
        /// Konstruktor klasy zwierzę, nadający bazowe wartości jej parametrów
        /// </summary>
        public Zwierzę()
        {
            this.HP = 1;
            this.Mana = 0;
            this.Damage = 2;
            this.Agility = 0;

            Licznik = Licznik + 1;

            
        }

        /// <summary>
        /// Pole statyczne, wspólne dla wszystkich obiektów klasy Zwierzę i pochodnych
        /// zwiększane za każdym utworzonym zwierzęciem
        /// </summary>
        public static int Licznik = 0;

        /// <summary>
        /// To jest tzw. właściwość. Powinno używać się właściwości zamiast pól, ale dlaczego, to już
        /// kwestia nieco bardziej zaawansowana, więc chwilowo ją pominiemy. To konkretne pole reprezentuje
        /// imię zwierzęcia.
        /// </summary>
        public string Imię { get; set; }

        /// <summary>
        /// Prywatny element punktów życia
        /// </summary>        
        private int _HP;

        /// <summary>
        /// To pole jest liczbą, która reprezentuje ile zwierzę ma punktów życia
        /// </summary>
        public virtual int HP
        {
            get { return _HP; }
            set { _HP = value;
                // jeśli próbujemy zmienić HP zwierzęcia,
                // to spraw, czy ono jeszcze żyje i jeśli ktoś
                // słucha czy żyje czy nie, to go poinformuj
                if (!CzyŻyje() && (ZwierzęMartwe != null))
                    ZwierzęMartwe.Invoke(this);
                }
        }

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
        public virtual bool CzyŻyje()
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
        public virtual void Gryź(Zwierzę z)
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