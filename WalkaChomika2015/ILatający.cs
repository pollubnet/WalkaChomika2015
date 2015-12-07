using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika
{
    interface ILatający
    {
        bool CzyLata { get; set; }
        void Lataj();
    }
}
