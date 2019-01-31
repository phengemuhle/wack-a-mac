using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    
    public Text mTxtHealth;
    public Text mTxtScore;
    public Text mTxtCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        mTxtHealth.text = GameController.Instance.Health.ToString();
        mTxtCount.text = GameController.Instance.Count.ToString();
    }
}
