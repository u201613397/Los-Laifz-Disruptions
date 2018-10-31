using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelButtonControl : MonoBehaviour {

	public int levelValue;
	public Text levelText;
	// Use this for initialization
	void Start () {
		SetInitialValues ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetInitialValues(){
		string tmp = "";
		if (levelValue < 10) {
			tmp = "0";
		}
		levelText.text = tmp + levelValue.ToString ();
	}
}
