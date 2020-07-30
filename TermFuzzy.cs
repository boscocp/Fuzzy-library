using System;
using System.Collections;
using System.Collections.Generic;

class TermFuzzy
{
    private List<float> values = new List<float>();
    private float pertinence ;
    private TypeFunction typeFunction;
    private string name;

    public TermFuzzy(string name, List<float> values)
    {
        this.name = name;
        this.values = values;
        this.pertinence = 0f;
    }

    public void SetPertinence(float value)
    {
        pertinence = value;
    }

    public float GetPertinence()
    {
        return pertinence;
    }

    public List<float> GetListOfValues()
    {
        return values;
    }
    public string GetName(){
        return name;
    }

}

enum TypeFunction
{
    Triangular,
    Trapezoidal,
    Gaussian
}

/*
using System;
using System.Collections;
using System.Collections.Generic;

class VarFuzzy
{
    private TermFuzzy term = new TermFuzzy();
    private string varFuzzy;
    public VarFuzzy(string nome)
    {
        varFuzzy = nome;
    }

    public void AddTerms(string name, List<float> list)
    {
        TermFuzzy newTerm = new TermFuzzy(name, list);
        term.Add(name,list);
    }

    public IDictionary GettermDefFunction()
    {
        return termDefFunction;
    }
}

##################################

using System;
using System.Collections;
using System.Collections.Generic;

class VarFuzzy
{
    public IDictionary termDefFunction = new Dictionary<string, List<float>>();
    private string varFuzzy;
    public VarFuzzy(string nome)
    {
        varFuzzy = nome;
    }

    public void AddTerms(string name, List<float> list)
    {
        termDefFunction.Add(name,list);
    }

    public IDictionary GettermDefFunction()
    {
        return termDefFunction;
    }
}

###################
public List<float> Fuzzification(VarFuzzy nome, float sensor)
    {
        
        foreach (DictionaryEntry element in nome.GettermDefFunction())
        {
            //Console.WriteLine("Key = {0}, Value = {1}",  element.Key, element.Value);
            //programar as condicoes de triangulo
            if(element.Value.Count==3) // se tem 3 eh pq eh triangulo
            {   //subida do triangulo
                if(sensor >= element.Value[0] && sensor<element.Value[1])  
                    return (sensor - element.Value[0]) / (element.Value[1] - element.Value[0]);
                //descida do triangulo
                if(sensor >= element.Value[1] && sensor<=element.Value[2])  
                    return (element.Value[2] - sensor) / (element.Value[2] - element.Value[1]);
            }else if (element.Value.Count==4) // se tem 4 eh pq eh trapezio
            {   //subida do trapezio
                if(sensor >= element.Value[0] && sensor<element.Value[1])  
                    return (sensor - element.Value[0]) / (element.Value[1] - element.Value[0]);
                if(sensor >= element.Value[1] && sensor<element.Value[2]) return 1f;
                //descida do trapezio
                if(sensor >= element.Value[2] && sensor<=element.Value[3])  
                    return (element.Value[3] - sensor) / (element.Value[3] - element.Value[2]);
            }else
            {
                return null;
            }
            //programar as condicoes de trapezio
        }

        return null;
    }
*/