using System;

namespace Interfaces_GL.Core.Datatypes
{
    internal static class SpeedUnitExtensions
    {
        public static string GetUnitText(this SpeedUnit fromUnit)
        {
            var result = string.Empty;

            switch (fromUnit)
            {
                case SpeedUnit.MilesPerHour:
                    result = "mph";
                    break;
                case SpeedUnit.KmPerHour:
                    result = "km/h";
                    break;
                case SpeedUnit.MetersPerSecond:
                    result = "m/s";
                    break;
                case SpeedUnit.Mach:
                    result = "mach";
                    break;

                default:
                    result = "n.d.";
                    break;
            }

            return result;
        }

        public static Speed ConvertFrom(this Speed fromSpeed, SpeedUnit destinationUnit)
        {
            var result = new Speed { Unit = destinationUnit };

            switch (destinationUnit)
            {
                case SpeedUnit.MilesPerHour:
                    result.Value = fromSpeed.Value / 1609.34 * 3600;
                    break;

                case SpeedUnit.KmPerHour:
                    result.Value = fromSpeed.Value / 1000.0 * 3600;
                    break;

                case SpeedUnit.MetersPerSecond:
                    result.Value = fromSpeed.Value;
                    break;

                case SpeedUnit.Mach:
                    result.Value = fromSpeed.Value / 343;
                    break;

                default:
                    throw new ArgumentException("Unknown unit for conversion detected.");
                    break;
            }

            return result;
        }

        public static Speed ConvertTo(this Speed fromSpeed)
        {
            var result = new Speed { Unit = SpeedUnit.MetersPerSecond };

            switch (fromSpeed.Unit)
            {
                case SpeedUnit.MilesPerHour:
                    //x*1609.34/60*60 => m/s
                    result.Value = fromSpeed.Value * 1609.34 / 3600;
                    break;

                case SpeedUnit.KmPerHour:
                    //x*1000/60*60 => m/s
                    result.Value = fromSpeed.Value * 1000.0 / 3600;
                    break;

                case SpeedUnit.MetersPerSecond:
                    result.Value = fromSpeed.Value;
                    break;

                case SpeedUnit.Mach:
                    result.Value = fromSpeed.Value * 343;
                    break;

                default:
                    throw new ArgumentException("Unknown unit for conversion detected.");
                    break;
            }

            return result;
        }
    }
}
