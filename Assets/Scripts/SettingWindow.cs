using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingWindow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject settingWindow;
    
    public void SettingBtnClick()
    {
        Invoke("Show", .8f);
    }

    public void Show()
    {
        settingWindow.SetActive(true);
    }

    public void SettingBackBtnClick()
    {
        settingWindow.SetActive(false);
    }

    public void GameEndBtnClick()
    {
        Application.Quit();
    }

    public void HomeClick()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        print(scene.name);
        SceneManager.LoadScene(scene.name);
    }

}
