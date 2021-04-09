using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rigidbody;
    private void Awake()
    {
        player = this;
    }

    private void Update()
    {
        rigidbody.velocity = Vector2.right * speed;
    }
}
