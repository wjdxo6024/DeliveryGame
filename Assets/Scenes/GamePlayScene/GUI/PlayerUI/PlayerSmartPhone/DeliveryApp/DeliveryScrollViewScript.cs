using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryScrollViewScript : MonoBehaviour
{

    private ScrollRect scrollRect;
    public float space = 50f;
    public GameObject prefab;
    public List<RectTransform> uiObjects = new List<RectTransform>();
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        InitScrollView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitScrollView()
    {
        OrderManager orderManager = GameObject.Find("OrderManager").GetComponent<OrderManager>();
        float y = 0f;

        //// �ٽ� �ʱ�ȭ �� ���
        if(uiObjects.Count > 0)
        {
            Debug.Log("Count > 0 false");
            for (int i = 0; i < orderManager.MakeListNumber; i++)
            {
                uiObjects[i].GetComponent<DeliveryQuestScript>().SetQuestIndex(i);
            }
        }
        else
        {
            Debug.Log("Count > 0 true");
            for (int i = 0; i < orderManager.MakeListNumber; i++)
            {
                //GameObject prefabQuest = new GameObject();
                //Order tempOrder = new Order();

                //tempOrder = orderManager.GetListIndexOf(i);
                GameObject prefabQuest = Instantiate(prefab) as GameObject;
                prefabQuest.GetComponent<DeliveryQuestScript>().SetQuestIndex(i);
                //prefabQuest.transform.SetParent(GameObject.Find("Content").transform);

                var newUi = Instantiate(prefabQuest, scrollRect.content).GetComponent<RectTransform>();
                uiObjects.Add(newUi);

                uiObjects[i].anchoredPosition = new Vector2(0f, -y);
                uiObjects[i].GetComponent<DeliveryQuestScript>().SetQuestIndex(i);
                y += uiObjects[i].sizeDelta.y + 1f + space;
                Destroy(prefabQuest);
            }
        }

        scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, y);

        //// ����� ��
        for (int i = 0; i < 5; i++)
        {
            //Debug.Log(uiObjects[i].GetComponent<DeliveryQuestScript>().index + " " + uiObjects[i].GetComponent<DeliveryQuestScript>().StoreNameText.text
            //    + " " + uiObjects[i].GetComponent<DeliveryQuestScript>().PriceText.text);

            // ���� �������� 2��° ���� ����� ������ ���� �ʴ� �������� ��Ÿ���� �ٽ� ����.
            uiObjects[i].GetComponent<DeliveryQuestScript>().SetQuestIndex(uiObjects[i].GetComponent<DeliveryQuestScript>().index);
        }
    }
}
