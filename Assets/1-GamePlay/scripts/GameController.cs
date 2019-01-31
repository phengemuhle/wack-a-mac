using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

    protected GameController() { }

    private int mHealth = 100;
    private int mTime = 30;
    private bool mGameOver = false;
    private int mScore = 0;

    public event EventHandler GameOverEvent;

    private void OnGameOver()
    {
        if(GameOverEvent != null)
        {
            GameOverEvent(this, EventArgs.Empty);
        }
    }


    private void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
    }
    private void Count()
    {
        if(mTime == 0)
        {
            mGameOver = true;
            CancelInvoke("Count");
            OnGameOver();
        }
        else
        {
            mTime--;
        }
    }

    public void SetDamage(int damage)
    {
        if (mGameOver)
        {
            return;
        }
        mHealth -= damage;

        if(mHealth <= 0)
        {
            mHealth = 0;
            mGameOver = true;
            CancelInvoke("Count");
            OnGameOver();

        }
    }

    public bool IsWon
    {
        get
        {
            if (Health <= 0)
                return false;
            return true;
        }
    }

    public bool IsGameOver
    {
        get { return mGameOver; }
    }

    public int GetHealth()
    {
        return mHealth;
    }

    public int Health
    {
        get { return mHealth; }
    }
    public int Time
    {
        get { return mTime; }
    }
    public int Score
    {
        get { return mScore; }
    }
    public void NewScore()
    {
        mScore += 50;
    }


}
