using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orders : MonoBehaviour
{
    public LM lm;

    public List<string> chances = new List<string>();
    public List<int> yo = new List<int>();

    void Start()
    {
        chances.Add("green");
        chances.Add("yellow");
        chances.Add("white");
    }

    void Update()
    {
        
    }

    public bool flipacoin()
    {
        int coin = Random.Range(0,2);
        if (coin == 0)
        {
            return false;
        }
        return true;
    }

    private void enquiry()
    {
        //1
        if (flipacoin())
        {
            yo.Add(1);
        }
        else
        {
            if (flipacoin())
            {
                yo.Add(2);
            }
            else
            {
                yo.Add(3);
            }
        }

        //2
        if (yo[0] != 1)
        {
            if (flipacoin())
            {
                yo.Add(1);
            }
            else
            {
                if (flipacoin())
                {
                    yo.Add(2);
                }
                else
                {
                    yo.Add(3);
                }
            }
        }
        else
        {
            int Coin3 = Random.Range(0, 3);
            if (Coin3 == 0)
            {
                yo.Add(1);
            }
            else
            {
                if (flipacoin())
                {
                    yo.Add(2);
                }
                else
                {
                    yo.Add(3);
                }
            }
        }

        //3
        int Coin4 = Random.Range(0, 3);
        if (Coin4 == 0)
        {
            yo.Add(1);
        }
        else
        {
            if (flipacoin())
            {
                yo.Add(2);
            }
            else
            {
                yo.Add(3);
            }
        }

    }

    
    private IEnumerator order()
    {
        yield return new WaitForSeconds(1f);
    }
}
