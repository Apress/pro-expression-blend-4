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

using System.IO;
using System.Windows.Markup;

namespace WpfControlsApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
            PopulateDocument();
		}

		private void ChangeColor(object sender, System.Windows.RoutedEventArgs e)
		{
			// Get the string value in the Button which was clicked. 
			string colorToUse = ((Button)sender).Content.ToString();
			
			// Now set the color by converting the string to 
			// solid color. 
			this.myInkArea.DefaultDrawingAttributes.Color = 
				(Color)ColorConverter.ConvertFromString(colorToUse);
		}

		private void txtPenSize_LostFocus(object sender, System.Windows.RoutedEventArgs e)
		{
            try
            {
                // Change the height and width of the pen based on the data in the text box.
                this.myInkArea.DefaultDrawingAttributes.Height = int.Parse(txtPenSize.Text);
                this.myInkArea.DefaultDrawingAttributes.Width = int.Parse(txtPenSize.Text);
            }
            catch
            {
                this.Title = "Bad Pen Size Value!";
            }
		}

        private void PopulateDocument()
        {
            // Add some data to the List item.
            this.listOfFunFacts.FontSize = 14;
            this.listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
            this.listOfFunFacts.ListItems.Add(new ListItem(new
                Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(
                new Paragraph(new Run("The API supports tables and embedded figures!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(
                new Paragraph(new Run("Flow documents are read only!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(
                new Paragraph(new Run("BlockUIContainer allows you to embed WPF controls in the document!"))));

            // Now add some data to the Paragraph.
            // First part of sentence.
            Run prefix = new Run("This paragraph was generated ");

            // Middle of paragraph.
            Bold b = new Bold();
            Run infix = new Run("dynamically");
            infix.Foreground = Brushes.Red;
            infix.FontSize = 30;
            b.Inlines.Add(infix);

            // Last part of paragraph. 
            Run suffix = new Run(" at runtime!");

            // Now add each piece to the collection of inline elements
            // of the Paragraph. 
            this.paraBodyText.Inlines.Add(prefix);
            this.paraBodyText.Inlines.Add(infix);
            this.paraBodyText.Inlines.Add(suffix);
        }

        private void btnSaveDoc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	using(FileStream fStream = File.Open("documentData.xaml", FileMode.Create))
			{
				XamlWriter.Save(this.myDocumentReader.Document, fStream);	
			}
        }

        private void btnLoadDoc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			using(FileStream fStream = File.Open("documentData.xaml", FileMode.Open))
			{
				try
				{
					FlowDocument doc = XamlReader.Load(fStream) as FlowDocument;
					this.myDocumentReader.Document = doc;
				} 
				catch(Exception ex) {MessageBox.Show(ex.Message, "Error Loading Doc!");}						 
			}
        }
	}
}