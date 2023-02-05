using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public Rigidbody2D rb;
    [SerializeField] private GameManager GameManager;

    public float moveSpeed = .1f;
    Vector2 position;
    Vector3 mousePos;
    [SerializeField] private float ThrowImpulse;

    public float SwingCooldown;
    public float GrappleCooldown;
    public float MaxCooldown;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.health == 0)
            Destroy(this);
        if (_lineRenderer.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
        if (SwingCooldown > 0)
        {
            SwingCooldown -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1)) //Right Click (Just Swing)
        {
            Swing();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            SwingCooldownReset();
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if(GrappleCooldown > 0)
        {
            GrappleCooldown -= Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0)) //This one will move the character towards the location (Left click)
        {
            Grapple();
        }else if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.AddForce((mousePos - transform.position) * ThrowImpulse, ForceMode2D.Force);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GrappleCooldownReset();
            GetMousePosition();
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
            rb.AddForce((mousePos - transform.position) * ThrowImpulse, ForceMode2D.Impulse);
        }
    }
    void GetMousePosition()
        {
            mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    void Swing()
    {
        Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _lineRenderer.SetPosition(0, mousePos);
        _lineRenderer.SetPosition(1, transform.position);
        _distanceJoint.connectedAnchor = mousePos;
        _distanceJoint.enabled = true;
        _lineRenderer.enabled = true;
    }
    void Grapple()
    {
        GetMousePosition();
        _lineRenderer.SetPosition(0, mousePos);
        _lineRenderer.SetPosition(1, transform.position);
        //_distanceJoint.connectedAnchor = mousePos;
        //_distanceJoint.enabled = true;
        _lineRenderer.enabled = true;
    }
    void SwingCooldownReset()
    {
        SwingCooldown = MaxCooldown;
    }
    void GrappleCooldownReset()
    {
        GrappleCooldown = MaxCooldown;
    }
}