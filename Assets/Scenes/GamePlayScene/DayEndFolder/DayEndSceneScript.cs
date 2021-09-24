using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayEndSceneScript : MonoBehaviour
{
    Text text;
    Text resultText;

    GameObject GuideText;
    int wait_time = 3;
    bool is_waiting = true;
    // Start is called before the first frame update
    void Start()
    {
        // 정산 후
        WalletManagerScript walletManager = GameObject.Find("WalletManager").GetComponent<WalletManagerScript>();
        walletManager.ClosingForEndDay();

        GuideText = GameObject.Find("GuideText");
        GuideText.SetActive(false);
        is_waiting = true;

        TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();
        text = GameObject.Find("Text").GetComponent<Text>();
        text.text = timeManager.GetDays() + " 일차 종료";

        resultText = GameObject.Find("ResultText").GetComponent<Text>();
        resultText.text = "소지금 : " + walletManager.GetCurrentMoney() + " 원";

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
        if (!is_waiting && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            GameManagerScript gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            gameManager.SetGameState(GamePlayState.DAYBEGIN);
        }
    }
}
