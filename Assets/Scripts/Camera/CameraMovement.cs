using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _deltaX;
    private Transform _player;
    void Start()
    {
        _player = Player.player.transform;
        _deltaX = _player.position.x - transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(_player.position.x - _deltaX, transform.position.y, -10f);
    }
}
