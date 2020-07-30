using System;
using System.Collections;
using System.Collections.Generic;

class VarFuzzy
{
    private List<TermFuzzy> terms = new List<TermFuzzy>();
    private string _varFuzzyName;
    public string VarFuzzyName { get { return _varFuzzyName; } set { _varFuzzyName = value; } }
    private Dictionary<string, TermFuzzy> termFuzzyDic = new Dictionary<string, TermFuzzy>();
    public VarFuzzy(string nome)
    {
        _varFuzzyName = nome;
    }

    public void AddTerms(string name, List<float> list)
    {
        TermFuzzy newTerm = new TermFuzzy(name, list);
        terms.Add(newTerm);
        termFuzzyDic.Add(name,newTerm);
    }
    public TermFuzzy GetTermFuzzy(string key)
    {
        return termFuzzyDic[key];
    }

    public List<TermFuzzy> GetTerms()
    {
        return terms;
    }

 
}