using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryQuestScript : MonoBehaviour
{
    public int index;
    public Text StoreNameText; // 나중에 Store 추가하기로함 현재는 Food Name
    public Text PriceText; // 가격 : Price : 배달비 : 형식으로
    public Text DistanceText;
    public Text LeftTimeText; // 나중에 추가 현재는 없음

    // Start is called before the first frame update
    void Start()
    {
        //StoreNameText = GameObject.Find("StoreNameText").GetComponent<Text>();
        //PriceText = GameObject.Find("PriceText").GetComponent<Text>();
        //DistanceText = GameObject.Find("DistanceText").GetComponent<Text>();
        //LeftTimeText = GameObject.Find("LeftTimeText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInit()
    {
        OnTextEmpty();
        StoreNameText = transform.Find("StoreNameText").GetComponent<Text>();
        PriceText = transform.Find("PriceText").GetComponent<Text>();
        DistanceText = transform.Find("DistanceText").GetComponent<Text>();
        LeftTimeText = transform.Find("LeftTimeText").GetComponent<Text>();

        //Debug.Log(index + " " + "OnSetText");
        //Debug.Log("StoreNameText :  " + transform.Find("StoreNameText").GetComponent<Text>().text);
        //Debug.Log("PriceText :  " + transform.Find("PriceText").GetComponent<Text>().text);
        //Debug.Log("DistanceText :  " + transform.Find("DistanceText").GetComponent<Text>().text);
        //Debug.Log("LeftTimeText :  " + transform.Find("LeftTimeText").GetComponent<Text>().text);
    }

    public void OnSetText()
    {
        transform.Find("StoreNameText").GetComponent<Text>().text = StoreNameText.text;
        transform.Find("PriceText").GetComponent<Text>().text = PriceText.text;
        transform.Find("DistanceText").GetComponent<Text>().text = DistanceText.text;
        transform.Find("LeftTimeText").GetComponent<Text>().text = LeftTimeText.text;
    }

    public void OnTextEmpty()
    {
        transform.Find("StoreNameText").GetComponent<Text>().text = "";
        transform.Find("PriceText").GetComponent<Text>().text = "";
        transform.Find("DistanceText").GetComponent<Text>().text = "";
        transform.Find("LeftTimeText").GetComponent<Text>().text = "";
    }

    public void SetQuestIndex(int index)
    {
        //Debug.Log(index + " : " + StoreNameText + "\n" + PriceText + "\n" + DistanceText + "\n" + LeftTimeText + "\n");
        OrderManager orderManager = GameObject.Find("OrderManager").GetComponent<OrderManager>();

        this.index = index;

        this.OnInit();
        this.StoreNameText.text = orderManager.GetListIndexOf(index).food.Name;

        this.PriceText.text = "가격 : " + orderManager.GetListIndexOf(index).food.FoodPrice + " 원" + " 배달비 : " + orderManager.GetListIndexOf(index).Reward;
        // 현재 플레이어 위치->픽업 거리 + 픽업->목적지 거리
        GameObject gameObject = GameObject.Find("Car");
        this.DistanceText.text = "약 " + ((int)Vector3.Distance(gameObject.transform.position, orderManager.GetListIndexOf(index).getSrc()) + (int)Vector3.Distance(
            orderManager.GetListIndexOf(index).getSrc(), orderManager.GetListIndexOf(index).getDst())) % 10000 + " m";

        this.LeftTimeText.text = "";

        //this.OnSetText();
        //Debug.Log(this.index + " : " + StoreNameText.text + "\n" + PriceText.text + "\n" + DistanceText.text + "\n" + LeftTimeText.text + "\n");
    }

    public void SetQuest(Order order, int index)
    {
        this.index = index;
        StoreNameText.text = order.food.Name;
        PriceText.text = "가격 : " + order.food.FoodPrice + " 원" + " 배달비 : " + order.Reward;
        // 현재 플레이어 위치->픽업 거리 + 픽업->목적지 거리
        GameObject gameObject = GameObject.Find("Car");
        DistanceText.text = "약 " + Vector3.Distance(gameObject.transform.position, order.getSrc()) + Vector3.Distance(order.getSrc(), order.getDst()) + " m";

        LeftTimeText.text = "";

        OnSetText();
    }

    public void Click()
    {
        // TODO : 메시지 박스 출력후 해야 하나 지금은 그냥 누르면 하기로 함.
        DeliveryManagerScript deliveryManager = GameObject.Find("DeliveryManager").GetComponent<DeliveryManagerScript>();
        deliveryManager.SetDeliveryToIndex(index);

        PlayerCurrentDeliveryPanelScript playerCurrentDeliveryPanel = GameObject.Find("PlayerCurrentDeliveryPanel").GetComponent<PlayerCurrentDeliveryPanelScript>();
        playerCurrentDeliveryPanel.SetInformationIndex(index);
    }

    public Text GetQuestName()
    {
        return StoreNameText;
    }
}
