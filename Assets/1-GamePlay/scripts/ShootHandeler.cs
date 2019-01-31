using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandeler : MonoBehaviour {
    private AudioSource mAudioSrc;

    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();

    }


    public void ShootEvent()
    {
        int doShoot = Random.Range(0, 2);

        if(doShoot > 0)
        {
            mAudioSrc.Play();
            int damage = Random.Range(4, 15);
            GameController.Instance.SetDamage(damage);
        }
    }
}
