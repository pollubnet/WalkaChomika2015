using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika
{
    /// <summary>
    /// Klasa ZwierzęMagiczne dziedziczy po klasie Zwierzę
    /// </summary>
    class ZwierzęMagiczne : Zwierzę
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

        public override string Stan()
        {
            return string.Format("{0} HP: {1}, Mana: {2}", this.Imię, this.HP, this.Mana);
        }
    }
}
