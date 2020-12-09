using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    private Rigidbody _rigidbody;

    float movementX;
    float movementY;
    float speed = 4.0f;
    float jump = 9f;
    const float portalDelay = 0.3f;
    const float hitDelay = 3f;
    const float rifleDelay = 0.3f;
    const float missileDelay = 2f;

    public float maxHp;
    public float hp;

    public GameObject rifleBullet;
    public GameObject missile;

    bool portalUseable;
    bool hitable;
    bool rifleShootAble;
    bool missileShootAble;

    float changetype;

    //액션 모드를 저장하는 변수, 0, 1, 2의 값을 가질 수 있고 기본 상태는 0에서 시작
    int actiontype = 0;

    bool isDead, needtoidle, isFire, isMissile, isPunch, isCharge, isSmash, isHacking;

    int DeadHash, needtoidleHash, isFireHash, isMissileHash, isPunchHash, isChargeHash, isSmashHash, isHackingHash;
    
    bool Hit, isJump, isGround, seeRight;

    float movex, movey;


    int HitHash, movexHash, moveyHash, isJumpHash;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        portalUseable = true;
        hitable = true;
        rifleShootAble = true;
        missileShootAble = true;
        isDead = false;

        DeadHash = Animator.StringToHash("Dead");
        needtoidleHash = Animator.StringToHash("needtoidle");
        isFireHash = Animator.StringToHash("isFire");
        isMissileHash = Animator.StringToHash("isMissile");
        isPunchHash = Animator.StringToHash("isPunch");
        isChargeHash = Animator.StringToHash("isCharge");
        isSmashHash = Animator.StringToHash("isSmash");
        isHackingHash = Animator.StringToHash("isHacking");
        HitHash = Animator.StringToHash("Hit");
        movexHash = Animator.StringToHash("movex");
        moveyHash = Animator.StringToHash("movey");
        isJumpHash = Animator.StringToHash("isJump");

        isGround = true;
        seeRight = true;

        hp = maxHp;
    }

    public void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void OnJump()
    {
        if (!isGround) return;
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jump, _rigidbody.velocity.z);
        isJump=true;
    }

    public void OnInteract()
    {
        //interaction with something
        RaycastHit hitInfo;
        int mask = 1 << 10;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.forward, out hitInfo, 2f, mask))
        {
            hitInfo.collider.gameObject.SendMessage("OnInteraction");
        }
    }

    public void OnFire()
    {
        //attack action
        if (!rifleShootAble) return;
        GameObject bullet = Instantiate(rifleBullet, this.transform.position + Vector3.forward * 0.3f + Vector3.up, Quaternion.identity);
        bullet.transform.up = this.transform.forward;
        rifleShootAble = false;
        isFire = true;
        StartCoroutine("RifleDelay");
        /*
        switch(actiontype)
        {
            case 0:
                isFire = true;
                break;
            case 1:
                isPunch = true;
                break;
            case 2:
                isSmash = true;
                break;
        }
        */
    }

    public void OnSkill()
    {
        //skill use
        if (!missileShootAble) return;
        GameObject miss = Instantiate(missile, this.transform.position + Vector3.forward * 0.3f + Vector3.up, Quaternion.identity);
        miss.transform.up = this.transform.forward;
        missileShootAble = false;
        isMissile = true;
        StartCoroutine("MissileDelay");
        /*
        switch(actiontype)
        {
            case 0:
                isMissile = true;
                break;
            case 1:
                isCharge = true;
                if (seeRight)
                {
                    _rigidbody.velocity = new Vector3(9f, _rigidbody.velocity.y, _rigidbody.velocity.z);
                    //_rigidbody.AddForce(new Vector3(0f, 0f, 4f));
                }
                else
                {
                    _rigidbody.velocity = new Vector3(-9f, _rigidbody.velocity.y, _rigidbody.velocity.z);
                    //_rigidbody.AddForce(new Vector3(0f, 0f, -4f));
                }
                break;
            case 2:
                isHacking = true;
                OnInteract();
                break;
        }
        */
    }

    public void OnChangeMode(InputValue context)
    {
        //Mode change
        //Debug.Log("ModChange");
        return;
        /*
        changetype = context.Get<float>();
        if(changetype < 0)
        {
            actiontype = actiontype - 1;
            if(actiontype < 0)
            {
                actiontype = 2;
            }
        }

        else if(changetype > 0)
        {
            actiontype = actiontype + 1;
            if(actiontype > 2)
            {
                actiontype = 0;
            }
        }*/
    }

    void GroundCheck()
    {
        if (Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.4f))
        {
            isGround = true;
            return;
        }
        else isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(horizontal, 0f, 0f);
        //_rigidbody.AddForce(new Vector3(movementX, 0f, 0f) *  speed);
        //transform.Translate(new Vector3(0f, 0f, movementX) * speed * Time.deltaTime);
        _rigidbody.velocity = new Vector3(movementX * speed, _rigidbody.velocity.y, _rigidbody.velocity.z);
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.velocity += new Vector3(0f, jump, 0f);
        }
        */
        if(isDead = true || movementX == 0)
        {
            needtoidle = true;
        }


        GroundCheck();
        //movex = _rigidbody.velocity.x;
        if (_rigidbody.velocity.x < 0.1f && _rigidbody.velocity.x > -0.1f) movex = 0f;
        else movex = 1f;
        movey = 0f;

        animator.SetBool(DeadHash, isDead);
        animator.SetBool(needtoidleHash, needtoidle);
        animator.SetBool(isFireHash, isFire);
        animator.SetBool(isMissileHash, isMissile);
        animator.SetBool(isPunchHash, isPunch);
        animator.SetBool(isChargeHash, isCharge);
        animator.SetBool(isSmashHash, isSmash);
        animator.SetBool(isHackingHash, isHacking);
        animator.SetBool(HitHash, Hit);
        animator.SetFloat(movexHash, movex);
        animator.SetFloat(moveyHash, movey);
        animator.SetBool(isJumpHash, isJump);
        animator.SetBool("isGround", isGround);
        animator.SetBool("seeRight", seeRight);

        isFire = false;
        isMissile = false;
        isPunch = false;
        isCharge = false;
        isSmash = false;
        isHacking = false;
        isJump=false;

        if(isDead == false)
        {
            Hit = false;
        }


        if (movementX > 0.9f && seeRight == false)
        {
            transform.Rotate(new Vector3(0f, 180f, 0f));
            seeRight = true;
        }
        if (movementX < -0.9f && seeRight == true)
        {
            transform.Rotate(new Vector3(0f, 180f, 0f));
            seeRight = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            if (movementY >= 0.9f && portalUseable == true)
            {
                if (other.GetComponent<LobbyPortal>())
                {
                    other.GetComponent<LobbyPortal>().UsePortal(this.gameObject);
                    return;
                }
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

    IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(hitDelay);
        hitable = true;
    }

    IEnumerator RifleDelay()
    {
        yield return new WaitForSeconds(rifleDelay);
        rifleShootAble = true;
    }

    IEnumerator MissileDelay()
    {
        yield return new WaitForSeconds(missileDelay);
        missileShootAble = true;
    }

    void Dead()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm.nowstage == 4) SceneManager.LoadScene("LastEndingFailure");
        else SceneManager.LoadScene("DeadEnd");
    }

    public void OnHit(float damage)
    {
        if (!hitable) return;
        hp -= damage;
        Hit = true;
        if (hp <= 0) Dead();
        hitable = false;
        StartCoroutine("HitDelay");
    }
}
