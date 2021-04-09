using UnityEngine;

public class Mover : SceneObjectsAction
{
    [SerializeField] private float startSpeed;
    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = startSpeed;
        InvokeRepeating(nameof(IncreaseSpeed), 5, 5);
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

    private void IncreaseSpeed()
    {
        _currentSpeed += startSpeed * 0.02f;
    }
}
