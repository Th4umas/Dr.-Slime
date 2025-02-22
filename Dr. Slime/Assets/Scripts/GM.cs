using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    

    //UI
    public bool captureUI = false;
    public bool rentrerUI = false;

    public int canna = 0;
    public int champi = 0;
    public int crack = 0;

    public Text cannaText;
    public Text crackText;
    public Text champiText;
    public GameObject CapturePanel;
    public GameObject RentrerPanel;
    void Start()
    {
        CapturePanel.SetActive(false);
        RentrerPanel.SetActive(false);
    }

    void Update()
    {
        cannaText.text = "CANNA\nSLIMES : " + canna;

        champiText.text = "CHAMPI\nSLIMES : " + champi;

        crackText.text = "CRACK\nSLIMES : " + crack;

        if (captureUI && !rentrerUI)
        {
            CapturePanel.SetActive(true);
        }
        else
        {
            CapturePanel.SetActive(false);
        }

        if (rentrerUI)
        {
            RentrerPanel.SetActive(true);
        }
        else
        {
            RentrerPanel.SetActive(false);
        }



        data.cannabis = canna;
        data.champignons = champi;
        data.crack = crack;
    }

    public void capture(int type)
    {
        if (type == 1)
        {
            canna += 1;
        }
        if (type == 2)
        {
            champi += 1;
        }
        if (type == 3)
        {
            crack += 1;
        }
    }

}
