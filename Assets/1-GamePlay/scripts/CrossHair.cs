
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    //private Ray ray;
    // Use this for initialization
    void Start()
    {
        // Hide mouse cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Move crosshair transform to mouse position
        this.transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
            Debug.Log(Physics.Raycast(ray, out hit));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.parent.GetComponent<Soldier>().Hit();

                }
            }
        }
    }
}
