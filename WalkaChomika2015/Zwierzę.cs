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
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika
{ 
    /// <summary>
    /// Klasa Zwierzę, reprezentująca zwierzę bojowe
    /// </summary>
    class Zwierzę
    {
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

            // zwierzęciu przekazanemu jako parametr odejmuje od punktów HP tyle, ile wyniosła moc ataku
            z.HP = z.HP - moc;
        }
    }
}
