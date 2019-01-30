using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Soldier[] Enemies;


    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        // Check if a solidier is currently active
        foreach (Soldier enemy in Enemies)
        {
            if (enemy.IsActive)
                return;
        }

        int soldier = Random.Range(0, Enemies.Length);
        Enemies[soldier].Activate();
    }
}
