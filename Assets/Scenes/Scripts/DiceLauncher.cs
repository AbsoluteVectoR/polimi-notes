using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using Random = System.Random;

public class DiceLauncher : MonoBehaviour
{
    public GameObject DiceObj;
    public float RollingRadius = 2f;
    public float RollingSpeedRotation = 0.5f;
    private GameObject Dice1;
    private GameObject Dice2;
    private bool AreRolling = true;
    public bool launch = false;
    public void StartRolling()
    {
        Vector3 ThisPos = this.transform.position;
        Vector3 DicePos = new Vector3(ThisPos.x + RollingRadius, ThisPos.y, ThisPos.z);
        Dice1 = Instantiate( DiceObj,DicePos, Quaternion.identity);
        DicePos = new Vector3(ThisPos.x - RollingRadius, ThisPos.y, ThisPos.z);
        Dice2 = Instantiate(DiceObj,DicePos, Quaternion.identity);
        Dice1.transform.parent = this.transform;
        Dice2.transform.parent = this.transform;
    }

    public void Rolling()
    {
        this.gameObject.transform.Rotate(Vector3.forward, RollingSpeedRotation);
        Dice1.transform.Rotate(Dice1.transform.up, -RollingSpeedRotation);
        Dice2.transform.Rotate(Dice2.transform.up, -RollingSpeedRotation);
        Dice1.transform.Rotate(Dice1.transform.right, RollingSpeedRotation);
        Dice2.transform.Rotate(Dice2.transform.right, RollingSpeedRotation);
    }

    public void Launch()
    {
        Vector3 ForceDirection = (Vector3.up + Vector3.forward) *1000f ;
        Dice1.AddComponent<Rigidbody>();
        Dice2.AddComponent<Rigidbody>();
        Dice1.GetComponent<Rigidbody>().AddForce(ForceDirection);
        Dice2.GetComponent<Rigidbody>().AddForce(ForceDirection);
        Dice1.transform.parent = null;
        Dice2.transform.parent = null;
        AreRolling = false;
        launch = false;
    }

    public void Start()
    {
        StartRolling();
    }

    public void Update()
    {
        if (AreRolling) Rolling();
        if(launch) Launch();
    }
}
