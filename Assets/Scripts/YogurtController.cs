using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YogurtController : MonoBehaviour
{
    int yogurt=0;
    int scorePerClick = 1;
    [SerializeField] TextMeshProUGUI counter;
    public bool isPassiveActivated;
    int passivePerSecond = 1;
    float lastPassive;
    [SerializeField] GameObject floatingTextPrefab;
    MarketController market;
    // Start is called before the first frame update
    void Start()
    {
        yogurt = PlayerPrefs.GetInt("yogurt", 0);
        counter.SetText(yogurt.ToString());
        lastPassive = Time.time;
        market = GetComponent<MarketController>();
        market.checkBuyable(yogurt);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPassiveActivated && Time.time-lastPassive>1)
        {
            yogurt += passivePerSecond;
            lastPassive = Time.time;
            UpdateCounterText();
        }
    }

    public void Click()
    {
        yogurt += scorePerClick;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counter.SetText(yogurt.ToString());
        counter.GetComponentInParent<Animator>().Play("CounterAnimation");
        PlayerPrefs.SetInt("yogurt", yogurt);
        Instantiate(floatingTextPrefab, new Vector2(-3f, -1f), Quaternion.identity);

        market.checkBuyable(yogurt);
    }


    public void DecreaseSikke(int amount)
    {
        yogurt -= amount;
        UpdateCounterText();
    }
    
}
