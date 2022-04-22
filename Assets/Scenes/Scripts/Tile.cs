using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject number;
    private TextMeshProUGUI _numberText;
    private Player owner;
    public void SetTextNum(int num)
    {
        _numberText = number.GetComponent<TextMeshProUGUI>();
        _numberText.text = num.ToString();
    }

    public void setOwner(Player owner)
    {
        this.owner = owner;
    }
    
    
    public int GetTextNum()
    {
        int tmp = -1;
        int.TryParse(_numberText.text, out tmp);
        return tmp;
    }

    public void FlipTile()
    {
        if (owner.FlipTile(GetTextNum()))
        {
            this.transform.Rotate(45, 0, 0);
        }
    }
}