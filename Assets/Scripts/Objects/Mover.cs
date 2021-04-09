using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : SceneObjectsAction
{
    public void LateUpdate()
    {
        if(objects.Count == 0) return;
        foreach (var o in objects)
            o.transform.Translate(Vector3.left * (10f * Time.deltaTime));
    }

    public void Remove(GameObject obj)
    {
        objects.Remove(obj);
    }
}
