using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCubeCreator : MonoBehaviour
{
    [SerializeField] private SmallCube _smallCubePrefab;
    [SerializeField] private SmallCubeResources _smallCubeResources;
    [SerializeField] private CoinResources _coinResources;

    private void OnEnable()
    {
        _smallCubeResources.OnDropSmallCubes += CreateSmallCube;
    }

    private void OnDisable()
    {
        _smallCubeResources.OnDropSmallCubes -= CreateSmallCube;
    }

    public void CreateSmallCube()
    {
        SmallCube newSmallCube = Instantiate(_smallCubePrefab);
        newSmallCube.Init(_coinResources);
        newSmallCube.FlipCube();
    }
}
