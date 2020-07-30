using System;
using System.Collections;
using System.Collections.Generic;

class Program
{

    static void Main(string[] args)
    {
        FuzzyReader reader = new FuzzyReader("FLC.txt");
        ControleFuzzy teste1 = reader.setFuzzySystem();

        Console.WriteLine("Input life");
        teste1.Fuzzification(teste1.GetVarFuzzy("life"), 30.1f);
        Console.WriteLine("Input damage");
        teste1.Fuzzification(teste1.GetVarFuzzy("damage"), 30.1f);
        Console.WriteLine("Input tempo");
        teste1.Fuzzification(teste1.GetVarFuzzy("time"), 30f);

        teste1.FuzzyInference();
        teste1.GetDefuzzification();
        
    }
}
