//----------------------AuditService proj(UniversalWindows)
//Auditors.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Data.Xml.Dom;
using DataTypes;

namespace AuditService
{
  public class Auditor
  {
      public void AuditOrder(Order order)
      {
          this.doAuditing(order);
      }

      private async void doAuditing(Order order)
      {
          List<OrderItem> ageRestrictedItems = findAgeRestrictedItems(order);
          if (ageRestrictedItems.Count > 0)
          {
              try
              {
                  StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync($"audit-{order.OrderID}.xml");
                  if (file != null)
                  {
                      XmlDocument doc = new XmlDocument();
                      XmlElement root = doc.CreateElement("Order");
                      root.SetAttribute("ID", order.OrderID.ToString());
                      root.SetAttribute("Date", order.Date.ToString());

                      foreach (OrderItem orderItem in ageRestrictedItems)
                      {
                          XmlElement itemElement = doc.CreateElement("Item");
                          itemElement.SetAttribute("Product", orderItem.Item.Name);
                          itemElement.SetAttribute("Description", orderItem.Item.Description);
                          root.AppendChild(itemElement);
                      }

                      doc.AppendChild(root);

                      await doc.SaveToFileAsync(file);
                  }
                  else
                  {
                      MessageDialog dlg = new MessageDialog($"Unable to save to file: {file.DisplayName}", "Not saved");
                      dlg.ShowAsync();
                  }
              }
              catch (Exception ex)
              {
                  MessageDialog dlg = new MessageDialog(ex.Message, "Exception");
                  dlg.ShowAsync();
              }
          }
      }

      private List<OrderItem> findAgeRestrictedItems(Order order)
      {
          return order.Items.FindAll(o => o.Item.AgeRestricted == true);
      }
  }
}

//---------------------------CheckoutService proj (Universal Windows)
//CheckoutController.cs

using DataTypes;

namespace CheckoutService
{
    public class CheckoutController
    {
        public delegate void CheckoutDelegate(Order order);
        public CheckoutDelegate CheckoutProcessing = null;

        private bool requestPayment()
        {
            // Payment processing goes here

            // Payment logic is not implemented in this example
            // - simply return true to indicate payment has been received
            return true;
        }

        public void StartCheckoutProcessing(Order order)
        {
            // Perform the checkout processing
            if (this.requestPayment())
            {
                if (this.CheckoutProcessing != null)
                {
                    this.CheckoutProcessing(order);
                }
            }
        }
    }
}
//--------------DataTypes proj (Universal Windows)
//Order.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
//OrderItem.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class OrderItem
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
    }
}

//Product.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Product
    {
        public string ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool AgeRestricted { get; set; }
    }
}

//ProductDataSource.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class ProductsDataSource
    {
        public List<Product> Products { get; set; }

        public ProductsDataSource()
        {
            // Populate data source with dummy data

            Products = new List<Product>
            {
                new Product { ProductID="P1", Name="Rope", Description="Best Italian hemp, 40ft", AgeRestricted=false, Price=28.00M },
                new Product { ProductID="P2", Name="Wood", Description="Pine, 4\' x 2\' x 18\'", AgeRestricted=false, Price=12.20M },
                new Product { ProductID="P3", Name="Screwdriver", Description="Crossheaded", AgeRestricted=false, Price=4.99M },
                new Product { ProductID="P4", Name="Power Drill", Description="1800 RPM hammer drill", AgeRestricted=true, Price=75.50M },
                new Product { ProductID="P5", Name="Hammer", Description="24oz heavy-duty claw hammer", AgeRestricted=false, Price=18.35M },
                new Product { ProductID="P6", Name="Power Saw", Description="Rotary action, high powered", AgeRestricted=true, Price=88.00M },
                new Product { ProductID="P7", Name="Nails", Description="2\" masonry nails", AgeRestricted=false, Price=5.00M },
                new Product { ProductID="P8", Name="Saw", Description="Fine-toothed fretsaw", AgeRestricted=false, Price=3.20M },
            };
        }
    }
}

//------------------------Delegates proj (Universal Windows)
//MainPage.xaml.cs

