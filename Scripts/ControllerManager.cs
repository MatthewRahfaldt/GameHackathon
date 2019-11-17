using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;


public class ControllerManager : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grab;

    public GameObject collide;
    public GameObject inHand;

    void Update()
    {


        if (grab.GetLastStateDown(handType))
        {
            if (collide)
            {
                grabObject();
            }
        }
        if (grab.GetLastStateUp(handType))
        {
            if (inHand)
            {
                releaseObject();
            }
        }
    }

    //checking for ridgidbodies
    void OnTriggerEnter(Collider x)
    {
        if (!x.GetComponent<Rigidbody>())
        {
            return;
        }
        collide = x.gameObject;
    }

    //colliding object gets set to null because there is nothing in the hand
    void OnTriggerExit(Collider x)
    {
        if (!collide)
        {
            return;
        }
        collide = null;
    }

    //assigns inHand and adds joint to a grabbed object
    private void grabObject()
    {
        inHand = collide;
        var joint = AddFixedJoint();
        joint.connectedBody = inHand.GetComponent<Rigidbody>();
    }

    //method to add fixed joint
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    //removes inHand and nullifies player effect on previously grabbed object
    private void releaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
        }
        inHand = null;
    }

}