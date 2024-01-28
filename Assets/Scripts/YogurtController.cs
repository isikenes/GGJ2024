using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    int endScore=1000;
    [SerializeField] GameObject[] cutscenes;
    int cutsceneIndex = 0;
    int[] cutsceneScores = {100, 1000, 10000, 100000, 1000000 };

    //int[] cutsceneScores = { 10, 20, 30, 40, 50 };

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
        cutsceneIndex = PlayerPrefs.GetInt("cutscene", 0);
        endScore = cutsceneScores[cutsceneIndex];
        UpdateCounterText();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPassiveActivated && Time.time-lastPassive>1)
        {
            yogurt += passivePerSecond;
            lastPassive = Time.time;
            UpdateCounterText();
            GameObject damla = Instantiate(floatingTextPrefab, new Vector2(-1.75f, -2f), Quaternion.identity);
            damla.GetComponentInChildren<TextMesh>().text = "+" + passivePerSecond;
        }
    }

    public void Click()
    {
        yogurt += scorePerClick;
        UpdateCounterText();
        GameObject damla = Instantiate(floatingTextPrefab, new Vector2(-1.75f, -2f), Quaternion.identity);
        damla.GetComponentInChildren<TextMesh>().text = "+" + scorePerClick;
    }

    private void UpdateCounterText()
    {
        counter.SetText(yogurt.ToString());
        counter.GetComponentInParent<Animator>().Play("CounterAnimation");
        PlayerPrefs.SetInt("yogurt", yogurt);

        market.checkBuyable(yogurt);
        bar.value = (float) yogurt / (float) endScore;
        if(yogurt>=cutsceneScores[cutsceneIndex])
        {
            cutscenes[cutsceneIndex].SetActive(true);
            StartCoroutine(CloseCutscene(cutsceneIndex));
            cutsceneIndex++;
            PlayerPrefs.SetInt("cutscene", cutsceneIndex);
            endScore = cutsceneScores[cutsceneIndex];
            bar.value = (float)yogurt / (float)endScore;
        }

        if(yogurt>=10000000000)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator CloseCutscene(int x)
    {
        yield return new WaitForSeconds(10);
        cutscenes[x].SetActive(false);
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