using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using DataTypes;
using AuditService;
using DeliveryService;
using Windows.UI.Popups;
using CheckoutService;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Delegates
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ProductsDataSource data = null;
        private Order order = null;
        private Auditor auditor = null;
        private Shipper shipper = null;
        private CheckoutController checkoutController = null;

        public MainPage()
        {
            this.InitializeComponent();

            this.auditor = new Auditor();
            this.shipper = new Shipper();
            this.checkoutController = new CheckoutController();
            this.checkoutController.CheckoutProcessing += this.auditor.AuditOrder;
            this.checkoutController.CheckoutProcessing += this.shipper.ShipOrder;
        }

        private void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            data = new ProductsDataSource();
            this.productList.DataContext = data.Products;

            this.order = new Order { Date = DateTime.Now, Items = new List<OrderItem>(), OrderID = Guid.NewGuid(), TotalValue = 0 };
        }

        private void AddProductToOrderButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                // Find the product ID of the selected product (contained in the Tag property of the button)
                Button addButton = sender as Button;
                string productId = addButton.Tag as string;

                // Display the list view header if it is not already visible
                this.listViewHeader.Visibility = Visibility.Visible;

                // Enable the checkout button if it is not already enabled
                this.checkout.IsEnabled = true;

                // Check to see whether this product has already been added to the order
                OrderItem orderItem = order.Items.Find(o => o.Item.ProductID == productId);
                if (orderItem != null)
                {
                    // If the product is already included the order just increment the quantity
                    orderItem.Quantity++;

                    // Update the total value of the order
                    order.TotalValue += orderItem.Item.Price;
                }
                else
                {
                    // If the product has not previously been included in the order then add it

                    // First, find the details of the product
                    Product product = data.Products.Find(p => p.ProductID == productId);

                    // Create an OrderItem that references this product and set the Quatity to 1
                    orderItem = new OrderItem { Item = product, Quantity = 1 };

                    // Add the OrderItem to the Order
                    this.order.Items.Add(orderItem);

                    // Update the total value of the order
                    this.order.TotalValue += product.Price;
                }

                // Rebind the ListView to the order data to update the display
                this.orderDetails.DataContext = null;
                this.orderDetails.DataContext = order.Items;

                // Display the total order value
                this.orderValue.Text = $"{order.TotalValue:C}";
            }
            catch (Exception ex)
            {
                MessageDialog dlg = new MessageDialog(ex.Message, "Exception");
                dlg.ShowAsync();
            }
        }

        private void CheckoutButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                // Perform the checkout processing
                this.checkoutController.StartCheckoutProcessing(this.order);

                // Display a summary of the order
                MessageDialog dlg = new MessageDialog($"Order {order.OrderID}, value {order.TotalValue:C}", "Order Placed");
                dlg.ShowAsync();

                // Clear out the order details so the user can start again with a new order
                this.order = new Order { Date = DateTime.Now, Items = new List<OrderItem>(), OrderID = Guid.NewGuid(), TotalValue = 0 };
                this.orderDetails.DataContext = null;
                this.orderValue.Text = $"{order.TotalValue:C}";
                this.listViewHeader.Visibility = Visibility.Collapsed;
                this.checkout.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageDialog dlg = new MessageDialog(ex.Message, "Exception");
                dlg.ShowAsync();
            }
        }


    }
}

//----------------------------DeliveryService proj(Universal Windows)
//Shipper.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using DataTypes;

namespace DeliveryService
{
    public class Shipper
    {
        public void ShipOrder(Order order)
        {
            this.doShipping(order);
        }

        private async void doShipping(Order order)
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync($"dispatch-{order.OrderID}.txt");
                if (file != null)
                {
                    string dispatchNote = $"Order Summary: \r\nOrder ID: {order.OrderID}\r\nOrder Total: {order.TotalValue:C}";

                    var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                    var writeStream = stream.GetOutputStreamAt(0);
                    DataWriter writer = new DataWriter(writeStream);
                    writer.WriteString(dispatchNote);
                    await writer.StoreAsync();
                    await writeStream.FlushAsync();
                    writeStream.Dispose();
                }
                else
                {
                    MessageDialog dlg = new MessageDialog($"Unable to save to file: {file.DisplayName}", "Not saved");
                    dlg.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog dlg = new MessageDialog(ex.Message, "Exception");
                dlg.ShowAsync();
            }
        }
    }
}
