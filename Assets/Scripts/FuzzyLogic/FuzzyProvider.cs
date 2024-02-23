using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyProvider : MonoBehaviour, IFuzzyProvider
{

    public List<string> GoodWords => _goodWords;
    public List<string> BadWords => _badWords;
    
    [Header("Properties")]
    [Space]
    [SerializeField] private List<string> _goodWords = new List<string>();
    [SerializeField] private List<string> _badWords = new List<string>();

    public float ProvideFuzzyCalculation(List<string> words)
    {
        float score = 0;
        foreach(string word in words)
        {
            if(_goodWords.Contains(word))
            {
                score += 1;
            }
            else if(_badWords.Contains(word))
            {
                score += 0;
            }else
            {
                score += 0.5f;
            }
        }
        return 100.0f / 3 * score;
    }
}
