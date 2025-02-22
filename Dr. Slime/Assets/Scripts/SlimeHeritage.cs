using UnityEngine;

public class ChampiContainer : SlimeController
{

    public override void captured()
    {

        StartCoroutine(capture(2));
    }

}
