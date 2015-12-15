using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    class ArmiaChomików : Zwierzę
    {
        private List<Chomik> armia;

        public ArmiaChomików(int liczba)
        {
            armia = new List<Chomik>();

            for (int i = 0; i < liczba; i++)
            {
                armia.Add(new Chomik("Chomik " + i));
            }

            this.Agility = 1;
            this.Mana = 0;            
            this.Imię = "Niezwyciężona Armia";
        }

        public override int HP
        {
            get
            {
                int suma = 0;
                for (int i = 0; i < armia.Count; i++)
                {
                    suma = suma + armia[i].HP;
                }

                return suma;
            }

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

        private Chomik najsłabszeOgniwo()
        {
            return armia.OrderByDescending(x => x.HP).First();           
        }

        public override bool CzyŻyje()
        {
            return (armia.Count > 0);                
        }

        public override string Stan()
        {
            return string.Format("{0} Ilość: {1}", this.Imię, armia.Count);
        }

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
