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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void btnAddNewObject_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// First, get our object resource. 
			PurchaseOrders myOrders = (PurchaseOrders)this.Resources["PurchaseOrdersDataSource"];
			
			// Now, generate some random values for the numerical properties.
			Random r = new Random();
			int amount = r.Next(50);
			double cost = r.NextDouble();
			
			// Finally, add the new random test item.
			myOrders.Add(new PurchaseOrder(amount, cost, "TEST ITEM!"));
		}
	}
}