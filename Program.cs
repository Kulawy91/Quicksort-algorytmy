using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Tuple<string, string>> dane = new List<Tuple<string, string>>
        {
            Tuple.Create("Paweł", "Zwada"),
            Tuple.Create("Jan", "Kowalski"),
            Tuple.Create("Anna", "Nowak"),
            Tuple.Create("Piotr", "Kowalski")
           
        };

        Console.WriteLine("Przed sortowaniem:");
        foreach (var element in dane)
        {
            Console.WriteLine(element.Item1 + " " + element.Item2);
        }

        dane = QuickSort(dane, 0, dane.Count - 1);

        Console.WriteLine("\nPo sortowaniu:");
        foreach (var element in dane)
        {
            Console.WriteLine(element.Item1 + " " + element.Item2);
        }
    }

    public static List<Tuple<string, string>> QuickSort(List<Tuple<string, string>> dane, int lewa, int prawa)
    {
        int i = lewa, j = prawa;
        var pivot = dane[(lewa + prawa) / 2];

        while (i <= j)
        {
            while (Porownaj(dane[i], pivot) > 0)
            {
                i++;
            }

            while (Porownaj(dane[j], pivot) < 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Zamiana miejscami
                var tmp = dane[i];
                dane[i] = dane[j];
                dane[j] = tmp;

                i++;
                j--;
            }
        }

        // Wywołania rekurencyjne
        if (lewa < j)
        {
            QuickSort(dane, lewa, j);
        }

        if (i < prawa)
        {
            QuickSort(dane, i, prawa);
        }

        return dane;
    }

    public static int Porownaj(Tuple<string, string> x, Tuple<string, string> y)
    {
        int wynik = y.Item2.CompareTo(x.Item2);
        if (wynik == 0)
        {
            wynik = y.Item1.CompareTo(x.Item1);
        }

        return wynik;
    }
}
