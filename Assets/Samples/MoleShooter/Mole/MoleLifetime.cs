using UnityEngine;
using System.Collections;

public class MoleLifetime : MonoBehaviour
{
    public float duration = 5;
    float startTime;

    private ScoreCard scoreCard;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;

        scoreCard = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreCard>();
        if (scoreCard == null)
        {
            Debug.LogError("Cannot find a scorecard - kills will not count!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + duration < Time.time)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        scoreCard.molesKilled++;

        print("Score!");
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }
}