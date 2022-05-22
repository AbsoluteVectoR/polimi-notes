using TMPro;
using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public GameObject number;
    private TextMeshProUGUI _numberText;
    private Player owner;

    private int myNumber;
    public void SetTextNum(int num)
    {
        _numberText = number.GetComponent<TextMeshProUGUI>();
        _numberText.text = num.ToString();
        myNumber = num;
    }

    public void setOwner(Player owner)
    {
        this.owner = owner;
    }
    
    public IEnumerator spawningAnimation(){
        var initialPosition = this.transform.position;
        this.transform.position = initialPosition - this.transform.forward*500f;
        yield return new WaitForSeconds(myNumber/10f);
        var i = 1f;
        while(i>0f){
            this.transform.position = Vector3.Lerp(initialPosition, initialPosition - this.transform.forward*500f,i*i);
            i-=0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    
    public int GetTextNum()
    {
        return myNumber;
    }

    public void Flip() //Used by Button and PlayerAI
    {
        if (owner.GetSelectableTiles().Contains(GetTextNum())&&
            owner.IsSelecting())
        {
            owner.TileSelected(GetTextNum());
            this.transform.Rotate(45, 0, 0);
        }
    }
    
}