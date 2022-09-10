using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvas;
    public static bool IsPause = false;
    bool pause = false;
    //public static canvas instance;
    
    public void pauseOFForON()
    {
        if (pause == false)
        {
            SetPause(true);
            pause = true;
        }
        if (pause == true)
        {
            SetPause(false);
            pause = false;
            Time.timeScale = 1f;
        }
    }
    public void SetPause(bool value)
    {
        IsPause = value;
        PauseCanvas.SetActive(value);
    }
}
