using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum OrderStatus { PICKING = 0, DELIVERING, FINISHED };

public class Order : MonoBehaviour
{
    // 주문 완료를 위해 배달해야 하는 음식
    public Food food;
    // 픽업지 (출발 지점)
    private Vector3 srcVector;
    // 목적지 (도착 지점)
    private Vector3 dstVector;
    private OrderStatus status;
    // 배달료 (보상)
    public int Reward;

    private float SelectTime; // 주문 받은 시간

    // TODO: Fix later: OrderedFoodList type to 'params Food[] OrderedFoodList'
    public Order()
    {
        MakeOrder();
    }

    void Update()
    {
        // TODO: add timer here
    }

    public Vector3 getSrc()
    {
        return this.srcVector;
    }

    public Vector3 getDst()
    {
        return this.dstVector;
    }

    public bool IsPicking()
    {
        if (this.status == OrderStatus.PICKING)
            return true;
        else
            return false;
    }

    public bool IsDelivering()
    {
        if (this.status == OrderStatus.DELIVERING)
            return true;
        else
            return false;
    }

    public Vector3 GetCurrentDst()
    {
        if (this.IsPicking())
            return this.srcVector;
        if (this.IsDelivering())
            return this.dstVector;

        return new Vector3(0, 0, 0);
    }

    public void SetStatus(OrderStatus status)
    {
        this.status = status;
    }

    public int Finish()
    {
        // TODO: 
        // * give reward
        return Reward;
    }

    public void MakeOrder()
    {
        TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();
        FoodTemplate foodTemplate = GameObject.Find("FoodTemplate").GetComponent<FoodTemplate>();
        DestinationTemplate destinationTemplate = GameObject.Find("DestinationTemplate").GetComponent<DestinationTemplate>();

        DeliveryPos tmpPos1 = destinationTemplate.GetPosRandom();
        DeliveryPos tmpPos2 = destinationTemplate.GetPosRandom();

        while (tmpPos1 == tmpPos2)
            tmpPos2 = destinationTemplate.GetPosRandom();

        tmpPos1.vector.y = 2.8f;
        tmpPos2.vector.y = 0.91f;

        Food tmpFood = foodTemplate.GetFoodRandom();

        this.food = tmpFood;
        this.srcVector = tmpPos1.vector;
        this.dstVector = tmpPos2.vector;
        this.Reward = tmpFood.Level * 1000 + 1000;
    }

    //public void getRandomOrder()
    //{
    //    Food testFoods = new Food();

    //    float src_x = Random.Range(-100.0f, 100.0f);
    //    float src_z = Random.Range(-100.0f, 100.0f);
    //    Vector3 src = new Vector3(src_x, 0f, src_z);

    //    float dst_x = Random.Range(-100.0f, 100.0f);
    //    float dst_z = Random.Range(-100.0f, 100.0f);
    //    Vector3 dst = new Vector3(dst_x, 0f, dst_z);

    //    int reward = Random.Range(10, 20) * 100; // 1000 ~ 2000 won
    //    // TODO Add foods in testfoods list
    //}

}

