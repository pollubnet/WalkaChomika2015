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

namespace WalkaChomika
{
    /// <summary>
    /// Klasa Chomik, dziedzicząca po Zwierzę
    /// </summary>
    internal class Chomik : Zwierzę
    {
        /// <summary>
        /// Ma własny konstruktor, który ustawia imię i nie ma bez -
        /// więc nie da się stworzyć go bez imienia
        /// </summary>
        /// <param name="imię">Imię chomika</param>
        public Chomik(string imię)
        {
            this.Imię = imię;

            this.HP = 5;
            this.Mana = 0;
            this.Damage = 2;
            this.Agility = 7;
        }
    }
}