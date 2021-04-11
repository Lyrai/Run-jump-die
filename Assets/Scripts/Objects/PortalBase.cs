using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PortalBase : MonoBehaviour
{
    [SerializeField] protected Mover mover;
    private Vector3 _initialPosition;

    protected virtual void Start()
    {
        _initialPosition = transform.position;
        gameObject.SetActive(false);
    }

    protected virtual void OnEnable()
    {
        mover.Add(gameObject);
    }

    protected virtual void OnDisable()
    {
        mover.Remove(gameObject);
        transform.position = _initialPosition;
    }
}
