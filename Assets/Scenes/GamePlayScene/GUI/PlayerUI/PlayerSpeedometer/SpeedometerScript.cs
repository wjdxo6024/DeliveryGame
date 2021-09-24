using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerScript : MonoBehaviour
{
    private Transform needleTransform;
    private Transform speedLabelTemplateTransform;

    private const float MAX_SPEED_ANGLE = -110;
    private const float ZERO_SPEED_ANGLE = 120;

    private float speedMax;
    private float speed;

    // 움직임을 부드럽게 하기위한 변수
    private float startPosition, endPosition;
    private float desiredPosition;

    private void Awake()
    {
        needleTransform = transform.Find("SpeedometerNeedle");
        speedLabelTemplateTransform = transform.Find("SpeedometerLabelTemplate");
        speedLabelTemplateTransform.gameObject.SetActive(false);
        // TODO : 이 두 변수는 Bike스크립트의 속도에서 가져올 것.
        speed = 0f;
        speedMax = 200f;

        CreateSpeedLabels();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CarControllerScript carControllerScript = GameObject.Find("Car").GetComponent<CarControllerScript>();
        SetSpeed(carControllerScript.GetVelocity());

        // needle 업데이트
        needleTransform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(ZERO_SPEED_ANGLE, MAX_SPEED_ANGLE, speed / speedMax));
    }

    private void CreateSpeedLabels()
    {
        int labelAmout = 10;
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        for(int i = 0; i <= labelAmout; i++)
        {
            Transform speedLabelTransform = Instantiate(speedLabelTemplateTransform, transform);
            float labelSpeedNormalized = (float)i / labelAmout;
            float speedLabelAngle = ZERO_SPEED_ANGLE - labelSpeedNormalized * totalAngleSize;
            speedLabelTransform.eulerAngles = new Vector3(0, 0, speedLabelAngle + 90);
            speedLabelTransform.Find("SpeedText").GetComponent<Text>().text = Mathf.RoundToInt(labelSpeedNormalized * speedMax).ToString();
            speedLabelTransform.Find("SpeedText").eulerAngles = Vector3.zero;
            speedLabelTransform.gameObject.SetActive(true);

        }

        needleTransform.SetAsLastSibling();
    }

    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }

    private void NeedleUpdate()
    {
        desiredPosition = startPosition - endPosition;
        float speedNormalized = speed / speedMax;
        needleTransform.eulerAngles = new Vector3(0, 0, (startPosition - speedNormalized * desiredPosition));
    }
    

    public void SetSpeed(float Speed)
    {
        speed = Speed;
    }
}
