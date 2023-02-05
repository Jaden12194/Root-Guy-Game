using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public Rigidbody2D rb;
    private bool MouseKeyDown = false;

    public float moveSpeed = .1f;
    Vector2 position;
    Vector3 mousePos;
    [SerializeField] private float ThrowImpulse;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _distanceJoint.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(MouseKeyDown == true)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) //Right Click (Just Swing)
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            GetMousePosition();
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) //This one will move the character towards the location (Left click)
        {
            MouseKeyDown = true;
            GetMousePosition();
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            //_distanceJoint.connectedAnchor = mousePos;
            //_distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }else if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.AddForce((mousePos - transform.position) * ThrowImpulse, ForceMode2D.Force);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GetMousePosition();
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            rb.AddForce((mousePos - transform.position) * ThrowImpulse, ForceMode2D.Impulse);
        }
        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
        void GetMousePosition()
        {
            mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}