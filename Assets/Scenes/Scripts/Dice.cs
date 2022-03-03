using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Transform DiceTransform;
    public int value;
    
    void Start()
    {
        value = 2000;
        DiceTransform = this.GetComponent<Transform>();
    }
    public int IsValue()
    {
        if (Vector3.Dot(DiceTransform.up, Vector3.up) > 0.9f) return 3;
        else if (Vector3.Dot(-DiceTransform.up, Vector3.up) > 0.9f) return 4;
        else if (Vector3.Dot(DiceTransform.forward, Vector3.up) > 0.9f) return 1;
        else if (Vector3.Dot(-DiceTransform.forward, Vector3.up) > 0.9f) return 6;
        else if (Vector3.Dot(DiceTransform.right, Vector3.up) > 0.9f) return 2;
        else return 5;
    }
    void Update()
    {
        if (this.GetComponent<Rigidbody>().velocity.magnitude <= 0.1f) Debug.Log(IsValue());
    }
}
