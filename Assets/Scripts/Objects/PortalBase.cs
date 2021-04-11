using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PortalBase : MonoBehaviour
{
    [SerializeField] protected Mover mover;
    private Vector3 _initialPosition;

    protected void Start()
    {
        Debug.Log($"Base start {gameObject.name}");
        _initialPosition = transform.position;
        gameObject.SetActive(false);
    }

    protected void OnEnable()
    {
        Debug.Log($"Base OnEnable {gameObject.name}");
        mover.Add(gameObject);
    }

    protected void OnDisable()
    {
        Debug.Log($"Base OnDisable {gameObject.name}");
        mover.Remove(gameObject);
        transform.position = _initialPosition;
    }
}
