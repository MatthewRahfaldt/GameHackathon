using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public float range;
    private Rigidbody myRB;
    public GameObject cam;
    private float multiplier;
    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody>();
        difference = cam.transform.localPosition.z;
        multiplier = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float valu = cam.transform.localPosition.z - difference;
        if (valu <= -range)
        {
            valu = -range;
        }
        else if (valu >= range)
        {
            valu = range;
        }
        //multiplier should start at 1 and go from 0.5 to 3

        if (valu < 0)
            multiplier = 1 + (valu * (0.5f / range));
        else if (valu > 0)
            multiplier = 1 + (valu * (2.0f / range));
        else
            multiplier = 1;

        myRB.velocity = new Vector3(0f, 0f, multiplier * speed);
        Debug.Log("value: " + valu);
        Debug.Log("Multiplier: " + multiplier);
        Debug.Log("Speed: " + (multiplier * speed));
        
        
    }
}
