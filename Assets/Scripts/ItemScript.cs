using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public int index;
    public int cost = 10;
    public bool isBought;
    [SerializeField] GameObject[] disables;
    private void Start()
    {
        string key = "isUnlocked" + index;
        if(PlayerPrefs.GetInt(key, 0)==1)
        {
            isBought = true;
            DisableUI();
        }
    }

    public void DisableUI()
    {
        foreach (GameObject g in disables)
        {
            g.SetActive(false);
        }
    }
}
