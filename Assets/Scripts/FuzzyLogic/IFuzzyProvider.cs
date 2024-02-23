using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFuzzyProvider
{
    List<string> GoodWords { get; }
    List<string> BadWords { get; }
    float ProvideFuzzyCalculation(List<string> words);
}
