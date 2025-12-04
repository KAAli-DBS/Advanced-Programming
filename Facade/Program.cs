﻿using System;

// Subsystems 
public class Amplifier
{
    public void On() => Console.WriteLine("Amplifier is ON");
    public void Off() => Console.WriteLine("Amplifier is OFF");
}

public class DVDPlayer
{
    public void Play() => Console.WriteLine("DVD Player is PLAYING");
    public void Stop() => Console.WriteLine("DVD Player is STOPPED");
}

public class Projector
{
    public void On() => Console.WriteLine("Projector is ON");
    public void Off() => Console.WriteLine("Projector is OFF");
}

// Facade Class
public class HomeTheaterFacade
{
    private Amplifier _amplifier;
    private DVDPlayer _dvdPlayer;
    private Projector _projector;

    public HomeTheaterFacade(Amplifier amplifier, DVDPlayer dvdPlayer, Projector projector)
    {
        _amplifier = amplifier;
        _dvdPlayer = dvdPlayer;
        _projector = projector;
    }

    public void StartMovie()
    {
        Console.WriteLine("Starting the movie...");
        _amplifier.On();
        _dvdPlayer.Play();
        _projector.On();
        Console.WriteLine("Movie started!\n");
    }

    public void EndMovie()
    {
        Console.WriteLine("Stopping the movie...");
        _dvdPlayer.Stop();
        _projector.Off();
        _amplifier.Off();
        Console.WriteLine("Movie stopped!\n");
    }
}

// Client Code 

public class Program
{
    public static void Main(string[] args)
    {
        // Subsystems
        Amplifier amplifier = new Amplifier();
        DVDPlayer dvdPlayer = new DVDPlayer();
        Projector projector = new Projector();

        // Facade
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(amplifier, dvdPlayer, projector);

        // Using the Facade
        homeTheater.StartMovie();
        homeTheater.EndMovie();
    }
}