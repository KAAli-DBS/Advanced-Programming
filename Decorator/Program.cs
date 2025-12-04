﻿using System;

namespace DecoratorPattern
{
    // Component Interface
    public interface INotifier
    {
        void Send(string message);
    }

    // Concrete Component
    public class BasicNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Basic Notification: {message}");
        }
    }

    // Base Decorator
    public class NotifierDecorator : INotifier
    {
        private readonly INotifier _notifier;

        public NotifierDecorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        public virtual void Send(string message)
        {
            _notifier.Send(message);
        }
    }

    // Concrete Decorators
    public class FacebookNotifier : NotifierDecorator
    {
        public FacebookNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Facebook Notification: {message}");
        }
    }

    public class TwitterNotifier : NotifierDecorator
    {
        public TwitterNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Twitter Notification: {message}");
        }
    }

    public class InstagramNotifier : NotifierDecorator
    {
        public InstagramNotifier(INotifier notifier) : base(notifier) { }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Instagram Notification: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            INotifier basicNotifier = new BasicNotifier();

           
            INotifier facebookNotifier = new FacebookNotifier(basicNotifier);

           
            INotifier twitterNotifier = new TwitterNotifier(facebookNotifier);

            
            INotifier instagramNotifier = new InstagramNotifier(twitterNotifier);

           
            instagramNotifier.Send("Hello, this is a multi-platform notification!");
        }
    }
}