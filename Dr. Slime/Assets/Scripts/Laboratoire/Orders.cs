using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Orders : MonoBehaviour
{
    public LM lm;

    public List<string> chances = new List<string>();
    public List<int> yo = new List<int>();

    public Text ingredient1;
    public Text ingredient2;

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

    public void completeorder()
    {
        Order(enquiry());
    }

    private void Order(List<int> cac)
    {
        if( cac[0] == 1)
        {
            ingredient1.text = "INGREDIENT 1 : cannabis";
        }
        else if( cac[0] == 2)
        {
            ingredient1.text = "INGREDIENT 1 : datura";
        }
        else if ( cac[0] == 3)
        {
            ingredient1.text = "INGREDIENT 1 : MDMA";
        }

        if (cac[1] == 1)
        {
            ingredient2.text = "INGREDIENT 2 : cannabis";
        }
        else if (cac[1] == 2)
        {
            ingredient2.text = "INGREDIENT 2 : datura";
        }
        else if (cac[1] == 3)
        {
            ingredient2.text = "INGREDIENT 2 : MDMA";
        }
    }

    private List<int> enquiry()
    {
        yo.Clear();
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
        /*
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
        }*/
        Debug.Log(yo);
        return yo;  
    }


    
    private IEnumerator order()
    {
        yield return new WaitForSeconds(1f);
    }
}
