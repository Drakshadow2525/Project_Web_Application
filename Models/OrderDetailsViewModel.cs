using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPetey.Models
{
    public class OrderDetailsViewModel
    {
            public string Gene { get; set; }
            public string Name { get; set; }
            public decimal? PricePet { get; set; }
            public int? Amount { get; set; }
            public decimal? Total { get; set; }

            public string BrandProduct { get; set; }
            public string NameProduct { get; set; }
            public decimal? PriceProduct { get; set; }
            public int? AmountProduct { get; set; }
            public decimal? TotalProduct { get; set; }

            public string NameTrainer { get; set; }
            public decimal? PriceTrainer { get; set; }
            public int? AmountTrainer { get; set; }
            public decimal? TotalTrainer { get; set; }

    }


    public class OrderDetailsViewModelPet
    {
        public string Gene { get; set; }
        public string Name { get; set; }
        public decimal? PricePet { get; set; }
        public int? Amount { get; set; }
        public decimal? Total { get; set; }
    }

    public class OrderDetailsViewModelProduct
    {
       

        public string BrandProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal? PriceProduct { get; set; }
        public int? AmountProduct { get; set; }
        public decimal? TotalProduct { get; set; }


    }

    public class OrderDetailsViewModelTrainer
    {
        public string NameTrainer { get; set; }
        public decimal? PriceTrainer { get; set; }
        public int? AmountTrainer { get; set; }
        public decimal? TotalTrainer { get; set; }

    }
}