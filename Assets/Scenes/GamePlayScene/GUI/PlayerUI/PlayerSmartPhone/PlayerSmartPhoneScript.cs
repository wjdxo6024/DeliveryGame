using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SmartPhoneState { MAINSCREEN, BANKAPP, DELIVERYAPP };

public class PlayerSmartPhoneScript : MonoBehaviour
{
    private SmartPhoneState PlayerPhoneState;

    private Transform PhoneTransform;
    private RectTransform PhoneRectTransform;

    private bool IsEnlarge = false;
    private void Awake()
    {
        PhoneTransform = transform;
        SetState(SmartPhoneState.MAINSCREEN);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            IsEnlarge = !IsEnlarge;
        }

        if (IsEnlarge)
        {
            Enlarge();
        }
        else
        {
            Reduction();
        }
        //WindowScript windowComponent = GameObject.Find("Window").GetComponent<WindowScript>();
        //windowComponent.Show();
    }

    private void Enlarge()
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        GameObject obj = GameObject.Find("PlayerSmartPhone");
        Vector3 position = obj.transform.localPosition;

        obj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        position.x = 370f;
        position.y = -170 * 3f;
        obj.transform.localPosition = position;

        //rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1200);
        //rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 700);
    }

    private void Reduction()
    {
        RectTransform rectTran = gameObject.GetComponent<RectTransform>();
        GameObject obj = GameObject.Find("PlayerSmartPhone");
        Vector3 position = obj.transform.localPosition;
        Vector3 scale = obj.transform.localScale;

        obj.transform.localScale = new Vector3(1f, 1f, 1f);

        position.x = 900f; // -519 -> 169 -> -46 370*3
        position.y = -500f; // 346 -> 145 -> 78 -173 * 3
        obj.transform.localPosition = position;

        //rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 428);
        //rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 652);
    }

    public SmartPhoneState GetState()
    {
        return PlayerPhoneState;
    }

    // 스테이지가 바뀌는 것으로 Show를 출력.
    public void SetState(SmartPhoneState state)
    {
        PlayerPhoneState = state;

        WindowScript windowComponent = GameObject.Find("Window").GetComponent<WindowScript>();
        windowComponent.Show();
    }

}
