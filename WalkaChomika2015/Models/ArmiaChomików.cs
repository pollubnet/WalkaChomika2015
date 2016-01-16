#region License

/*
 * Written in 2014 by Marcin Badurowicz <m dot badurowicz at pollub dot pl>
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Klasa reprezentująca kolejnego nowego zawodnika - armię krwiożerczych chomików
    /// </summary>
    internal class ArmiaChomików : Zwierzę
    {
        /// <summary>
        /// Prywatna lista chomików, członków armii
        /// </summary>
        private List<Chomik> armia;

        /// <summary>
        /// Konstruktor - w odróżnieniu od innych typowych dla klasy Zwierzę, nie przyjmuje imienia,
        /// ale liczbę chomików w armii
        /// </summary>
        /// <param name="liczba"></param>
        public ArmiaChomików(int liczba)
        {
            // jeśli liczba chomików jest mniejsza lub równa 0, rzuć wyjątek
            // dotyczący tego parametru
            if (liczba <= 0)
                throw new ArgumentOutOfRangeException("liczba", "Armia musi mieć żołnierzy!");

            // tworzenie listy
            armia = new List<Chomik>();

            // dodawanie do listy
            for (int i = 0; i < liczba; i++)
            {
                armia.Add(new Chomik("Chomik " + i));
            }

            this.Agility = 1;
            this.Mana = 0;
            this.Imię = "Niezwyciężona Armia";
        }

        /// <summary>
        /// Nadpisane bazowe akcesory dla cechy, jaką jest HP
        /// </summary>
        public override int HP
        {
            // HP armii jest sumą HP wszystkich jej członków
            get
            {
                int suma = 0;
                for (int i = 0; i < armia.Count; i++)
                {
                    suma = suma + armia[i].HP;
                }

                return suma;
            }

            // zmiana HP armii tak naprawdę powoduje tylko atak na jednego z zawodników
            set
            {
                if (armia != null)
                {
                    int dmg = Math.Abs(value);

                    //Random r = new Random();
                    //int cel = r.Next(armia.Count);

                    //armia[cel].HP = armia[cel].HP - dmg;
                    //if (armia[cel].HP < 0)
                    //{
                    //    Debug.WriteLine(armia[cel].Imię + " RIP!");
                    //    armia.RemoveAt(cel);
                    //}

                    // wybieramy, kto jest najsłabszy
                    // i to jemu zabieramy HP
                    var cel = najsłabszeOgniwo();
                    cel.HP -= dmg;
                    if (cel.HP < 0)
                    {
                        Debug.WriteLine(cel.Imię + " RIP!");
                        armia.Remove(cel);
                    }
                }
            }
        }

        /// <summary>
        /// Wybór najsłabszego chomika, który zostanie zaatakowany
        /// </summary>
        /// <returns>Chomik o najmniejszej liczbie HP</returns>
        private Chomik najsłabszeOgniwo()
        {
            return armia.OrderByDescending(x => x.HP).First();
        }

        /// <summary>
        /// Nadpisanie sprawdzania, czy armia żyje - zwraca, czy ktokolwiek w armii pozostał przy życiu
        /// </summary>
        /// <returns>Czy ktokolwiek pozostał żywy</returns>
        public override bool CzyŻyje()
        {
            return (armia.Count > 0);
        }

        /// <summary>
        /// Nadpisana funkcja opisująca stan, nie podaje HP, ale ilość pozostałych przy życiu
        /// żołnierzy
        /// </summary>
        /// <returns>Nazwa armii i liczba żywych chomików w niej</returns>
        public override string Stan()
        {
            return string.Format("{0} Ilość: {1}", this.Imię, armia.Count);
        }

        /// <summary>
        /// Nadpisana funkcja gryzienia - każdy chomik w armii gryzie wroga
        /// </summary>
        /// <param name="z"></param>
        public override void Gryź(Zwierzę z)
        {
            // tworzenie generatora liczb losowych
            Random r = new Random();

            foreach (Chomik c in armia)
            {
                // losuje liczbę z zakresu od 0 do maksymalnego ataku obecnego obiektu
                var moc = r.Next(c.Damage);

                // gryzienie powodzi się tylko w sytuacji, kiedy uda nam się wylosować liczbę
                // powyżej wartości zwinności celu
                if (r.NextDouble() * 10 > z.Agility)
                    z.HP = z.HP - moc;
            }
        }
    }
}