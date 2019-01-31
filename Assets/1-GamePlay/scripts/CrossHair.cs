
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    private AudioSource mAudioSrc;

    void Start()
    {
        // Hide mouse cursor
        Cursor.visible = false;
        GameController.Instance.GameOverEvent += OnGameOverEvent;
        mAudioSrc = GetComponent<AudioSource>();
    }
    private void OnGameOverEvent(object sender, System.EventArgs e)
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Move crosshair transform to mouse position
        this.transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            mAudioSrc.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
            Debug.Log(Physics.Raycast(ray, out hit));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    GameController.Instance.NewScore();
                    hit.transform.parent.GetComponent<Soldier>().Hit();


                }
            }
        }
    }
}
