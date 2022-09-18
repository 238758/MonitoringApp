using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FM4017Library.DataModels.Sample
{
    /// <summary>
    /// Derived class that initialize an object with some "random" data in ctor. 
    /// </summary>
    public class SamplePoint : Point
    {
        private Random _rand = new Random();

        private List<string> _imageUrls = new() {
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.YgH2nVnzKjEu7UqymdXvvwHaD3%26pid%3DApi&f=1",
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.tJm9V35pSp89sd7tdgBesAHaEK%26pid%3DApi&f=1",
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.XOB5xdbzQZkqyTkkaHH3agHaEo%26pid%3DApi&f=1",
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse4.mm.bing.net%2Fth%3Fid%3DOIP.VP4BIAuADBOSO5iPwqZ39AHaFj%26pid%3DApi&f=1",
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse1.mm.bing.net%2Fth%3Fid%3DOIP.4V8u2N4lY2jC2-JPUuHRvQHaEw%26pid%3DApi&f=1",
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse3.mm.bing.net%2Fth%3Fid%3DOIP.ZnyfH7tpAIIL-6SI-GY2rAHaE8%26pid%3DApi&f=1",
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.VrNCRbjgBOaCQelyBhru9QHaGB%26pid%3DApi&f=1",
            "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Ftse2.mm.bing.net%2Fth%3Fid%3DOIP.WCql8zeWFIW7YAGmSoNZSwHaEK%26pid%3DApi&f=1"
        };

        private List<string> _sensorType = new()
        {
            "Temperature",
            "Barometer",
            "Humidity",
            "Cloud height",
            "Wind Speed"
        };

        private List<string> _unit = new()
        {
            "°C",
            "mBar",
            "%RH",
            "m",
            "m/s"
        };

        public SamplePoint()
        {
            Name = _sensorType[_rand.Next(_sensorType.Count)];
            signals = new List<Signal>() { 
                new Signal() { 
                    Value = (_rand.NextDouble() * 100).ToString("0.0"), 
                    Unit= _unit[_rand.Next(_unit.Count)],
                    Timestamp = DateTime.Now.AddMinutes(_rand.Next()).AddSeconds(_rand.Next())
                }};
            Latitude = (_rand.NextDouble() * 100).ToString("00.000");
            Longitude = (_rand.NextDouble() * 100).ToString("00.000");
            ImageUrl = _imageUrls[_rand.Next(_imageUrls.Count)];
        }
    }
}
