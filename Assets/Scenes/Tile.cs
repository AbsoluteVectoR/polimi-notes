using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public GameObject number;
    private TextMeshProUGUI numberText;
    public void SetTextNum(int num)
    {
        numberText = number.GetComponent<TextMeshProUGUI>();
        numberText.text = num.ToString();
    }
    
    public int GetTextNum()
    {
        int number = -1;
        int.TryParse(numberText.text,out number);
        return number;
    }
    
    public void flipTile()
    {
        this.transform.Rotate(45,0,0);
    }
    
}
