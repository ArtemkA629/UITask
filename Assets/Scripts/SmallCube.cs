using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCube : MonoBehaviour
{
    [SerializeField] Resources _resources;
    [SerializeField] float _forceValue = 3f;

    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnMouseEnter()
    {
        _resources.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }

    public void Init(Resources coinResources)
    {
        _resources = coinResources;
    }

    public void FlipCube()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(randomX, 5, randomZ);
        _rigidBody.AddForce(direction * _forceValue, ForceMode.VelocityChange);
    }
}
