using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTheme : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Stop("Theme");
    }
}
