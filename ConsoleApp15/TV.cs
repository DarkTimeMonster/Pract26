namespace ConsoleApp15;
public class TV
{
    public string Brand { get; set; }
    public double Diagonal { get; set; }
    public decimal Price { get; set; }

    public TV(string brand, double diagonal, decimal price)
    {
        Brand = brand;
        Diagonal = diagonal;
        Price = price;
    }
}