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

namespace WalkaChomika
{
    /// <summary>
    /// Klasa ZwierzęMagiczne dziedziczy po klasie Zwierzę
    /// </summary>
    internal class ZwierzęMagiczne : Zwierzę
    {
        /// <summary>
        /// Konstruktor, który ustawia wartości podstawowe
        /// </summary>
        public ZwierzęMagiczne()
        {
            this.HP = 10;
            this.Mana = 0;
            this.Damage = 5;
        }

        /// <summary>
        /// Konstruktor, który ustawia wartości przekazane jako parametry
        /// </summary>
        /// <param name="imię">Imię stworzenia</param>
        /// <param name="mana">Ilość many stworzenia</param>
        public ZwierzęMagiczne(string imię, int mana)
        {
            this.Imię = imię;
            this.Mana = mana;
        }

        /// <summary>
        /// Funkcja ataku magicznego, jest prawie analogiczna do funkcji
        /// Gryzienia, ale ma o wiele większą moc
        /// </summary>
        /// <param name="z"></param>
        public void AtakujMagicznie(Zwierzę z)
        {
            if (this.Mana > 0)
            {
                // tworzenie generatora liczb losowych
                Random r = new Random();
                // losuje liczbę z zakresu od 0 do maksymalnego ataku obecnego obiektu
                var moc = r.Next(this.Damage * 100);
                this.Mana = this.Mana - 1;

                // zwierzęciu przekazanemu jako parametr odejmuje od punktów HP tyle, ile wyniosła moc ataku
                z.HP = z.HP - moc;
            }
        }

        /// <summary>
        /// Nadpisana w stosunku do klasy Zwierzę funkcja Stan, wyświetlająca w inny sposób
        /// </summary>
        /// <returns>Zwraca imię, HP oraz manę zwierzęcia magicznego</returns>
        public override string Stan()
        {
            return string.Format("{0} HP: {1}, Mana: {2}", this.Imię, this.HP, this.Mana);
        }
    }
}