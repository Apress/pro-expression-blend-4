using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CollectionDataContext
{
	// A simple custom business object. 
    public class PurchaseOrder
    {
	    public PurchaseOrder(){}
        public PurchaseOrder(int amt, double cost, string desc)
        {
            Amount = amt;
            TotalCost = cost;
            Description = desc;
        }
		
	    public int Amount {get; set;}
	    public double TotalCost{get; set;}
	    public string Description{get; set;}
    }

	// A custom collection of PurchaseOrder objects.
    public class PurchaseOrders : 
        System.Collections.ObjectModel.ObservableCollection<PurchaseOrder>
    {
        public PurchaseOrders()
        {
            // Add a few items upon startup.
            this.Add(new PurchaseOrder(5, 50.00, "Mikko's Cat Nip Treat"));
            this.Add(new PurchaseOrder(5, 50.00, "Saku's Best Dog Bone"));
            this.Add(new PurchaseOrder(1, 2.50, "Extra Bland Tofu"));
        }
    }
}