using FinalProjectPetey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPetey.Controllers
{
    public class item
    {
        private Pet pet = new Pet();

        public Pet Pet
        {
            get { return pet; }
            set { pet = value; }
        }

        private int quantity;
        private int quantity1;
        private int quantity2;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public item(Pet pet, int quantity)
        {
            this.Pet = pet;
            this.quantity = quantity;
        }

        //    -------------------End Pet Method-----------------------------

        private Product product = new Product();

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public int QuantityProduct
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public item(Product product, int quantity)
        {
            this.Product = product;
            this.quantity = quantity;
        }

        //    -------------------End Product Method-----------------------------

        private Trainer trainer = new Trainer();

        public Trainer Trainer
        {
            get { return trainer; }
            set { trainer = value; }
        }


        public int QuantityTrainer
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public item(Trainer trainer, int quantity)
        {
            this.Trainer = trainer;
            this.quantity = quantity;
        }

        //    -------------------End Trainer Method-----------------------------
    }
}