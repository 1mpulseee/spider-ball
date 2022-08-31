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
    public int lvl;
    [System.Serializable]
    public enum Scene {main, lb, st, info }
    public Scene scene
    {
        get { return _scene; }
        set { _scene = value; }
    }
    private Scene _scene;
}
