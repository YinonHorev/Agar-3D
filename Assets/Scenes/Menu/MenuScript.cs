using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_HowToPlayImage;
    // Start is called before the first frame update
    void Start()
    {
        m_HowToPlayImage.SetActive(false);
    }

    public void Start_OnClick()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void HowToPlay_OnClick()
    {
        m_HowToPlayImage.SetActive(true);
    }
    
    public void Exit_OnClick()
    {
        Application.Quit();
    }
    
    public void BackToMenu_OnClick()
    {
        m_HowToPlayImage.SetActive(false);
    }
}
