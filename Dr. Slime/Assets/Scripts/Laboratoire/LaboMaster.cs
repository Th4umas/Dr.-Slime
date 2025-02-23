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
    public Text money;

    void Start()
    {
        
    }

    void Update()
    {

        nbcanna = data.cannabis;
        nbchampi = data.champignons;
        nbcrack = data.crack;

        txtcanna.text = "SLIME VERT : "+nbcanna;
        txtchampi.text = "SLIME JAUNE : " + nbchampi;
        txtcrack.text = "SLIME BLANC : " + nbcrack;
        money.text = ""+data.money;
    }
}
