using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneObjectsAction : MonoBehaviour
{
    protected List<GameObject> objects = new List<GameObject>();

    public void Add(params GameObject[] objs)
    {
        foreach (var obj in objs)
            objects.Add(obj);
    }
}
