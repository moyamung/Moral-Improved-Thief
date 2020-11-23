using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    float movementX;
    float movementY;
    float speed = 4.0f;
    float jump = 9f;
    const float portalDelay = 0.3f;

    bool portalUseable;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        portalUseable = true;
    }

    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void OnSpaceBar()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jump, _rigidbody.velocity.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(horizontal, 0f, 0f);
        _rigidbody.AddForce(new Vector3(movementX, 0f, 0f) *  speed);
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity += new Vector3(0f, jump, 0f);
        }
        */
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            if (movementY >= 0.9f && portalUseable == true)
            {
                other.GetComponent<PortalController>().UsePortal(this.gameObject);
                portalUseable = false;
                StartCoroutine("PortalDelay");
            }
        }
    }

    IEnumerator PortalDelay()
    {
        yield return new WaitForSeconds(portalDelay);
        portalUseable = true;
    }
}
