using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlikAutomat
{
    internal class Product
    {
        int price;
        string name;


        public Product(int Price, string Name)
        {
            price = Price;
            name = Name;
        }





        public int Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return name + price;
        }
    }
    
}
