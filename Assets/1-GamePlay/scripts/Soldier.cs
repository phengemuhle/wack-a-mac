using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    private GameObject mEnemy;

    public float UpTime = 3.0f;

    public float ShootTime = 2.0f;

    public float DownTime = 2.0f;

    private bool mIsActive = false;

    private Animator mAnimator = null;

    Vector3 mStartPos = Vector3.zero;

    // Use this for initialization
    void Awake()
    {
        mEnemy = transform.GetChild(0).gameObject;

        mStartPos = mEnemy.transform.position;

        mAnimator = mEnemy.GetComponent<Animator>();

    }

    public void Activate()
    {
        mIsActive = true;

        mEnemy.transform.position = mStartPos;

        MoveUpwards();

        mAnimator.SetBool("shoot", true);

        Invoke("MoveDownwards", ShootTime);
    }

    private void MoveUpwards()
    {
        // Move upwards
        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.y += 5.0f;

        iTween.MoveTo(mEnemy, enemyPos, UpTime);
    }

    private void MoveDownwards()
    {

        mAnimator.SetBool("shoot", false);

        Vector3 enemyPos = mEnemy.transform.position;
        enemyPos.y -= 5.0f;

        iTween.MoveTo(mEnemy, enemyPos, DownTime);

        iTween.MoveTo(mEnemy, iTween.Hash("y", enemyPos.y, "time", DownTime,
            "onComplete", "OnDownComplete", "onCompleteTarget", gameObject));

    }

    internal void Hit()
    {
        mAnimator.SetTrigger("Die");

        Invoke("MoveDownwards", 0.5f);
    }

    void OnDownComplete()
    {
        mIsActive = false;
    }

    public bool IsActive
    {
        get { return mIsActive; }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
