using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class FuzzyReader
{
    private ControleFuzzy controleFuzzy;
    private string _path;
    public FuzzyReader(string path){
        _path = path;
    }

    enum Steps
    {
        NONE,
        INPUT,
        OUTPUT,
        FUZZIFY,
        DEFUZZIFY,
        RULEBLOCK
    }
   
    public ControleFuzzy setFuzzySystem()
    {
        Steps step = Steps.NONE;
        Console.WriteLine("teste ok");
        controleFuzzy = new ControleFuzzy("teste");
        int cont = -1;
        
        using (StreamReader file = new StreamReader(_path))
        {
            while (file.Peek()>=0)
            {
                
                string line;
                string[] lineArray;
                line = file.ReadLine();
                
                if(line.ToUpper() == "VAR_INPUT")
                {
                    step = Steps.INPUT;
                    line = file.ReadLine();
                    Console.WriteLine("input ok: "+step);
                    
                }else if(line.ToUpper() == "VAR_OUTPUT")
                {
                    step = Steps.OUTPUT;
                    line = file.ReadLine();
                    Console.WriteLine("output ok: "+step);
                }else if(line.ToUpper() == "END"){
                    step = Steps.NONE;
                    Console.WriteLine("END");
                }else if(line.ToUpper() == "RULEBLOCK"){
                    step = Steps.RULEBLOCK;
                    Console.WriteLine("RULEBLOCK");
                    line = file.ReadLine();
                }else{
                    lineArray = line.Split(' ');
                    if(lineArray[0].Trim() == "FUZZIFY"){
                        step = Steps.FUZZIFY;
                        line = file.ReadLine();
                        cont++;
                        Console.WriteLine("step "+lineArray[0].Trim()+" cont "+cont);
                    }else if (lineArray[0].Trim() == "DEFUZZIFY"){
                        step = Steps.FUZZIFY;
                        line = file.ReadLine();
                        cont++;
                        Console.WriteLine("step "+lineArray[0].Trim()+" cont "+cont);
                    }
                }
                
                switch(step)
                {
                    case Steps.INPUT:
                        Console.WriteLine("add var fuzzy "+line.Trim());
                        controleFuzzy.AddVarFuzzy(line.Trim());
                        break;
                    case Steps.OUTPUT:
                        Console.WriteLine(controleFuzzy.GetVarFuzzyList().Count+" add output var fuzzy "+line.Trim());
                        controleFuzzy.AddVarFuzzy(line.Trim());
                        break;
                    case Steps.FUZZIFY:
                        List<float> auxList = new List<float>();
                        Console.WriteLine("numero de var fuzzy "+controleFuzzy.GetVarFuzzyList().Count);
                        Console.WriteLine("fuzzify "+line.Trim());
                        string[] fuzzifyArray = line.Split('=');
                        fuzzifyArray[0] = fuzzifyArray[0].Trim();
                        fuzzifyArray[1] = fuzzifyArray[1].Trim();
                        string[] fuzziArrayNumbers = fuzzifyArray[1].Split(',');
                        foreach(string str in fuzziArrayNumbers)
                        {
                            auxList.Add(float.Parse(str));
                            Console.WriteLine("var "+fuzzifyArray[0]+" number: "+str);
                        }
                        controleFuzzy.GetVarFuzzyList()[cont].AddTerms(fuzzifyArray[0],auxList);
                        break;
                    case Steps.DEFUZZIFY:
                        //implementar depois, por enquanto ta fazendo igual o fuzzify
                        break;
                    case Steps.RULEBLOCK:
                        List<TermFuzzy> rulesTermsList = new List<TermFuzzy>();
                        List<string> rulesOperatorsList = new List<string>();
                        string[] separators = {"IS","THEN","IF"," "};
                        string[] fuzziRule = line.Split('=');
                        string[] ruleTerms = fuzziRule[1].Split(' ');
                        int contador =0;
                        foreach(string str in ruleTerms)
                        {
                            if(str=="IF")
                            {
                                try
                                {
                                    rulesTermsList.Add(controleFuzzy.GetVarFuzzy(ruleTerms[contador+1]).GetTermFuzzy(ruleTerms[contador+3]));
                                    Console.WriteLine("var fuzzy = "+ruleTerms[contador+1]+" term fuzzy: "+ruleTerms[contador+3]);
                                }catch (KeyNotFoundException)
                                {
                                    Console.WriteLine("Key = "+str+" is not found.");
                                }
                                Console.WriteLine(str);
                            }else if(str == "AND" || str == "OR"){
                                try
                                {
                                    rulesOperatorsList.Add(str);
                                    Console.WriteLine("operator = "+str);
                                }catch (KeyNotFoundException)
                                {
                                    Console.WriteLine("Key = "+str+" is not found.");
                                }

                                try
                                {
                                    rulesTermsList.Add(controleFuzzy.GetVarFuzzy(ruleTerms[contador+1]).GetTermFuzzy(ruleTerms[contador+3]));
                                    Console.WriteLine("var fuzzy = "+ruleTerms[contador+1]+" term fuzzy: "+ruleTerms[contador+3]);
                                }catch (KeyNotFoundException)
                                {
                                    Console.WriteLine("Key = "+str+" is not found.");
                                }
                            }else if(str == "THEN"){
                                RuleFuzzy rule = new RuleFuzzy(rulesTermsList, rulesOperatorsList);
                                rule.SetActivatorTerm(controleFuzzy.GetVarFuzzy(ruleTerms[contador+1]).GetTermFuzzy(ruleTerms[contador+3]));
                                controleFuzzy.AddRuleFuzzy(rule);
                                Console.WriteLine("Then var fuzzy = "+ruleTerms[contador+1]+" term fuzzy: "+ruleTerms[contador+3]);
                            }
                             //+controleFuzzy.GetVarFuzzy("life").VarFuzzyName
                            contador++;
                        }
                        break;
                    default:
                        Console.WriteLine("The state is unknown.");
                        break;
                }
                
            }

            file.Close();
        }
        return controleFuzzy;
    }

   

}
