using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchLeft;
    public bool isTouchRight;
    public bool isRespawnTime;
    public bool LeftMove = false;
    public bool RightMove = false;
    Vector3 moveVelocity = Vector3.zero;
 
    public bool isHit;
    public bool Usedgun;
    public GameObject bulletobj;

    public Image atkDial;
    private float maxLimit = 5.0f;
    private float limittime;

    public float maxShotDelay;
    public float curShotDelay;

    public GameManager manager;

    public Slider hPBar;
    public float maxHP = 0.0f;
    private float minusHp = 0.0f;
    public float Damage;
    public float Healing;

    Animator anim;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        limittime = maxLimit;
    }

    void Start()
    {
        minusHp = 1 / maxHP;
        InvokeRepeating("fuelDown", 1, 1);
    }

    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        float time = gameManager.gTime;

        if (time <= 10)
            speed = 15.0f;

        else if (time > 10 && time <= 30)
            speed = 16.0f;

        else if (time > 30 && time <= 60)
            speed = 17.0f;

        else if (time > 60 && time <= 90)
            speed = 18.0f;

        Move();

        if (Usedgun == true)
        {
            limittime -= Time.deltaTime;
            atkDial.fillAmount = limittime / maxLimit;
            Fire();
        }

        if (limittime < 0f)
        {
            Usedgun = false;
            limittime = maxLimit;
        }

        Reload();

        if (hPBar.value <= 0)
        {
            gameManager.endGame();
            gameManager.gameOver();
        }
    }

    void Move()
    {
        if(gameObject.transform.position.x >= -3.5f)
        {
            if (LeftMove)
            {
                anim.SetBool("Direction", false);
                moveVelocity = new Vector3(-0.5f, 0, 0);
                transform.position += moveVelocity * speed * Time.deltaTime;
            }
        }
        
        if(gameObject.transform.position.x <= 3.5f)
        {
            if (RightMove)
            {
                anim.SetBool("Direction", true);
                moveVelocity = new Vector3(+0.5f, 0, 0);
                transform.position += moveVelocity * speed * Time.deltaTime;
            }
        }
        //float h = Input.GetAxisRaw("Horizontal");
        //if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
        //    h = 0;
        //float v = Input.GetAxisRaw("Vertical");
        //if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
        //    v = 0;
        //Vector3 curPos = transform.position;
        //Vector3 nextPos = new Vector3(h, 0, 0) * speed * Time.deltaTime;

        //transform.position = curPos + nextPos;

        //if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        //{
        //    anim.SetInteger("Input", (int)h);
        //}
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1"))
        {
            return;
        }

        if (curShotDelay < maxShotDelay)
            return;

        GameObject bullet = Instantiate(bulletobj, transform.position, transform.rotation);
        Rigidbody rigid = bullet.GetComponent<Rigidbody>();
        rigid.AddForce(Vector2.up * 10, ForceMode.Impulse);

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Debug.Log(collision.gameObject.tag);
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    Debug.Log(collision.gameObject.tag);
                    break;
                case "Right":
                    isTouchRight = true;
                    Debug.Log(collision.gameObject.tag);
                    break;

            }
        }

        else if (collision.gameObject.tag == "Enemy") //���ʹ̴� ��, ���ʹ̺ҷ��� �Ѿ�
        {
            OnDamaged();
        }

        else if (collision.gameObject.tag == "Item")
        {
            Usedgun = true;
        }
        else if (collision.gameObject.tag == "fuel")
        {
            hPBar.value += Healing;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }

    void OnDamaged()
    {
        gameObject.layer = 7;
        hPBar.value -= minusHp * Time.deltaTime;
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);

        Invoke("OnDamagedoff", 3);
    }
    void OnDamagedoff()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1); //���� Ÿ�� ����(�������)
        gameObject.layer = 8;
    }

    void fuelDown()
    {
        hPBar.value -= 1;
    }
}