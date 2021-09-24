using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DayStartSceneScript : MonoBehaviour
{
    Text text;
    GameObject GuideText;
    int wait_time = 3;
    bool is_waiting = true;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        WalletManagerScript walletManager = GameObject.Find("WalletManager").GetComponent<WalletManagerScript>();
        if(walletManager.IsMoneyEmpty())
        {
            gameManager.SetGameState(GamePlayState.GAMEOVER);
            return;
        }

        GuideText = GameObject.Find("GuideText");
        GuideText.SetActive(false);
        is_waiting = true;

        TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();

        text = GameObject.Find("Text").GetComponent<Text>();
        text.text = timeManager.GetDays() + " ÀÏÂ÷";

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(wait_time);
        GuideText.SetActive(true);
        is_waiting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!is_waiting && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            GameManagerScript gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            gameManager.SetGameState(GamePlayState.PLAYING);
        }
    }
}
