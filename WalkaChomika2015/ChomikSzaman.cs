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
    /// Klasa ChomikSzaman dziedziczy po ZwierzęciuMagicznym
    /// </summary>
    internal class ChomikSzaman : ZwierzęMagiczne
    {
        /// <summary>
        /// Bazowy konstruktor - nie istnieje konstruktor bez parametrów
        /// tylko taki, który musi ustawić imię i wartość many
        /// </summary>
        /// <param name="imię">Imię stworzenia</param>
        /// <param name="mana">Wartość many stworzenia</param>
        public ChomikSzaman(string imię, int mana)
        {
            this.Imię = imię;
            this.Mana = mana;
            this.HP = this.HP * 100;
        }
    }
}