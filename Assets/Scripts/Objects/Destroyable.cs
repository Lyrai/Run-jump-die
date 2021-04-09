using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private const float DistanceToBeDestroyed = 22f;
    private Transform _player;

    void Start()
    {
        _player = Player.player.transform;
    }

    void Update()
    {
        if(_player.position.x - transform.position.x > DistanceToBeDestroyed)
            Destroy(gameObject);
    }
}
