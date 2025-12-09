﻿using System;
using System.Collections.Generic;

class Program
{
    // The Visitor interface
    interface IVisitor
    {
        void Visit(ResidentialBuilding residential);
        void Visit(Bank bank);
        void Visit(CoffeeShop coffeeShop);
    }

    // The Element interface
    interface IBuilding
    {
        void Accept(IVisitor visitor);
    }

    // Concrete Elements
    class ResidentialBuilding : IBuilding
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Bank : IBuilding
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class CoffeeShop : IBuilding
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete Visitor
    class InsuranceAgent : IVisitor
    {
        public void Visit(ResidentialBuilding residential)
        {
            Console.WriteLine("Selling medical insurance to residents.");
        }

        public void Visit(Bank bank)
        {
            Console.WriteLine("Selling theft insurance to the bank.");
        }

        public void Visit(CoffeeShop coffeeShop)
        {
            Console.WriteLine("Selling fire and flood insurance to the coffee shop.");
        }
    }

    static void Main(string[] args)
    {
        // List of buildings in the neighborhood
        List<IBuilding> neighborhood = new List<IBuilding>
        {
            new ResidentialBuilding(),
            new Bank(),
            new CoffeeShop()
        };

        // Insurance agent (Visitor)
        InsuranceAgent agent = new InsuranceAgent();

        // Agent visits each building
        foreach (var building in neighborhood)
        {
            building.Accept(agent);
        }
    }
}