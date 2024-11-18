using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    public class SmartLight
    {
        // Полета и свойства
        private int brightness;

        public bool IsOn { get; set; }
        public string Color { get; set; }        
        public int Brightness
        {
            get { return brightness; }
            set
            { 
                if(value >= 0 && value <= 100)
                {
                    brightness = value;
                }
                else
                {
                    Console.WriteLine("Invalid brightness value.");
                }
            }
        }

        public SmartLight()
        {
            IsOn = false;
            Color = "White";
            Brightness = 50;
        }

        public SmartLight(int brightness, string color)
        {
            Brightness = brightness;
            Color = color;
        }

        // методи

        public void TurnOn()
        {
            if(IsOn)
            {
                Console.WriteLine("The light is already turned on.");
            }
            else
            {
                IsOn = true;
                Console.WriteLine("The light is turned on.");
            }
        }

        public void TurnOff()
        {
            if (!IsOn)
            {
                Console.WriteLine("The light is already turned off.");
            }
            else
            {
                IsOn = false;
                Console.WriteLine("The light is turned off.");
            }
        }

        public void AdjustBrightness(int brightness)
        {
            if(brightness >= 0 && brightness <= 100)
            {
                Brightness = brightness;
                Console.WriteLine("Brightness adjusted successfully.");
            }
            else
            {
                Console.WriteLine("Brightness must be in [0..100].");
            }
        }

        public void ChangeColor(string color)
        {
            Console.WriteLine("Light color was changed successfully.");
            Color = color;
        }

        public void DisplayInfo()
        {
            if(IsOn)
            {
                Console.WriteLine($"The light is on. COlor is {Color}, adjust to brightness {Brightness}/100.");
            }
            else
            {
                Console.WriteLine($"The light is off. It is light in {Color} color when works. Brightness adjustment: {Brightness}.");
            }
        }
    }
}
