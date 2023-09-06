using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicredit
{
    internal class Movimento
    {
        public int NrConto { get; set; }
        public double MovimentoDenaro { get; set; }
        
        public Movimento() { }
        public Movimento(int nrConto, double movimento) 
        {
            NrConto = nrConto;
            MovimentoDenaro = movimento;

            

        }
    }
    
    
}
