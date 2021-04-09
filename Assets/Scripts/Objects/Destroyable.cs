using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private Mover mover;
    [SerializeField] private Destroyer destroyer;

    void Start()
    {
        mover.Add(gameObject);
        destroyer.Add(gameObject);
    }
}
