using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketController : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject marketUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenMarket()
    {
        gameUI.SetActive(false);
        marketUI.SetActive(true);
    }

    public void CloseMarket()
    {
        marketUI.SetActive(false);
        gameUI.SetActive(true);
    }
}
