// CarsInventoryMvc/Models/Car.
namespace CarsInventoryMvc.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public bool New { get; set; }
}
