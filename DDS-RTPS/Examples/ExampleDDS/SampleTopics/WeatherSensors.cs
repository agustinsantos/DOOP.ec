
namespace ExampleDDS.SampleTopics
{
    #region Some Class Definitions

    /// <summary>
    /// Basic class
    /// </summary>
    public class TemperatureSensor
    {
        public short Id { get; set; }
        public float Temp { get; set; }
    }

    /// <summary>
    /// Derived class, for testing inheritance.
    /// </summary>
    public class WeatherSensor : TemperatureSensor
    {
        public float Humidity { get; set; }
    }

    /// <summary>
    /// Class contains another class, for testing composition
    /// </summary>
    public class WeatherSensorComposition
    {
        public TemperatureSensor TempSensor { get; set; }
        public float Humidity { get; set; }
    }
    #endregion

    #region Some Struct Definitions

    /// <summary>
    /// Basic Struct
    /// </summary>
    public struct TemperatureSensorAsStruct
    {
        public short Id { get; set; }
        public float Temp { get; set; }
    }


    /// <summary>
    /// struct contains another struct, for testing composition
    /// </summary>
    public struct WeatherSensorAsStructComposition
    {
        public TemperatureSensorAsStruct TempSensor { get; set; }
        public float Humidity { get; set; }
    }
    #endregion

    #region Some mixed (class and structs) definitions
    /// <summary>
    /// class contains struct, for testing composition
    /// </summary>
    public class WeatherSensorComposition1
    {
        public TemperatureSensorAsStruct TempSensor { get; set; }
        public float Humidity { get; set; }
    }

    /// <summary>
    /// struct contains class, for testing composition
    /// </summary>
    public struct WeatherSensorComposition2
    {
        public TemperatureSensor TempSensor { get; set; }
        public float Humidity { get; set; }
    }
    #endregion

}
