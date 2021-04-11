using UnityEngine;

public class EnterPortal : MonoBehaviour
{
    [SerializeField] private Mover mover;
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void OnEnable()
    {
        mover.Add(gameObject);
    }

    private void OnDisable()
    {
        mover.Remove(gameObject);
        transform.position = _initialPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            gameObject.SetActive(false);
    }
}
