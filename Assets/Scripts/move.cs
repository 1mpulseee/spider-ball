using System.Collections;
using UnityEngine;
public class move : MonoBehaviour
{
    public Transform c_target;
    private Rigidbody2D target;
    private Rigidbody2D rb;
    private DistanceJoint2D DistanceJoint;
    private LineRenderer lineRenderer;
    private bool IsConnected = false;
    [HideInInspector] public bool IsHook = false;
    private IEnumerator _Connect;
    public int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DistanceJoint = GetComponent<DistanceJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material.color = Menu.instance._color / 255;
        lineRenderer.material.color += new Color(0, 0, 0, 255);
        lineRenderer.material.SetColor("_EmissionColor", Menu.instance._color / 255);
        c_target.transform.parent = null;
    }
    void Update()
    {
        if (IsHook)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.gameObject.transform.position);
        }
        else
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (_Connect == null && !IsConnected)
            {
                _Connect = Connect();
                StartCoroutine(_Connect);
            }
        }
        else if (IsConnected)
        {
            IsConnected = false;
            IsHook = false;
            StopCoroutine(_Connect);
            _Connect = null;
            DistanceJoint.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (IsHook)
        {
            c_target.gameObject.SetActive(false);
        }
        else
        {
            c_target.gameObject.SetActive(true);
            target = world.instance.GetTarget(transform.position);
            c_target.position = target.gameObject.transform.position;
        }
    }
    public IEnumerator Connect()
    {
        target = world.instance.GetTarget(transform.position);
        rb.AddForce(new Vector2(target.gameObject.transform.position.x - transform.position.x, target.gameObject.transform.position.y - transform.position.y).normalized * force, ForceMode2D.Impulse);
        IsHook = true;
        yield return new WaitForSeconds(.1f);
        DistanceJoint.connectedBody = target;
        DistanceJoint.enabled = true;
        IsConnected = true;
    }
    
}