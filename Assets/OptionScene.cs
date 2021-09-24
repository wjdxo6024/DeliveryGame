using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionScene : MonoBehaviour
{
    FullScreenMode screenMode;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenBtn;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;
    public GameObject canvas;

    void Awake()
    {
        GameObject.Find("SoundManager").transform.Find("Canvas").gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        initUI();

    }

    // Update is called once per frame
    void initUI()
    {
        for (int i=0; i<Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60)
                resolutions.Add(Screen.resolutions[i]);
        }

        resolutionDropdown.options.Clear();

        int optionNum = 0;
        foreach(Resolution item in resolutions)
        {
            //Debug.Log(item.width + "x" + item.height + " " + item.refreshRate + "hz");
 
                Dropdown.OptionData option = new Dropdown.OptionData();
                option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
                resolutionDropdown.options.Add(option);

                if (item.width == Screen.width && item.height == Screen.height)
                    resolutionDropdown.value = optionNum;
         optionNum++;
        }

        resolutionDropdown.RefreshShownValue();

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }
    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void OkBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width,
            resolutions[resolutionNum].height,
            screenMode);
    }

    public void CloseBtnClick()
    {
        LoadingScene.LoadScene("MainMenuScene");
        canvas.gameObject.SetActive(false);
    }
}
