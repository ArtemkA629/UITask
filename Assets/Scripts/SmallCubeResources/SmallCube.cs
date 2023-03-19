using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCube : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField]  CoinResources _coinResources;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnMouseEnter()
    {
        _coinResources.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }

    public void Init(CoinResources coinResources)
    {
        _coinResources = coinResources;
    }

    public void FlipCube()
    {
        System.Random random = new System.Random();
        float randomX = random.Next(-5, 5);
        float randomZ = random.Next(-5, 0);
        Vector3 direction = new Vector3(randomX, 5, randomZ);
        _rigidBody.AddForce(direction);
    }
}
