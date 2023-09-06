using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicredit
{
    internal class ContoCorrente
    {
        public string NomeCorrentista { get; set; }
        public string CognomeCorrentista { get; set; }
        public DateTime DataDiApertura { get; set; }
        public int NrDiConto { get; set; }
        public double Saldo = 0;

        public ContoCorrente() { }
        public ContoCorrente(string nome, string cognome)
        {
            NomeCorrentista = nome;
            CognomeCorrentista = cognome;
            DataDiApertura = DateTime.Now;
            Saldo = 0;
        }
        public ContoCorrente(string nome, string cognome, DateTime data, int nrDiConto, double saldo )
        {
            NomeCorrentista = nome; 
            CognomeCorrentista = cognome;
            DataDiApertura = data;
            NrDiConto = nrDiConto;
            Saldo = saldo;
        }


    }
}
