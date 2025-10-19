using FitNet.Domain.Enums;

namespace FitNet.Domain.Entities;
public class Measurement
{
    public double Quantity { get; set; }
    public UnitOfMeasure Unit { get; set; }
}
