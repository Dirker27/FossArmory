using UnityEngine;
using System.Collections;

public class ScorePrinter : MonoBehaviour {
    public ScoreCard scoreCard;
    public UnityEngine.UI.Text textField;
	
	// Update is called once per frame
	void Update () {
        textField.text = scoreCard.GetCalculatedScore().ToString();	
	}
}
