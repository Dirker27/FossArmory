using UnityEngine;
using System.Collections;

public class ScoreCard : MonoBehaviour {
    public int molesKilled = 0;

    public int GetCalculatedScore()
    {
        return molesKilled;
    }
}
