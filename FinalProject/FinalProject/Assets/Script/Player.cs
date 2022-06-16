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
    
    public bool isHit;
    public bool Usedgun;
    public GameObject bulletobj;

    private float limittime;

    public float maxShotDelay;
    public float curShotDelay;

    public GameManager manager;

    Animator anim;
    SpriteRenderer spriteRenderer;
    GameManager gameManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        limittime = 5f;
    }

    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        float time = gameManager.gTime;

        if (time <= 10)
            speed = 4.0f;

        else if (time > 10 && time <= 30)
            speed = 4.2f;

        else if (time > 30 && time <= 60)
            speed = 4.4f;

        else if (time > 60 && time <= 90)
            speed = 4.6f;

        Move();

        if (Usedgun == true)
        {
            limittime -= Time.deltaTime;
            Fire();
        }

        if (limittime < 0f)
        {
            Usedgun = false;
            limittime = 5f;
        }

        Reload();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;
        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, 0, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)h);
        }
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

        else if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet") //���ʹ̴� ��, ���ʹ̺ҷ��� �Ѿ�
        {
            if (isRespawnTime) //���� �ð��̸� ������ ���� ����
                return;

            //if (isHit) //�̹� �������¿��� �ٷ� ������ ������ ���� ����,�ߺ� �� �������� �ѹ��� �������� ����
            //    return;

            manager.RespawnPlayer();
            gameObject.SetActive(false);
            Debug.Log(collision.gameObject.tag);

            isHit = true;
        }

        else if (collision.gameObject.tag == "Item")
        {
            Usedgun = true;
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

    void OnEnable()
    {
        Unbeatable();

        Invoke("Unbeatable", 3);
    }

    void Unbeatable()
    {
        isRespawnTime = !isRespawnTime;

        if (isRespawnTime) //���� Ÿ�� ����Ʈ (����)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1); //���� Ÿ�� ����(�������)
        }
    }
}