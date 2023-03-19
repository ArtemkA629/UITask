using System;
using System.Collections;
using UnityEngine;

public class SmallCubeResources : MonoBehaviour
{
    public event Action OnDropSmallCubes;

    public void DropBoxes()
    {
        OnDropSmallCubes?.Invoke();
    }
}

