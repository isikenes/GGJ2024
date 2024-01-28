using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketController : MonoBehaviour
{
    [SerializeField] ItemScript[] items;
    YogurtController yogurtController;
    // Start is called before the first frame update
    void Start()
    {
        yogurtController = GetComponent<YogurtController>();
        int temp = PlayerPrefs.GetInt("lastUnlocked", 0);
        if(temp>0)
        {
            items[temp].GetComponent<Image>().color = Color.green;
        }
    }

    public void checkBuyable(int sikke)
    {
        foreach(ItemScript item in items)
        {

            if(!item.isBought && sikke<item.cost)
            {
                item.GetComponentInChildren<Button>().interactable=false;
            } else if(!item.isBought && sikke >= item.cost)
            {
                item.GetComponentInChildren<Button>().interactable = true;
            }
        }
    }

    public void buyItem(int index)
    {
        items[index].isBought = true;
        items[index].DisableUI();
        items[index].GetComponent<Image>().color = Color.green;
        if(index>0)
        {
            items[index - 1].GetComponent<Image>().color = Color.white;
        }

        string key = "isUnlocked" + index;
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.SetInt("lastUnlocked", index);
        yogurtController.DecreaseSikke(items[index].cost);

        yogurtController.UpdateScorePerClick();
        if (index == 1)
        {
            yogurtController.ActivatePassive();
        } else if(index>1)
        {
            yogurtController.UpdatePassive();
        }

        AudioManager.instance.Play("Coin");
        
    }
    


}
