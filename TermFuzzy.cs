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

