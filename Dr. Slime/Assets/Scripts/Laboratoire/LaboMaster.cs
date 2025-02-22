using UnityEngine;
using UnityEngine.UI;

public class LM : MonoBehaviour
{
    public int nbcanna;
    public int nbchampi;
    public int nbcrack;    
    
    public Text txtcanna;
    public Text txtchampi;
    public Text txtcrack;

    void Start()
    {
        
    }

    void Update()
    {

        nbcanna = data.cannabis;
        nbchampi = data.champignons;
        nbcrack = data.crack;

        txtcanna.text = "CANNASLIME : "+nbcanna;
        txtchampi.text = "CHAMPISLIME : " + nbchampi;
        txtcrack.text = "CRACKSLIME : " + nbcrack;
    }
}
