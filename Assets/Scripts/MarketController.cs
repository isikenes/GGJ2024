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
        items[index].GetComponentInChildren<Button>().gameObject.SetActive(false);

        string key = "isUnlocked" + index;
        PlayerPrefs.SetInt(key, 1);
        yogurtController.DecreaseSikke(items[index].cost);
    }
    


}
