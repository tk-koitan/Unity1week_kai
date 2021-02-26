using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KoitanLib;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            KoitanDebug.Display("Up\n");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            KoitanDebug.Display("Down\n");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            KoitanDebug.Display("Right\n");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            KoitanDebug.Display("Left\n");
        }
    }
}
