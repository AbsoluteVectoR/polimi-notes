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
    public GameObject dice1;
    public GameObject dice2;
    public GameObject player; 
    public float rollingRadius = 2f;
    public float rollingSpeedRotation = 0.5f;
    public bool turnHasStarted;
    public bool dicesPickedUp;
    public bool launched = false;
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
        dicesPickedUp = false;
        dice1rb = dice1.GetComponent<Rigidbody>();
        dice2rb = dice2.GetComponent<Rigidbody>();
    }
    public void Update()
    {   
        if (dicesPickedUp&&turnHasStarted)
        {
            StartCoroutine(PickUpDices());
            turnHasStarted = false;
        }
        if(isRollingDices)Rolling();
        if (launched) Launch();
    }

    private IEnumerator PickUpDices()
    {
        dicesPickedUp = true;
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
            dice1.transform.position = Vector3.Lerp( dice1rb.position,dice1DestPos,Mathf.Pow(time,3f)/2f);
            dice2.transform.position = Vector3.Lerp( dice2rb.position,dice2DestPos,Mathf.Pow(time,3f)/2f);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //move dices to the launcher position 
        time = 0f;
        this.transform.LookAt(Vector3.zero);
        dice1DestPos = transform.TransformPoint(this.transform.right * rollingRadius);
        dice2DestPos = transform.TransformPoint(-this.transform.right * rollingRadius);
        while (time < 1f) 
        {
            dice1.transform.position = Vector3.Lerp( dice1rb.position,dice1DestPos,Mathf.Pow(time,3f)/5f);
            dice2.transform.position = Vector3.Lerp( dice2rb.position,dice2DestPos,Mathf.Pow(time,3f)/5f);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        isRollingDices = true; //starts to roll the dices
        time = 0f;
    }
    
    private void Rolling()
    {
        dice1rb.position = dice1DestPos;
        dice2rb.position = dice2DestPos;
        dice1rb.AddRelativeTorque(rollingSpeedRotation,rollingSpeedRotation,-rollingSpeedRotation);
        dice2rb.AddRelativeTorque(-rollingSpeedRotation,rollingSpeedRotation,rollingSpeedRotation);
    }
    
    private void Launch()
    {
        isRollingDices = false;
        dicesPickedUp = false;
        launched = false;
        Vector3 forceDirection = new Vector3(-this.transform.position.x,1,-this.transform.position.z).normalized*2000f;
        dice1rb.AddForce(forceDirection);
        dice2rb.AddForce(forceDirection);
        dice1rb.AddRelativeTorque(-rollingSpeedRotation,-rollingSpeedRotation,-rollingSpeedRotation);
        dice2rb.AddRelativeTorque(rollingSpeedRotation,rollingSpeedRotation,rollingSpeedRotation);
        dice1rb.useGravity = true;
        dice2rb.useGravity = true;
        dice1.GetComponent<Dice>().Launched();
        dice2.GetComponent<Dice>().Launched();
        StartCoroutine(MakeSumOfDices());
    }
    
    private IEnumerator MakeSumOfDices()
    {
        while(dice1.GetComponent<Dice>().GetValue() == -1 || dice2.GetComponent<Dice>().GetValue() == -1) yield return new WaitForSeconds(0.1f);
        sum = 0;
        sum = dice1.GetComponent<Dice>().GetValue();
        sum += dice2.GetComponent<Dice>().GetValue();
        player.GetComponent<Player>().setSum(sum);
        dice1.GetComponent<Dice>().ResetValue();
        dice2.GetComponent<Dice>().ResetValue();
    }

    
}
