class OrderEventArgs:EventArgs
{
    public Order order;
    public DateTime OrderTime;
    public OrderEventArgs(Order order, DateTime orderTime)
    {
        this.order = order;
        OrderTime = orderTime;
    }
}
static class RaiseOrderNotification
{
    public static event Action<OrderReceiver, OrderEventArgs> OnNewOrderPlaced;
    public static void RaiseNotification(OrderReceiver Waiter , OrderEventArgs e)
    {
        OnNewOrderPlaced?.Invoke(Waiter,e);
        OnNewOrderPlaced=null;
    }
}
class Order
{
    public OrderReceiver waiter { get; }
    public string DisheName { get;}
    public string DisheNotes { get; }
    public Order(string disheName, string disheNotes)
    {
        if(string.IsNullOrEmpty(disheName))
        {
            throw new Exception("Dishe Name Cannot Be empty");
        }
        DisheName = disheName;
        DisheNotes = disheNotes;
    }
}

class OrderReceiver
{
    public string Name { get; }
    public readonly string Role ="Waiter";
    public OrderReceiver(string name)
    {
        Name = name;
    }
    public void PlaceOrder(string disheName, string disheNotes, KitchenStation1 kitchenStation1)
    {
        Order order = new Order(disheName, disheNotes);
        kitchenStation1.OnDisheISReady += TakeOrderFromKitchen;
        RaiseOrderNotification.RaiseNotification(this,new OrderEventArgs(order,DateTime.Now));
    }
    private void TakeOrderFromKitchen(OrderReceiver waiter ,OrderEventArgs e)
    {
        if (waiter.Name == this.Name) // when the chef call the name of the waiter
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Hello Mr Client Here Is your order");
            Console.WriteLine($"Your Order Is : {e.order.DisheName + " With " + e.order.DisheNotes}");
            Console.WriteLine("_________________________________ Enjoy :) _______________________________");
            Console.WriteLine("==========================================================================");
        }
    }
}
class IngredientInMinimumLevelEventArgs
{
    public Dictionary<string, int> IngredientNeeded;
    public IngredientInMinimumLevelEventArgs(Dictionary<string, int> ingredientNeeded)
    {
        IngredientNeeded = ingredientNeeded;
    }
}
static class ClsIngredient
{
    public static Dictionary<string, int> Ingredient = new Dictionary<string, int>(); //empty for the moment;
    
}
class KitchenStation1
{
    public event Action<OrderReceiver,OrderEventArgs> OnDisheISReady;
    public event Action<KitchenStation1> IngredientInMinimumLevel;

    public KitchenStation1()
    {
        RaiseOrderNotification.OnNewOrderPlaced += CookDishe;
    }
    private void CookDishe(object? sender, OrderEventArgs e)
    {
        if (ClsIngredient.Ingredient.Count == 0)
        {
            this.IngredientInMinimumLevel?.Invoke(this);
            
        }

        Console.WriteLine("==========================================================================");
        for (int i=0;i<3;i++)
        {
            Console.WriteLine("Cooking ...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("==========================================================================\n\n");
        OnDisheISReady?.Invoke((OrderReceiver)sender, e);
    }
}
class Supplier
{
    public string Name { get; }
    public Supplier(string name, Manager manager)
    {
        Name = name;
        manager.IngredientInMinimumLevel += SendIngredientToKitchern;
    }
    private void SendIngredientToKitchern()
    {
        Console.WriteLine("========================================================");
        Console.WriteLine("                Ingredient On The Way                   ");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Cooming ...");
            Thread.Sleep(1000);
        }
        ClsIngredient.Ingredient.Add("Oil", 10);
        ClsIngredient.Ingredient.Add("Dough", 15);
        ClsIngredient.Ingredient.Add("chicken", 10);
        ClsIngredient.Ingredient.Add("water", 60);
        ClsIngredient.Ingredient.Add("sugar", 10);
        Console.WriteLine("Ingredient Was Shipped thank you");
        Console.WriteLine("========================================================\n");
    }
}
class Manager
{
    string RoleName { get; }
    public event Action IngredientInMinimumLevel;
    public Manager(string RoleName, KitchenStation1 kitchenStation1)
    {
        this.RoleName = RoleName;
        kitchenStation1.IngredientInMinimumLevel += CallSupliers;

    }
    private void CallSupliers(object? sender)
    {
        IngredientInMinimumLevel?.Invoke();
    }

}

class Program
{
    static void Main()
    {
        OrderReceiver waiter = new OrderReceiver("Mustapha");
        KitchenStation1 kitchenStation1 = new KitchenStation1();
        Manager manager = new Manager("Ahmed", kitchenStation1);//manage this kitchen
        Supplier supplier = new Supplier("Marjane", manager);

        waiter.PlaceOrder("Pizza", "Extra sauce", kitchenStation1);
    }



}