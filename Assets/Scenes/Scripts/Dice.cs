using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Transform DiceTransf;
    public bool isJustLaunched;
    public Rigidbody thisone;
    public int value;

    public void Start(){ 
        thisone = this.GetComponent<Rigidbody>();
        ResetValue();
        
    }

    public void ResetValue(){value = -1;}
    
    private void UpdateValue()
    {
        DiceTransf = this.GetComponent<Transform>();
        if (Vector3.Dot(DiceTransf.up, Vector3.up) > 0.9f) value = 3;
        else if (Vector3.Dot(-DiceTransf.up, Vector3.up) > 0.9f) value = 4;
        else if  (Vector3.Dot(DiceTransf.forward, Vector3.up) > 0.9f) value = 1;
        else if (Vector3.Dot(-DiceTransf.forward, Vector3.up) > 0.9f) value = 6;
        else if (Vector3.Dot(DiceTransf.right, Vector3.up) > 0.9f) value = 2;
        else if (Vector3.Dot(-DiceTransf.right, Vector3.up) > 0.9f) value = 5;
        else ResetValue();
        isJustLaunched = false;
        thisone.isKinematic = true;
    }
    
    public int GetValue()
    { return value; }

    public void Launched()
    {
        isJustLaunched = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (isJustLaunched)
        {
            if (thisone.velocity.magnitude <= 0.01f)
            {
                UpdateValue();
            }
        }
    } 
    
}
