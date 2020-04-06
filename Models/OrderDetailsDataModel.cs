using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectPetey.Models
{
    


    public class OrderDetailsDataModel
    {

       private ProjectPeteyEntities db = new ProjectPeteyEntities();

        public List<ChartModel> GetOrderbyModelPet()
        {
            var chartDataList = new List<ChartModel>();


            var prod = db.Orders_Details.OrderBy(i => i.Product_Id).ToList();
            foreach (var item in prod.GroupBy(i => i.Product_Id))
            {
                var chartData = new ChartModel();
                chartData.Name= item.FirstOrDefault().Pet.Gene;
                chartData.Amount = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }

        public class ChartModel
        {
            public string Name { get; set; }
            public int Amount { get; set; }
        }

        public List<ChartModel> GetOrderbyModelProduct()
        {
            var chartDataList = new List<ChartModel>();

            var prod = db.Orders_Details.OrderBy(i => i.Product_Id2).ToList();
            foreach (var item in prod.GroupBy(i => i.Product_Id2))
            {
                var chartData = new ChartModel();
                chartData.Name = item.FirstOrDefault().Product.Name;
                chartData.Amount = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }

        public List<ChartModel> GetOrderbyModelTrainer()
        {
            var chartDataList = new List<ChartModel>();
            var prod = db.Orders_Details.OrderBy(i => i.Product_Id3).ToList();
            foreach (var item in prod.GroupBy(i => i.Product_Id3))
            {
                var chartData = new ChartModel();
                chartData.Name = item.FirstOrDefault().Trainer.Name;
                chartData.Amount = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }



    }

    //public class OrderDetailsDataModelProduct
    //{
    //    PeteyEntities3 db = new PeteyEntities3();

    //    public List<ChartModel> GetOrderbyModelProduct()
    //    {
    //        var chartDataList2 = new List<ChartModel>();

    //        var prod = db.Orders_Details.OrderBy(i => i.Product_Id2).ToList();
    //        foreach (var item in prod.GroupBy(i => i.Product_Id2))
    //        {
    //            var chartData = new ChartModel();
    //            chartData.Model = item.FirstOrDefault().Product.Name;
    //            chartData.Amount = item.Count();
    //            chartDataList2.Add(chartData);
    //        }
    //        return chartDataList2;
    //    }
    }

    //public class OrderDetailsDataModelTrainer
    //{
    //    PeteyEntities3 db = new PeteyEntities3();

    //    public List<ChartModel> GetOrderbyModelTrainer()
    //    {
    //        var chartDataList3 = new List<ChartModel>();
    //        var prod = db.Orders_Details.OrderBy(i => i.Product_Id3).ToList();
    //        foreach (var item in prod.GroupBy(i => i.Product_Id3))
    //        {
    //            var chartData = new ChartModel();
    //            chartData.Model = item.FirstOrDefault().Trainer.Name;
    //            chartData.Amount = item.Count();
    //            chartDataList3.Add(chartData);
    //        }
    //        return chartDataList3;
    //    }
    //}
