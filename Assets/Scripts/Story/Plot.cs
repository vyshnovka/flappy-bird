using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plot", menuName = "ScriptableObjects/Plot")]
public class Plot : ScriptableObject
{
    public List<string> lines;
}
