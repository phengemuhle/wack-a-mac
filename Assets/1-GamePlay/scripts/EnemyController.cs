using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Soldier[] Enemies;

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.IsGameOver)
            return;

        foreach (Soldier enemy in Enemies)
        {
            if (enemy.IsActive)
                return;
        }
        int soldier = Random.Range(0, Enemies.Length-1);
        Enemies[soldier].Activate();

    }
}
