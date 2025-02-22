using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    //UI
    public bool captureUI = false;
    public bool rentrerUI = false;

    public int canna = 0;
    public int champi = 0;

    public Text cannaText;
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
    }

}
