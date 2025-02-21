using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    //UI
    public bool captureUI = false;
    public bool rentrerUI = false;

    public int slimes1 = 0;

    public Text slimesOne;
    public GameObject CapturePanel;
    public GameObject RentrerPanel;
    void Start()
    {
        CapturePanel.SetActive(false);
        RentrerPanel.SetActive(false);
    }

    void Update()
    {
        slimesOne.text = "SLIMES : "+ slimes1;

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
            slimes1 += 1;
        }
    }

}
