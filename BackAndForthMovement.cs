using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthMovement : MonoBehaviour
{
    public Transform endPoint;
    public Transform startPoint;
    private Vector3 target;
    private bool canDrive;
    private Rigidbody myRB;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = endPoint.position;
        myRB = GetComponent<Rigidbody>();
        canDrive = true;
    }

    public void setDrive(bool can)
    {
        canDrive = can;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrive)
        {
            if (Equals2(endPoint))
            {
                target = startPoint.position;
            }
            else if (Equals2(startPoint))
            {
                target = endPoint.position;
            }
            myRB.velocity = Vector3.MoveTowards(transform.position, target, speed);
            Debug.Log(myRB.velocity);
        }
    }
    public bool Equals2(Transform t)
    {
        return (Mathf.Abs(transform.position.x - t.position.x) < 0.1f && Mathf.Abs(transform.position.y - t.position.y) < 0.1f && Mathf.Abs(transform.position.z - t.position.z) < 0.1f) ;
    }
}
