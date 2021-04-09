using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Destroyer : SceneObjectsAction
{
    private Mover _mover;
    private Transform _player;
    private const float DistanceToBeDestroyed = 23f;

    private void Start()
    {
        _player = Player.player.transform;
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if(objects.Count == 0) return;
        List<GameObject> toBeDeleted = new List<GameObject>();
        
        foreach (var t in objects)
            if (_player.position.x - t.transform.position.x > DistanceToBeDestroyed)
                toBeDeleted.Add(t);
        
        foreach (var obj in toBeDeleted)
        {
            _mover.Remove(obj);
            objects.Remove(obj);
            Destroy(obj.gameObject);
        }
        
    }
}
