using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Menu instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
