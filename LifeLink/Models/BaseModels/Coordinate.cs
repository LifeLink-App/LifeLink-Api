namespace LifeLink.Models.BaseModels;

public class Coordinate
{  
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Coordinate()
    {
        Latitude = 0;
        Longitude = 0;
    }

    public Coordinate(string coordinateStr)
    {
        var stringBreakDown = coordinateStr.Split('-');

        var culture = System.Globalization.CultureInfo.InvariantCulture;

        Latitude = Convert.ToDouble(stringBreakDown[0], culture);
        Longitude = Convert.ToDouble(stringBreakDown[1], culture);
    }
}
