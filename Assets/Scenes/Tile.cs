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
    
}
