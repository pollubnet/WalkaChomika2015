using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika
{
    /// <summary>
    /// Klasa ChomikSzaman dziedziczy po ZwierzęciuMagicznym
    /// </summary>
    class ChomikSzaman : ZwierzęMagiczne
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
