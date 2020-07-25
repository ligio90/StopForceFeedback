using System;
using System.ComponentModel;

namespace AntiFFB
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LogitechGSDK.LogiSteeringInitialize(false);
            Console.WriteLine("Gebe bitte den gewünschten Maximalwinkel ein (180° = 90° in jede Richtung)");
            int response = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Ist Lenkrad verbunden? {LogitechGSDK.LogiIsConnected(0)}");
            while (true)
            {
                if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
                {
                    LogitechGSDK.LogiStopSpringForce(0);
                    LogitechGSDK.LogiPlaySpringForce(0, 0, 0, 0);
                    LogitechGSDK.LogiSetOperatingRange(0, response);
                }
            }
        }
    }
}