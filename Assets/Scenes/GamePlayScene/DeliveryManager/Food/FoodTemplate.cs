using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTemplate : MonoBehaviour
{
    public List<Food> Template;

    private int ListSize;
    // Start is called before the first frame update
    void Start()
    {
        ListSize = Template.Count;
    }

    public Food GetFoodIndexOf(int index)
    {
        if (index >= ListSize || index < 0)
            return null;
        return Template[index];
    }

    public Food GetFoodRandom()
    {
        return Template[Random.Range(0, Template.Count - 1)];
    }
}
