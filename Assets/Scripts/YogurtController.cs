using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class YogurtController : MonoBehaviour
{
    int yogurt=0;
    int scorePerClick = 1;
    [SerializeField] TextMeshProUGUI counter;
    public bool isPassiveActivated;
    int passivePerSecond = 0;
    float lastPassive;
    [SerializeField] GameObject floatingTextPrefab;
    MarketController market;
    [SerializeField] Slider bar;
    int endScore=10000;
    // Start is called before the first frame update
    void Start()
    {
        yogurt = PlayerPrefs.GetInt("yogurt", 0);
        counter.SetText(yogurt.ToString());
        lastPassive = Time.time;
        market = GetComponent<MarketController>();
        market.checkBuyable(yogurt);
        scorePerClick = PlayerPrefs.GetInt("spc", 1);
        passivePerSecond = PlayerPrefs.GetInt("pps", 1);
        isPassiveActivated = PlayerPrefs.GetInt("passive", 0) == 1;
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
        bar.value = (float) yogurt / (float) endScore;
    }


    public void DecreaseSikke(int amount)
    {
        yogurt -= amount;
        UpdateCounterText();
    }

    public void UpdateScorePerClick()
    {
        scorePerClick *= 2;
        PlayerPrefs.SetInt("spc", scorePerClick);
    }

    public void ActivatePassive()
    {
        isPassiveActivated = true;
        passivePerSecond = 1;
        PlayerPrefs.SetInt("passive", 1);
    }
    
    public void UpdatePassive()
    {
        passivePerSecond *= 2;
        PlayerPrefs.SetInt("pps", passivePerSecond);
    }
}
