using System;
using System.Collections;
using System.Collections.Generic;

class RuleFuzzy
{
    private List <TermFuzzy> varFuzzyList=  new List<TermFuzzy>();
    private List <string> operators=  new List<string>();
    private TermFuzzy activator = new TermFuzzy("n",null);

    public RuleFuzzy(List <TermFuzzy> varFuzzyListNew,List <string> ruleOperators)
    {
        varFuzzyList = varFuzzyListNew;
        operators = ruleOperators;
    }
    public void SetActivatorTerm(TermFuzzy term)
    {
        activator = term;
    }

    public TermFuzzy GetActivatorTerm()
    {
        return activator;
    }

    public void SetActivatorPertinence(float value)
    {
        activator.SetPertinence(value);
    }

    public float GetActivatorPertinece()
    {
        return activator.GetPertinence();
    }

    public List <TermFuzzy> GetVarFuzzyList()
    {
        return varFuzzyList;
    }

    public List <string> GetOperators()
    {
        return operators;
    }


}