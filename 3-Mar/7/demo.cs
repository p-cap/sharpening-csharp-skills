using MarketSystems;

Console.WriteLine("--- Market Monitor Active ---");

// Object initialization can be simplified IDE0017
// var monitor = new PriceMonitor("Bitcoin", 60000m);

// IDE0017 suggests object initializer
var monitor = new PriceMonitor("Bitcoin", 60000m)
{
    OnPriceChanged = (msg) => Console.WriteLine($"[NOTIFICATIONS]: {msg}")
};

monitor.UpdatePrice(62000m);
monitor.UpdatePrice(50000m);

// 1. define namespace
namespace MarketSystems
{
    // 2. PRIMARY CONSTRUCTOR
    public class PriceMonitor(string name, decimal basePrice)
    {
        // 3. define delegate type
        public delegate void PriceChangeHandler(string message);

        // a property to hold the delegate "callback"
        // this is a common pattern
        // the delegate declaration below checks if it's null first because it uses Null-Conditional Operator
        public PriceChangeHandler? OnPriceChanged { get; set; }

        private decimal _currentPrice = basePrice;

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < _currentPrice)
            {
                // the Invoke funvtion can be utilized because it is made available as delegate property
                OnPriceChanged?.Invoke($"{name} dropped to {newPrice}! (Down from {_currentPrice})");
            }
            else
            {
                Console.WriteLine($"{name} is already at {newPrice}");
            }

            _currentPrice = newPrice;
        }
    }
}