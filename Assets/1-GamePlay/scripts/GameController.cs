using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController> {

    protected GameController() { }

    private int mHealth = 100;
    private int mCount = 30;
    private bool mGameOver = false;

    private void Start()
    {
        InvokeRepeating("Count", 0.0f, 1.0f);
    }
    private void Count()
    {
        if(mCount == 0)
        {
            mGameOver = true;
            CancelInvoke("Count");
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
    public int Count
    {
        get { return mCount; }
    }


}
//public int Score
//{
//    get { return mScore; }
//}

//private int mScore = 0;
