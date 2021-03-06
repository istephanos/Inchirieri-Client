using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Client
    {
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int ID = 0;
        private const int CNP = 1;
        private const int NUME = 2;
        private const int PRENUME = 3;

        //proprietati auto-implemented

        private int idClient;//identificator unic 
        private string cnp; //client-cod numeric personal
        private string nume;
        private string prenume;

        //constructor implicit
        public Client()
        {
            cnp = nume = prenume = string.Empty;
        }

        //constructor cu parametri
        public Client(int idClient, string cnp, string nume, string prenume)
        {
            this.idClient = idClient;
            this.cnp = cnp;
            this.nume = nume;
            this.prenume = prenume;
        }

        public Client(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idClient= ConvertToInt32(dateFisier[ID]);
            cnp = dateFisier[CNP];
            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectClientPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idClient.ToString(),
                (cnp ?? " NECUNOSCUT "),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "));

            return obiectClientPentruFisier;
        }

        public int GetIdClient()
        {
            return idClient;
        }

        public string GetCNP()
        {
            return cnp;
        }

        public string GetNume()
        {
            return nume;
        }

        public string GetPrenume()
        {
            return prenume;
        }
    }
}
