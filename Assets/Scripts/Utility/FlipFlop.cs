using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlop : MonoBehaviour
{
    public GameObject[] True;
    public GameObject[] False;

    public bool Toggle;

    public void Update()
    {
        foreach (var go in True)
        {
            go.SetActive(Toggle);
        }
        foreach (var go in False)
        {
            go.SetActive(!Toggle);
        }
    }
}