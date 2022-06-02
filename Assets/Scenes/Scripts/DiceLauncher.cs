using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TreeEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class DiceLauncher : MonoBehaviour
{
    public GameObject dice1;
    public GameObject dice2;
    public float rollingRadius = 2f;
    public float rollingSpeedRotation = 0.5f;
    public int sum;
    public GameManager _gameMan;
    private Rigidbody _dice1Rb;
    private Rigidbody _dice2Rb;
    private Vector3  _dice1DestPos;
    private Vector3 _dice2DestPos;
    private bool _isRollingDices;
   
    public void Start()
    {
        _gameMan = this.GetComponent<GameManager>(); 
        _isRollingDices = false;
    }
    
    public IEnumerator turnStart(float waitingTimeBeforePickUp)
    {
        yield return new WaitForSeconds(waitingTimeBeforePickUp);
        StartCoroutine(PickUpDices());
    }
    
    public void Update()
    {
        if(_isRollingDices)Rolling();
    }

    private IEnumerator PickUpDices()
    {
        _dice1Rb = dice1.GetComponent<Rigidbody>();
        _dice2Rb = dice2.GetComponent<Rigidbody>();
        _dice1Rb.isKinematic = true;
        _dice2Rb.isKinematic = true;
        var launcherTransform = this.transform;
        var launcherPosition = launcherTransform.position + Vector3.up * 12;
        _dice1DestPos = new Vector3(_dice1Rb.position.x,launcherPosition.y,_dice1Rb.position.z);
        _dice2DestPos = new Vector3(_dice2Rb.position.x,launcherPosition.y,_dice2Rb.position.z);
        _dice1DestPos = launcherTransform.position - launcherTransform.forward*5f -  launcherTransform.right * rollingRadius + Vector3.up*12;
        _dice2DestPos =  launcherTransform.position - launcherTransform.forward*5f + launcherTransform.right * rollingRadius + Vector3.up*12;
        var time = 0.042f;
        while (time < 1f)
        {
            var delta = Mathf.Pow(time, 3f);
            dice1.transform.position = Vector3.Lerp( _dice1Rb.position,_dice1DestPos,delta);
            dice2.transform.position = Vector3.Lerp( _dice2Rb.position,_dice2DestPos,delta);
            time += 0.01f;
            yield return new WaitForSeconds(0.001f);
        }
        _isRollingDices = true; //starts to roll the dices 
        yield return new WaitForSeconds(1.5f); // <- time of rolling
        Launch();
    }
    
    private void Rolling()
    {
        _dice1Rb.isKinematic = false;
        _dice2Rb.isKinematic = false;
        _dice1Rb.useGravity = false;
        _dice2Rb.useGravity = false;
        _dice1Rb.position = _dice1DestPos;
        _dice2Rb.position = _dice2DestPos;
        _dice1Rb.AddRelativeTorque(rollingSpeedRotation,rollingSpeedRotation,-rollingSpeedRotation);
        _dice2Rb.AddRelativeTorque(-rollingSpeedRotation,rollingSpeedRotation,rollingSpeedRotation);
    }
    
    private void Launch()
    {
        _isRollingDices = false;
        _dice1Rb.useGravity = true;
        _dice2Rb.useGravity = true;
        _dice1Rb.isKinematic = false;
        _dice2Rb.isKinematic = false;
        var launchDirection = this.transform.position;
        Vector3 forceDirection = new Vector3(-launchDirection.x,1,-launchDirection.z).normalized*2000f;
        _dice1Rb.AddForce(forceDirection);
        _dice2Rb.AddForce(forceDirection);
        _dice1Rb.AddRelativeTorque(-rollingSpeedRotation,-rollingSpeedRotation,-rollingSpeedRotation);
        _dice2Rb.AddRelativeTorque(rollingSpeedRotation,rollingSpeedRotation,rollingSpeedRotation);
        dice1.GetComponent<Dice>().Launched();
        dice2.GetComponent<Dice>().Launched();
        StartCoroutine(MakeSumOfDices());
    }
    
    private IEnumerator MakeSumOfDices()
    {
        while (dice1.GetComponent<Dice>().GetValue() == -1 || dice2.GetComponent<Dice>().GetValue() == -1)
        {
            yield return new WaitForSeconds(0.1f); //every 0.1 seconds check if the dices are finally aligned
        }
        sum = dice1.GetComponent<Dice>().GetValue();
        sum += dice2.GetComponent<Dice>().GetValue();
        _gameMan.DicesStopped(sum);
        dice1.GetComponent<Dice>().ResetValue();
        dice2.GetComponent<Dice>().ResetValue();
    }


    public void setDicesToDefaultPosition()
    {
        StartCoroutine(setDicesToDefPos());
    }
    
    private IEnumerator setDicesToDefPos()
    {
        _dice1Rb = dice1.GetComponent<Rigidbody>();
        _dice2Rb = dice2.GetComponent<Rigidbody>();
        _dice1Rb.isKinematic = true;
        _dice2Rb.isKinematic = true;
        dice1.transform.position = new Vector3(_dice1Rb.position.x,2f,_dice1Rb.position.z);
        dice2.transform.position = new Vector3(_dice2Rb.position.x,2f,_dice2Rb.position.z);
        //move dices to the default position 
        var _dice1DefPos = new Vector3(17,2,-17);
        var _dice2DefPos = new Vector3(13,2,-17);
        var _diceDefRotation = Quaternion.Euler(90f, 90f, 45f);
        var time = 0.042f;
        while (time < 1f)
        {
            var delta = Mathf.Pow(time, 3f);
            dice1.transform.position = Vector3.Lerp( _dice1Rb.position,_dice1DefPos,time);
            dice2.transform.position = Vector3.Lerp( _dice2Rb.position,_dice2DefPos,time);
            dice1.transform.rotation = Quaternion.Lerp(dice1.transform.rotation,_diceDefRotation,time);
            dice2.transform.rotation = Quaternion.Lerp(dice2.transform.rotation,_diceDefRotation,time);
            time += 0.01f;
            yield return new WaitForSeconds(0.001f);
        }
    }
    
}
