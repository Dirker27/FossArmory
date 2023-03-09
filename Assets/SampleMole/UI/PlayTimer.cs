using UnityEngine;
using System.Collections;

public class PlayTimer : MonoBehaviour {

    public double startTime = 0.0d;
    private double currentTime = 0.0d;

    public UnityEngine.UI.Text textField;

	// Use this for initialization
	void Start () {
        currentTime = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        textField.text = currentTime.ToString("0.###");
	}
}
