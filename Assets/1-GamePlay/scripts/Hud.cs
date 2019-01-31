﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    
    public Text mTxtHealth;
    public Text mTxtScore;
    public Text mTxtTime;
    public RectTransform mPanelGameOver;
    public Text mTxtGameOver;

	// Use this for initialization
	void Start () {
        GameController.Instance.GameOverEvent += OnGameOverEvent;
	}
    private void OnGameOverEvent(object sender, System.EventArgs e)
    {
        mPanelGameOver.gameObject.SetActive(true);
        mTxtGameOver.text = GameController.Instance.IsWon ? "YOU WIN!" : "YOU LOSE!";
    }

    // Update is called once per frame
    void Update () {
        mTxtScore.text = GameController.Instance.Score.ToString();
        mTxtHealth.text = GameController.Instance.Health.ToString();
        mTxtTime.text = GameController.Instance.Time.ToString();
    }
}
