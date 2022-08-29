using UnityEngine;

public class world : MonoBehaviour
{
    public static world instance;
    private void Awake()
    {
        instance = this;
    }
    public Rigidbody2D[] targets;
    public Rigidbody2D GetTarget(Vector3 pos)
    {
        Rigidbody2D rb = targets[0];
        for (int i = 1; i < targets.Length; i++)
        {
            if (Vector3.Distance(pos, rb.gameObject.transform.position) > Vector3.Distance(pos, targets[i].gameObject.transform.position))
            {
                rb = targets[i];
            }
        }
        return rb;
    }
}
