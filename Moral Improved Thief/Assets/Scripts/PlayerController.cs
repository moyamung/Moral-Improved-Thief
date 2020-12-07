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

    public void OnJump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jump, _rigidbody.velocity.z);
    }

    public void OnInteract()
    {
        //interaction with something
        RaycastHit hitInfo;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position, Vector3.forward, out hitInfo, 100f, mask))
        {
            hitInfo.collider.gameObject.SendMessage("OnInteraction");
        }
    }

    public void OnFire()
    {
        //attack action
    }

    public void OnSkill()
    {
        //skill use
    }

    public void OnChangeMode()
    {
        //Mode change
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
