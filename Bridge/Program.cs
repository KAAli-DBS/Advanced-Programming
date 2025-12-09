
﻿using System;

class Program
{
    // Abstraction
    abstract class RemoteControl
    {
        protected IDevice _device;

        protected RemoteControl(IDevice device)
        {
            _device = device;
        }

        public abstract void TogglePower();
    }

    // Refined Abstraction
    class BasicRemoteControl : RemoteControl
    {
        public BasicRemoteControl(IDevice device) : base(device) { }

        public override void TogglePower()
        {
            if (_device.IsOn())
            {
                _device.TurnOff();
                Console.WriteLine("Remote: Turning off the device.");
            }
            else
            {
                _device.TurnOn();
                Console.WriteLine("Remote: Turning on the device.");
            }
        }
    }

    // Implementation Interface
    interface IDevice
    {
        void TurnOn();
        void TurnOff();
        bool IsOn();
    }

    // Concrete Implementations
    class TV : IDevice
    {
        private bool _isOn = false;

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("TV: The TV is now ON.");
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("TV: The TV is now OFF.");
        }

        public bool IsOn()
        {
            return _isOn;
        }
    }

    class Radio : IDevice
    {
        private bool _isOn = false;

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine("Radio: The Radio is now ON.");
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("Radio: The Radio is now OFF.");
        }

        public bool IsOn()
        {
            return _isOn;
        }
    }

    static void Main(string[] args)
    {
        // Using a TV with a Basic Remote
        IDevice tv = new TV();
        RemoteControl tvRemote = new BasicRemoteControl(tv);
        tvRemote.TogglePower();
        tvRemote.TogglePower();

        Console.WriteLine();

        // Using a Radio with a Basic Remote
        IDevice radio = new Radio();
        RemoteControl radioRemote = new BasicRemoteControl(radio);
        radioRemote.TogglePower();
        radioRemote.TogglePower();
    }
}