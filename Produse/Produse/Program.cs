using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Produse
{
    public class Produs
    {
        /*static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }*/

        private List<string> _products;
        private const string resources = "Produse\\";

        public Produs()
        {
            _products = new List<string>();
            StreamReader sr = new StreamReader(resources + "produse.txt");
            string line;
            line = sr.ReadLine();
            if (line == null)
                Console.WriteLine("Fisier gol");
            else
            {
                while (line!=null)
                {
                    _products.Add(line);
                    line = sr.ReadLine();

                }

            }
        }

        public int getNrProduse()
        {
            return _products.Count;
        }

        public Boolean checkNull(List<string> lista)
        {
            if (lista.Count == 0)
                return true;
            else
                return false;
        }



        public string[] returnAll()
        {
            string[] lista_produse = new string[_products.Count];
            if (checkNull(_products) == true)
                return null;
            for (int i = 0; i < _products.Count; i++)
                lista_produse[i] = _products[i];

            return lista_produse;
           
            
        }


        public void AddProduct(string name)
        {
            foreach (string str in _products)
                if (str.Equals(name))
                    return;
            _products.Add(name);

            Save();
        }


        public void Save()
        {
            StreamWriter wr = new StreamWriter(resources + "produse.txt");
            foreach(string str in _products)
            {
                wr.WriteLine(str);
            }

            wr.Close();
        }

        public void DeleteProduct(string name)
        {
            for (int i=0;i<_products.Count;i++)
            {
                if (_products[i]==name)
                {
                    _products.RemoveAt(i);
                }
            }
            Save();
        }


    }
}
