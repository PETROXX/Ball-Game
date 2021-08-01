using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _creatorsPanel;

    private const string CreatorsPanelShowUpAnimation = "CreatorsPanelShowUpAnimation";

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ShowCreators()
    {
        _creatorsPanel.SetActive(true);
        _creatorsPanel.GetComponent<Animation>().Play(CreatorsPanelShowUpAnimation);
    }

    public void HideCreators()
    {
        _creatorsPanel.SetActive(false);
    }
}
