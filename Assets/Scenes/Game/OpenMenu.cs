using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_GameOverImage;
    
    // Start is called before the first frame update
    void Start()
    {
        m_GameOverImage.Enabled(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu_OnCliked()
    {
        m_GameOverImage.SetActive(false);
        SceneManager.LoadScene("Menu");

    }
}
