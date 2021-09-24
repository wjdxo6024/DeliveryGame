using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref 
// https://github.com/choijoohee213/SD-RPG/tree/master/Assets/Scripts
// https://ansohxxn.github.io/unity%20lesson%203/ch5-1/
public class PlayerBase : MonoBehaviour
{
    private int Reputation = 50;
    // 보유한 탈 것 목록
    private List<Ride> RideList = new List<Ride>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetReputation()
    {
        return Reputation;
    }

    void SetReputation(int Reputation)
    {
        this.Reputation = Reputation;
    }

    void AddReputation(int Reputation)
    {
        this.Reputation += Reputation;
        if(100 < this.Reputation)
        {
            this.Reputation = 100;
        }
    }

    void SubReputation(int Reputation)
    {
        this.Reputation -= Reputation;
        if(this.Reputation < 0)
        {
            this.Reputation = 0;
        }
    }
}
