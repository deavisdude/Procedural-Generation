using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {
	public Text clock;
	public Text popCounter;
	private ClockScript.Clock gameClock;

	public void UpdatePop(int count){
		popCounter.text = "Population: " + Censuscript.population;
	}

	// Use this for initialization
	void Start () {
		gameClock = new ClockScript.Clock (0.001f);
	}
	
	// Update is called once per frame
	void Update () {
		int[] timeData = gameClock.GetTime ();
		string season = "ERR";
		float fract = 365 / 4;
		float s = timeData [3] / fract;
		if (s < 1)
			season = "Winter";
		if (s > 1 && s < 2)
			season = "Spring";
		if (s > 2 && s < 3)
			season = "Summer";
		if (s > 3 && s < 4)
			season = "Fall";
		clock.text = season + " Year " + timeData [4];
	}
}
