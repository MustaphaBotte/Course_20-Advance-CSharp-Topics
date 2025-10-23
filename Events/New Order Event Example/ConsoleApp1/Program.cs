class Client
{
    public string ClientName { get; } = "";
    public string ClientEmail { get; } = "";
    public string PhoneNUmber { get; } = "";

    public Client(string clientName, string clientEmail, string phoneNUmber)
    {
        ClientName = clientName;
        ClientEmail = clientEmail;
        PhoneNUmber = phoneNUmber;
    }
}
class OrderPlacedEventArgs:EventArgs
{
   public string OrderID { get; set; } = "";
   public string Product { get; } = "";
   public Client Client { get; }
   public DateTime OrderDate { get; } 

    public OrderPlacedEventArgs(string OrderID,string Product, Client Client, DateTime OrderDate)
    {
        this.OrderID = OrderID;
        this.Product = Product;
        this.Client = Client;
        this.OrderDate = OrderDate;
    }
}
class OrderCreator
{
    public event EventHandler<OrderPlacedEventArgs> OnOrderPlaced = delegate { };
    public string OrderID { get; set; } ="";
    string Product { get; set; } = "";
    Client? Client { get; set; } = null;
    DateTime OrderDate { get; set; }

    public void PlaceNewOrder(string Product, Client Client, DateTime OrderDate)
    {
        if(Product!=""&& Client != null)
        {
            this.OrderID =  Guid.NewGuid().ToString();
            this.Product = Product;
            this.Client = Client;
            this.OrderDate = OrderDate;
            RaiseOrderPlacedEvent();
        }
    }
    private void RaiseOrderPlacedEvent()
    {
        this.OnOrderPlaced?.Invoke(this,new OrderPlacedEventArgs(this.OrderID,this.Product, this.Client, this.OrderDate));
    }
}
class SendEmail
{
    public void Subscribe(OrderCreator order)
    {
        order.OnOrderPlaced += HandleOrderPlacedEvent;
    }
    public void UnSbnscribe(OrderCreator order)
    {
        order.OnOrderPlaced -= HandleOrderPlacedEvent;
    }
    private void HandleOrderPlacedEvent(object? sender , OrderPlacedEventArgs e)
    {
        Console.WriteLine("================================ Email Service =======================================");
        Console.WriteLine($"Email Sent SuccessFully To {e.Client.ClientEmail}");
        Console.WriteLine("==========================================================================================\n\n");

    }
}
class SendSms
{
    public void Subscribe(OrderCreator order)
    {
        order.OnOrderPlaced += HandleOrderPlacedEvent;
    }
    public void UnSbnscribe(OrderCreator order)
    {
        order.OnOrderPlaced -= HandleOrderPlacedEvent;
    }
    private void HandleOrderPlacedEvent(object? sender, OrderPlacedEventArgs e)
    {
        Console.WriteLine("================================ SMS Service =======================================");
        Console.WriteLine($"SMS Sent SuccessFully To {e.Client.PhoneNUmber}");
        Console.WriteLine("==========================================================================================\n\n");
    }
}
class Shipper
{
    public string ShipperName { get; } = "";
    public Shipper(string shipperName)
    {
        ShipperName = shipperName;
    }
    public void Subscribe(OrderCreator order)
    {
        order.OnOrderPlaced += HandleOrderPlacedEvent;
    }
    public void UnSbnscribe(OrderCreator order)
    {
        order.OnOrderPlaced -= HandleOrderPlacedEvent;
    }
    private void HandleOrderPlacedEvent(object? sender, OrderPlacedEventArgs e)
    {
        Console.WriteLine("================================ Speedaf Shipping =======================================");
        Console.WriteLine($"Order Created With ID ={e.OrderID}. and Will be shipped soon to the client {e.Client.ClientName}");
        Console.WriteLine("==========================================================================================\n\n");

    }
}

class Program
{
    static void Main()
    {
        Client client = new Client("Mustapha Botte", "Mostaphabotte@gmail.com", "+212704971758");
        Console.Write("Are you sure you want to place this order Y/n: ");
        string? choice = Console.ReadLine();
        if(choice?.ToLower()!="y")
        {
            return;
        }

        OrderCreator orderCreator = new OrderCreator();

        Shipper OrdersShipper = new Shipper("Speedaf");

        SendEmail sendEmail = new SendEmail();

        SendSms sendSms = new SendSms();



        OrdersShipper.Subscribe(orderCreator);
        sendEmail.Subscribe(orderCreator);
        sendSms.Subscribe(orderCreator);



        orderCreator.PlaceNewOrder("Gaming Computer", client, DateTime.Now);
    }

}