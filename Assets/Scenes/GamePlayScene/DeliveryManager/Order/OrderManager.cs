using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // 林巩 格废
    public List<Order> orders;
    public int MakeListNumber;
    // Start is called before the first frame update
    void Start()
    {
        MakeList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 林巩 格废 积己
    public void MakeList()
    {
        if(orders.Count > 0)
        {
            orders.Clear();
        }

        for(int i = 0; i < MakeListNumber; i++)
        {
            orders.Add(new Order());
            Debug.Log("[" + i + "]" + " order : " + orders[i].food.Name);
        }
    }

    public List<Order> GetList()
    {
        return orders;
    }

    public Order GetListIndexOf(int index)
    {
        if (orders.Count <= index)
            return null;
        else
            return orders[index];
    }

    public Order SelectOrder(int index)
    {
        if (orders.Count <= index)
            return null;
        else
            return orders[index];
    }
}
