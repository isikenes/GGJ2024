using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiScript : MonoBehaviour
{
    public GameObject CreditPanel;
    public GameObject OptionsPanel;
    public GameObject MenuPanel;
    public void baslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void cikis()
    {
        Application.Quit();
    }
    public void creditscene()
    {
        CreditPanel.gameObject.SetActive(true);
        MenuPanel.gameObject.SetActive(false);
    }
    public void optionscene()
    {
        OptionsPanel.gameObject.SetActive(true);
        MenuPanel.gameObject.SetActive(false);
    }
    public void Geributon()
    {
        CreditPanel.gameObject.SetActive(false);
        OptionsPanel.gameObject.SetActive(false);
        MenuPanel.gameObject.SetActive(true);
    }
}
