using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public float wait_time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(wait_time);

        SceneManager.LoadScene("MainMenuScene");
        // 게임 매니저 파괴
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("WalletManager"));
        Destroy(GameObject.Find("TimeManager"));
        Destroy(GameObject.Find("PlaySceneManager"));
        Destroy(GameObject.Find("AudioManager"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
