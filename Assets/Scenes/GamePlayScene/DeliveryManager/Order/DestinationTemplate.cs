using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTemplate : MonoBehaviour
{
    public List<DeliveryPos> Template;
    private int ListSize;

    private void Start()
    {
        Debug.Log("Template Cound : " + Template.Count);
        ListSize = Template.Count;
    }

    public DeliveryPos GetPosIndexOf(int index)
    {
        if (index >= ListSize || index < 0)
            return null;
        return Template[index];
    }

    public DeliveryPos GetPosRandom()
    {
        return Template[Random.Range(0, Template.Count - 1)];
    }
}
