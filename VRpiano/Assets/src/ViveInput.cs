using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using Valve.VR;

public class ViveInput : MonoBehaviour
{

    public SteamVR_Action_Boolean relocateAction;
    public GameObject leftHand;

    void Update()
    {
        
        if(relocateAction.stateDown)
        {
            transform.position = new Vector3(leftHand.transform.position.x+0.14F, leftHand.transform.position.y+0.01F, leftHand.transform.position.z);
            print("relocate");
        }
    }
}
