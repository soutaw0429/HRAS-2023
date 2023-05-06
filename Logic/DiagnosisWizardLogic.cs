using System;

public class DiagnosisWizardLogic
{
    public string FindSymptomNameNearFiftyPercent(Dictionary<string, int> dictionary)
    {
        SortSymptomsByFrequencyDescendingOrder(dictionary);
        if (sortedDict.Count % 2 == 0)
        {
            Dictionary<string, int> result = sortedDict.ElementAt(sortedDict.Count / 2);
            return result.Key;
        }
        else
        {
            Dictionary<string, int> result = sortedDict.ElementAt(Math.Floor(sortedDict.Count / 2) + 1);
            return result.Key;
        }
    }

    public void SortSymptomsByFrequencyDescendingOrder(Dictionary<string, int> dictionary)
    {
        dictionary = from entry in dictionary orderby entry.Value descending select entry;
    }

    public Dictionary<string, int> GetDiagnosisResults(Dictionary<string, int> dictionary)
    {
        SortSymptomsByFrequencyDescendingOrder(dictionary);
        return dictionary.ToDictionary(pair => pair.Key, pair => pair.Value).Take(5);
    }
}
