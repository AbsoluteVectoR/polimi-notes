using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TreeEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class DiceLauncher : MonoBehaviour
{
    public static DiceLauncher instance;
    public GameObject Dice1;
    public GameObject Dice2;
    public float RollingRadius = 2f;
    public float RollingSpeedRotation = 0.5f;
    public bool TurnHasStarted;
    public bool DicesPickedUp;
    public bool launch = false;
    public int sum;
    private Rigidbody dice1rb;
    private Rigidbody dice2rb;
    private Vector3 thisTransf;
    private Vector3  dice1DestPos;
    private Vector3 dice2DestPos;
    private bool isRollingDices;
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        isRollingDices = false;
        DicesPickedUp = false;
        dice1rb = Dice1.GetComponent<Rigidbody>();
        dice2rb = Dice2.GetComponent<Rigidbody>();
    }
    public void Update()
    {   
        if (DicesPickedUp&&TurnHasStarted)
        {
            StartCoroutine(PickUpDices());
            TurnHasStarted = false;
        }
        if(isRollingDices)Rolling();
        if (launch) Launch();
    }
    private void Rolling()
    {
        dice1rb.position = dice1DestPos;
        dice2rb.position = dice2DestPos;
        dice1rb.AddRelativeTorque(RollingSpeedRotation,RollingSpeedRotation,-RollingSpeedRotation);
        dice2rb.AddRelativeTorque(-RollingSpeedRotation,RollingSpeedRotation,RollingSpeedRotation);
    }

    private IEnumerator PickUpDices()
    {
        DicesPickedUp = true;
        dice1rb.useGravity = false;
        dice2rb.useGravity = false;
        dice1rb.isKinematic = false;
        dice2rb.isKinematic = false;
        thisTransf = this.transform.position;
        //pick up dices
        float time = 0f;
        dice1DestPos = new Vector3(dice1rb.position.x,thisTransf.y,dice1rb.position.z);
        dice2DestPos = new Vector3(dice2rb.position.x,thisTransf.y,dice2rb.position.z);
        while (time < 1f) 
        {
            Dice1.transform.position = Vector3.Lerp( dice1rb.position,dice1DestPos,Mathf.Pow(time,3f)/2f);
            Dice2.transform.position = Vector3.Lerp( dice2rb.position,dice2DestPos,Mathf.Pow(time,3f)/2f);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //move dices to the launcher position 
        time = 0f;
        this.transform.LookAt(Vector3.zero);
        dice1DestPos = transform.TransformPoint(this.transform.right * RollingRadius);
        dice2DestPos = transform.TransformPoint(-this.transform.right * RollingRadius);
        while (time < 1f) 
        {
            Dice1.transform.position = Vector3.Lerp( dice1rb.position,dice1DestPos,Mathf.Pow(time,3f)/5f);
            Dice2.transform.position = Vector3.Lerp( dice2rb.position,dice2DestPos,Mathf.Pow(time,3f)/5f);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isRollingDices = true; //starts to roll the dices
        time = 0f;
    }
    private void Launch()
    {
        isRollingDices = false;
        DicesPickedUp = false;
        launch = false;
        Vector3 ForceDirection = new Vector3(-this.transform.position.x,1,-this.transform.position.z).normalized*2000f;
        dice1rb.AddForce(ForceDirection);
        dice2rb.AddForce(ForceDirection);
        dice1rb.AddRelativeTorque(-RollingSpeedRotation,-RollingSpeedRotation,-RollingSpeedRotation);
        dice2rb.AddRelativeTorque(RollingSpeedRotation,RollingSpeedRotation,RollingSpeedRotation);
        dice1rb.useGravity = true;
        dice2rb.useGravity = true;
        Dice1.GetComponent<Dice>().Launched();
        Dice2.GetComponent<Dice>().Launched();
        StartCoroutine(MakeSumOfDices());
    }
    
    private IEnumerator MakeSumOfDices()
    {
        while(Dice1.GetComponent<Dice>().GetValue() == -1 || Dice2.GetComponent<Dice>().GetValue() == -1) yield return new WaitForSeconds(0.1f);
        sum = 0;
        sum += Dice1.GetComponent<Dice>().GetValue();
        sum += Dice2.GetComponent<Dice>().GetValue();
        Dice1.GetComponent<Dice>().ResetValue();
        Dice2.GetComponent<Dice>().ResetValue();
    }

    
}
