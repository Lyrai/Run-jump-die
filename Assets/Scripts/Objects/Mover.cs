using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Mover : SceneObjectsAction
{
    [SerializeField] private float startSpeed;
    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = startSpeed;
        StartCoroutine(IncreaseSpeed());
    }

    public void LateUpdate()
    {
        if(objects.Count == 0) return;
        foreach (var o in objects)
            o.transform.Translate(Vector3.left * (_currentSpeed * Time.deltaTime));
    }

    public void Remove(GameObject obj)
    {
        objects.Remove(obj);
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            _currentSpeed += startSpeed * 0.02f;
            Debug.Log("increasing");
        }
    }
}
