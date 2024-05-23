using EnvironmentalMonitoringSystem;
using Microsoft.Win32;
using System;
using System.Globalization;
using static EnvironmentalMonitoringSystem.Program;

namespace UnitTest
{
    /// <summary>
    /// Test Method to implementing the test unit in the
    /// Environmental Monitoring System
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        Program progObj = new Program();

        /// <summary>
        /// Method to test a temperatura with a normal value 
        /// </summary>
        [TestMethod]
        public void TrigerTemperature_WithinRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            decimal normalTemperatureValueExpected = 25m;
            decimal temperature = 20;
            string temperatureAlertExpected = $"Normal <= {(decimal)normalTemperatureValueExpected}°C";

            //Act
            string temperatureAlert = trigerTemperature(temperature, normalTemperatureValueExpected);

            //Assert
            Assert.AreEqual(temperatureAlertExpected, temperatureAlert);
        }

        /// <summary>
        /// Method to test a temperatura with a out range value 
        /// </summary>
        [TestMethod]
        public void trigerTemperature_WithOutRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            decimal normalTemperatureValueExpected = 25m;
            decimal temperature = 50;
            string temperatureAlertExpected = $"***Alert Condition***: Exceeds a predefined threshold of {normalTemperatureValueExpected}°C";

            //Act
            string temperatureAlert = trigerTemperature(temperature, normalTemperatureValueExpected);

            //Assert
            Assert.AreEqual(temperatureAlertExpected, temperatureAlert);
        }

        /// <summary>
        /// Method to test a Humidity with a normal value 
        /// </summary>
        [TestMethod]
        public void trigerHumidity_WithinRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            int normalHumidityValueExpected = 50;
            int humidity = 65;
            string humidityAlertExpected = $"Normal > {normalHumidityValueExpected}%";

            //Act
            string humidityAlert = trigerHumidity(humidity, normalHumidityValueExpected);

            //Assert
            Assert.AreEqual(humidityAlertExpected, humidityAlert);
        }

        /// <summary>
        /// Method to test a Humidity with a out range value 
        /// </summary>
        [TestMethod]
        public void trigerHumidity_WithOutRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            int normalHumidityValueExpected = 50;
            int humidity = 28;
            string humidityAlertExpected = $"***Alert Condition***: Falls below a predefined threshold of {normalHumidityValueExpected}%";

            //Act
            string humidityAlert = trigerHumidity(humidity, normalHumidityValueExpected);

            //Assert
            Assert.AreEqual(humidityAlertExpected, humidityAlert);

        }

        /// <summary>
        /// Method to test a Soil with a normal value 
        /// </summary>
        [TestMethod]
        public void trigerSoil_WithinRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            int normalSoilValueExpected = 60;
            int soil = 70;
            string SoilAlertExpected = $"Normal > {normalSoilValueExpected}%";

            
            //Act
            string soilAlert = trigerSoil(soil, normalSoilValueExpected);

            //Assert
            Assert.AreEqual(SoilAlertExpected, soilAlert);
        }

        /// <summary>
        /// Method to test a Soil with a out range value 
        /// </summary>
        [TestMethod]
        public void trigerSoil_WithOutRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            int normalSoilValueExpected = 60;
            int soil = 59;
            string SoilAlertExpected = $"***Alert Condition***: Drops below a predefined threshold of {normalSoilValueExpected}%";
        
            //Act
            string soilAlert = trigerSoil(soil, normalSoilValueExpected);

            //Assert
            Assert.AreEqual(SoilAlertExpected, soilAlert);

        }

        /// <summary>
        /// Method to test a LightIntensity with a normal value 
        /// </summary>
        [TestMethod]
        public void trigerLightIntensity_WithinRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            int normallightIntensityValueExpected = 5_000;
            int lightIntensity = 2500;
            string lightIntensityAlertExpected = $"Normal < {normallightIntensityValueExpected}";

            //Act
            string lightIntensityAlert = trigerLightIntensity(lightIntensity, normallightIntensityValueExpected);

            //Assert
            Assert.AreEqual(lightIntensityAlertExpected, lightIntensityAlert);
        }

        /// <summary>
        /// Method to test a Light Intensity with a out range value 
        /// </summary>
        [TestMethod]
        public void trigerLightIntensity_WithOutRangeValue()
        {
            //Arrange - Act - Assert(AAA) Pattern:
            // Arrange
            int normallightIntensityValueExpected = 5_000;
            int lightIntensity = 10_000;
            string lightIntensityAlertExpected = $"***Alert Condition***: Exceeds a predefined threshold of {normallightIntensityValueExpected} lux";

            //Act
            string lightIntensityAlert = trigerLightIntensity(lightIntensity, normallightIntensityValueExpected);

            //Assert
            Assert.AreEqual(lightIntensityAlertExpected, lightIntensityAlert);
        }
    }
}