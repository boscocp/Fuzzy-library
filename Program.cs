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
        /*
        //reader.setFuzzySystem();
        Console.WriteLine("\n \n \n");
       

        //arvore teste  
        Console.WriteLine("\n \n Inicio da arvore\n \n ");
        DecisionTree.Condition sim = new DecisionTree.Condition("sim");
        DecisionTree.Condition nao = new DecisionTree.Condition("nao");
        DecisionTree.Condition tem = new DecisionTree.Condition("tem");
        DecisionTree.Condition nTem = new DecisionTree.Condition("n tem");
        DecisionTree.Condition pouco = new DecisionTree.Condition("pouco");
        DecisionTree.Condition medio = new DecisionTree.Condition("medio");
        DecisionTree.Condition muito = new DecisionTree.Condition("muito");
        DecisionTree.Condition nenhum = new DecisionTree.Condition("nenhum");
        DecisionTree.Condition frances  = new DecisionTree.Condition("frances");
        DecisionTree.Condition thailandes = new DecisionTree.Condition("thailandes");
        DecisionTree.Condition burguer = new DecisionTree.Condition("burguer");
        DecisionTree.Condition italiano = new DecisionTree.Condition("italiano");
        List<DecisionTree.Condition> verdadeFalso = new List<DecisionTree.Condition>();
        List<DecisionTree.Condition> temNTem = new List<DecisionTree.Condition>();
        List<DecisionTree.Condition> quantidade = new List<DecisionTree.Condition>();
        List<DecisionTree.Condition> quantidade2 = new List<DecisionTree.Condition>();
        List<DecisionTree.Condition> tipos = new List<DecisionTree.Condition>();
        verdadeFalso.Add(sim);
        verdadeFalso.Add(nao);
        temNTem.Add(tem);
        temNTem.Add(nTem);
        quantidade.Add(pouco); //10-30
        quantidade.Add(medio); //30-60
        quantidade.Add(muito); //>60
        quantidade.Add(nenhum); //0-10
        quantidade2.Add(pouco);
        quantidade2.Add(medio);
        quantidade2.Add(muito);
        tipos.Add(frances);
        tipos.Add(thailandes);
        tipos.Add(burguer);
        tipos.Add(italiano);
        DecisionTree.Attribute alternativa = new DecisionTree.Attribute("alternativa ",temNTem);
        DecisionTree.Attribute bar = new DecisionTree.Attribute("tem bar ",temNTem);
        DecisionTree.Attribute sexta = new DecisionTree.Attribute("eh sexta ",temNTem);
        DecisionTree.Attribute fome = new DecisionTree.Attribute("tem fome",temNTem);
        DecisionTree.Attribute fregues = new DecisionTree.Attribute("quantidade fregues ",quantidade2);
        DecisionTree.Attribute preco = new DecisionTree.Attribute("preco ",quantidade2);
        DecisionTree.Attribute chuva = new DecisionTree.Attribute("chuva ",temNTem);
        DecisionTree.Attribute reserva = new DecisionTree.Attribute("reserva ",temNTem);
        DecisionTree.Attribute tipo = new DecisionTree.Attribute("tipo ",tipos);
        DecisionTree.Attribute tempoEspera = new DecisionTree.Attribute("tempo ",quantidade);
        DecisionTree.Attribute resultado = new DecisionTree.Attribute("resultado ",verdadeFalso);

        List<DecisionTree.Attribute> atributos_reais = new List<DecisionTree.Attribute>();
        List<DecisionTree.Attribute> atributos_exemplos = new List<DecisionTree.Attribute>();
        List<DecisionTree.Example> exemplos = new List<DecisionTree.Example>();

        atributos_reais.Add(alternativa);
        atributos_reais.Add(bar);
        atributos_reais.Add(sexta);
        atributos_reais.Add(fome);
        atributos_reais.Add(fregues);
        atributos_reais.Add(preco);
        atributos_reais.Add(chuva);
        atributos_reais.Add(reserva);
        atributos_reais.Add(tipo);
        atributos_reais.Add(tempoEspera);

        atributos_exemplos.Add(alternativa);
        atributos_exemplos.Add(bar);
        atributos_exemplos.Add(sexta);
        atributos_exemplos.Add(fome);
        atributos_exemplos.Add(fregues);
        atributos_exemplos.Add(preco);
        atributos_exemplos.Add(chuva);
        atributos_exemplos.Add(reserva);
        atributos_exemplos.Add(tipo);
        atributos_exemplos.Add(tempoEspera);
        atributos_exemplos.Add(resultado);

        //exemplo 1 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo1 = new List<DecisionTree.Condition>();
        decisoes_exemplo1.Add(tem);
        decisoes_exemplo1.Add(nTem);
        decisoes_exemplo1.Add(nTem);
        decisoes_exemplo1.Add(tem);
        decisoes_exemplo1.Add(medio);
        decisoes_exemplo1.Add(muito);
        decisoes_exemplo1.Add(nTem);
        decisoes_exemplo1.Add(tem);
        decisoes_exemplo1.Add(frances);
        decisoes_exemplo1.Add(nenhum);
        decisoes_exemplo1.Add(sim);
        DecisionTree.Example exemplo1 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo1);
        exemplos.Add(exemplo1);
        //exemplo 2 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo2 = new List<DecisionTree.Condition>();
        decisoes_exemplo2.Add(tem);
        decisoes_exemplo2.Add(nTem);
        decisoes_exemplo2.Add(nTem);
        decisoes_exemplo2.Add(tem);
        decisoes_exemplo2.Add(muito);
        decisoes_exemplo2.Add(pouco);
        decisoes_exemplo2.Add(nTem);
        decisoes_exemplo2.Add(nTem);
        decisoes_exemplo2.Add(thailandes);
        decisoes_exemplo2.Add(medio); //30-60
        decisoes_exemplo2.Add(nao);
        DecisionTree.Example exemplo2 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo2);
        exemplos.Add(exemplo2);
        //exemplo 3 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo3 = new List<DecisionTree.Condition>();
        decisoes_exemplo3.Add(nTem);
        decisoes_exemplo3.Add(nTem);
        decisoes_exemplo3.Add(nTem);
        decisoes_exemplo3.Add(nTem);
        decisoes_exemplo3.Add(medio);
        decisoes_exemplo3.Add(pouco);
        decisoes_exemplo3.Add(nTem);
        decisoes_exemplo3.Add(nTem);
        decisoes_exemplo3.Add(burguer);
        decisoes_exemplo3.Add(nenhum);  //0-10
        decisoes_exemplo3.Add(sim);
        DecisionTree.Example exemplo3 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo3);
        exemplos.Add(exemplo3);
        //exemplo 4 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo4 = new List<DecisionTree.Condition>();
        decisoes_exemplo4.Add(tem);
        decisoes_exemplo4.Add(tem);
        decisoes_exemplo4.Add(tem);
        decisoes_exemplo4.Add(tem);
        decisoes_exemplo4.Add(muito);
        decisoes_exemplo4.Add(pouco);
        decisoes_exemplo4.Add(tem);
        decisoes_exemplo4.Add(nTem);
        decisoes_exemplo4.Add(thailandes);
        decisoes_exemplo4.Add(pouco); //10-30
        decisoes_exemplo4.Add(sim);
        DecisionTree.Example exemplo4 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo4);
        exemplos.Add(exemplo4);
        //exemplo 5 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo5 = new List<DecisionTree.Condition>();
        decisoes_exemplo5.Add(tem);
        decisoes_exemplo5.Add(tem);
        decisoes_exemplo5.Add(tem);
        decisoes_exemplo5.Add(nTem);
        decisoes_exemplo5.Add(muito);
        decisoes_exemplo5.Add(muito);
        decisoes_exemplo5.Add(nTem);
        decisoes_exemplo5.Add(tem);
        decisoes_exemplo5.Add(frances);
        decisoes_exemplo5.Add(muito); //10-30
        decisoes_exemplo5.Add(nao);
        DecisionTree.Example exemplo5 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo5);
        exemplos.Add(exemplo5);
        //exemplo 6 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo6 = new List<DecisionTree.Condition>();
        decisoes_exemplo6.Add(nTem);
        decisoes_exemplo6.Add(nTem);
        decisoes_exemplo6.Add(nTem);
        decisoes_exemplo6.Add(tem);
        decisoes_exemplo6.Add(medio);
        decisoes_exemplo6.Add(medio);
        decisoes_exemplo6.Add(tem);
        decisoes_exemplo6.Add(tem);
        decisoes_exemplo6.Add(italiano);
        decisoes_exemplo6.Add(nenhum); //0-10
        decisoes_exemplo6.Add(sim);
        DecisionTree.Example exemplo6 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo6);
        exemplos.Add(exemplo6);
        //exemplo 7 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo7 = new List<DecisionTree.Condition>();
        decisoes_exemplo7.Add(nTem);
        decisoes_exemplo7.Add(nTem);
        decisoes_exemplo7.Add(nTem);
        decisoes_exemplo7.Add(nTem);
        decisoes_exemplo7.Add(pouco);
        decisoes_exemplo7.Add(pouco);
        decisoes_exemplo7.Add(tem);
        decisoes_exemplo7.Add(nTem);
        decisoes_exemplo7.Add(burguer);
        decisoes_exemplo7.Add(nenhum); //0-10
        decisoes_exemplo7.Add(nao);
        DecisionTree.Example exemplo7 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo7);
        exemplos.Add(exemplo7);
        //exemplo 8 chuva, nublado, muito umido, levo guardachuva
        List<DecisionTree.Condition> decisoes_exemplo8 = new List<DecisionTree.Condition>();
        decisoes_exemplo8.Add(nTem);
        decisoes_exemplo8.Add(nTem);
        decisoes_exemplo8.Add(nTem);
        decisoes_exemplo8.Add(tem);
        decisoes_exemplo8.Add(medio);
        decisoes_exemplo8.Add(medio);
        decisoes_exemplo8.Add(tem);
        decisoes_exemplo8.Add(tem);
        decisoes_exemplo8.Add(thailandes);
        decisoes_exemplo8.Add(nenhum); //10-30
        decisoes_exemplo8.Add(sim);
        DecisionTree.Example exemplo8 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo8);
        exemplos.Add(exemplo8);
         List<DecisionTree.Condition> decisoes_exemplo9 = new List<DecisionTree.Condition>();
        decisoes_exemplo9.Add(nTem);
        decisoes_exemplo9.Add(tem);
        decisoes_exemplo9.Add(tem);
        decisoes_exemplo9.Add(nTem);
        decisoes_exemplo9.Add(muito);
        decisoes_exemplo9.Add(pouco);
        decisoes_exemplo9.Add(tem);
        decisoes_exemplo9.Add(nTem);
        decisoes_exemplo9.Add(burguer);
        decisoes_exemplo9.Add(muito); //>60
        decisoes_exemplo9.Add(nao);
        DecisionTree.Example exemplo9 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo9);
        exemplos.Add(exemplo9);
         List<DecisionTree.Condition> decisoes_exemplo10 = new List<DecisionTree.Condition>();
        decisoes_exemplo10.Add(tem);
        decisoes_exemplo10.Add(tem);
        decisoes_exemplo10.Add(tem);
        decisoes_exemplo10.Add(tem);
        decisoes_exemplo10.Add(muito);
        decisoes_exemplo10.Add(muito);
        decisoes_exemplo10.Add(nTem);
        decisoes_exemplo10.Add(tem);
        decisoes_exemplo10.Add(italiano);
        decisoes_exemplo10.Add(pouco); //10-30
        decisoes_exemplo10.Add(sim);
        DecisionTree.Example exemplo10 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo10);
        exemplos.Add(exemplo10);
         List<DecisionTree.Condition> decisoes_exemplo11 = new List<DecisionTree.Condition>();
        decisoes_exemplo11.Add(nTem);
        decisoes_exemplo11.Add(nTem);
        decisoes_exemplo11.Add(nTem);
        decisoes_exemplo11.Add(nTem);
        decisoes_exemplo11.Add(pouco);
        decisoes_exemplo11.Add(pouco);
        decisoes_exemplo11.Add(nTem);
        decisoes_exemplo11.Add(nTem);
        decisoes_exemplo11.Add(thailandes);
        decisoes_exemplo11.Add(nenhum); //0-10
        decisoes_exemplo11.Add(nao);
        DecisionTree.Example exemplo11 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo11);
        exemplos.Add(exemplo11);
        List<DecisionTree.Condition> decisoes_exemplo12 = new List<DecisionTree.Condition>();
        decisoes_exemplo12.Add(tem);
        decisoes_exemplo12.Add(tem);
        decisoes_exemplo12.Add(tem);
        decisoes_exemplo12.Add(tem);
        decisoes_exemplo12.Add(muito);
        decisoes_exemplo12.Add(pouco);
        decisoes_exemplo12.Add(nTem);
        decisoes_exemplo12.Add(nTem);
        decisoes_exemplo12.Add(burguer);
        decisoes_exemplo12.Add(medio); //30-60
        decisoes_exemplo12.Add(sim);
        DecisionTree.Example exemplo12 = new DecisionTree.Example(atributos_exemplos,decisoes_exemplo12);
        exemplos.Add(exemplo12);

        //teste
        List<DecisionTree.Condition> decisoes_teste = new List<DecisionTree.Condition>();
        decisoes_teste.Add(tem);
        decisoes_teste.Add(nTem);
        decisoes_teste.Add(tem);
        decisoes_teste.Add(tem);
        decisoes_teste.Add(pouco);
        decisoes_teste.Add(pouco);
        decisoes_teste.Add(nTem);
        decisoes_teste.Add(nTem);
        decisoes_teste.Add(burguer);
        decisoes_teste.Add(medio); //30-60
        //decisoes_teste.Add(sim);
        DecisionTree.Example teste = new DecisionTree.Example(atributos_exemplos,decisoes_teste);
        //exemplos.Add(exemplo12);

        DecisionTree.Node arvore = null; 
        DecisionTree.DecisionTree treinamento = new DecisionTree.DecisionTree();
        //(List<Example> examples, List<Attribute> attributes_exemplos, List<Attribute> attributes_reais, Condition defalt_label)
        arvore = treinamento.BuildTree(exemplos,atributos_reais,exemplos);

        
        //Console.WriteLine(arvore.PrintNode(""));
        //arvore.Evaluate(exemplo1);
        
      */
    }
}
