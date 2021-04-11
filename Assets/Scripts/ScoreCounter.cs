using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int Score { get; private set; }
    [SerializeField] private float pointsPerSecond;
    [SerializeField] private Text text;
    private float _pointsPerSecondStart;

    private void Start()
    {
        _pointsPerSecondStart = pointsPerSecond;
        text.text = "Score: 0";
        StartCoroutine(CountScore());
        InvokeRepeating(nameof(IncreasePointsPerSecond),5, 5);
    }

    private void Update()
    {
        text.text = $"Score: {Score}";
    }

    private IEnumerator CountScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / pointsPerSecond);
            Score++;
        }
    }

    private void IncreasePointsPerSecond()
    {
        pointsPerSecond += _pointsPerSecondStart * 0.02f;
    }
}
