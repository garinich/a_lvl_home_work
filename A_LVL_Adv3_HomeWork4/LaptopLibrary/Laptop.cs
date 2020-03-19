using System;
using System.Collections;
using System.Collections.Generic;

namespace LaptopLibrary
{
    public class Laptop
    {
        public Laptop(string manufacturerName, int diagonal, int amountOfCPU, int amountOfRAM)
        {
            ManufacturerName = manufacturerName;
            Diagonal = diagonal;
            AmountOfCPU = amountOfCPU;
            AmountOfRAM = amountOfRAM;
        }

        public string ManufacturerName { get; }
        public int Diagonal { get; }
        public int AmountOfCPU { get; }
        public int AmountOfRAM { get; }
    }

    public class LaptopTable : IEnumerable
    {
        public List<Laptop> Laptops = new List<Laptop>();

        // Get Laptops length

        public int GetLength
        {
            get
            {
                return Laptops.Count;
            }
        }

        // Get Laptop by index

        public Laptop this[int index]
        {
            get
            {
                return Laptops[index];
            }
        }

        // Add new laptop

        public void Add(Laptop laptop)
        {
            Laptops.Add(laptop);
        }

        // Remove laptop by Id

        public void RemoveById(int Id)
        {
            Laptops.RemoveAt(Id);
        }

        // Get Laptop Index By Hash

        public string GetLaptopIndexByHash(int hash)
        {
            string laptopIndex = "";
            for (int i = 0; i < Laptops.Count; i++)
            {
                if (Laptops[i].GetHashCode() == hash)
                {
                    laptopIndex = (i + 1).ToString();
                    break;
                }
            }
            return laptopIndex;
        }

        public IEnumerator GetEnumerator()
        {
            return Laptops.GetEnumerator();
        }
    }
}
