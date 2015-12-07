using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika
{
    class Jednorożec : ZwierzęMagiczne, ILatający
    {
        public Jednorożec(string imię, int mana)
        {
            this.Imię = imię;
            this.Mana = mana;
            this.HP = 1000;
            this.Agility = 5;
            this.CzyLata = false;
        }

        public bool CzyLata { get; set; }

        public void Lataj()
        {
            if (Mana > 1)
            {
                CzyLata = true;
                this.Agility = 7;
                this.Mana--;
            }
            
        }
    }
}
