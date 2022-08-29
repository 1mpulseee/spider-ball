using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D target;
    private Rigidbody2D rb;
    private DistanceJoint2D DistanceJoint;
    private LineRenderer lineRenderer;
    private bool IsConnected = false;
    private bool IsHook = false;
    private IEnumerator _Connect;
    public int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DistanceJoint = GetComponent<DistanceJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();
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
    public IEnumerator Connect()
    {
        rb.AddForce(new Vector2(target.gameObject.transform.position.x - transform.position.x, target.gameObject.transform.position.y - transform.position.y).normalized * force, ForceMode2D.Impulse);
        IsHook = true;
        yield return new WaitForSeconds(.1f);
        DistanceJoint.connectedBody = target;
        DistanceJoint.enabled = true;
        IsConnected = true;
    }
}