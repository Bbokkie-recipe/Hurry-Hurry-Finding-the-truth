using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class yumiRun : MonoBehaviour
{
    public enum YumiState
    {
        Idle,
        Run,
        Accel_Run,
        Jump,
        Crouch,
        Die
    }

    /*���� ����*/
    YumiState yumiState;
    public int curHeart = 3;
    private int maxHeart = 3;
    public bool isDead = false;
    private bool isJump = false;
    private bool isGround = true;
    private bool isShielding = false;
    private bool isfianlGoal = false;

    /*�ӵ� ����*/
    float yumiSpeed;
    float yumiRunSpd = 15f;
    float yumiAccelSpd = 150f;
    //float yumiRunSpd = 25f;
    //float yumiAccelSpd = 250f;

    /*����*/
    private float jumpForce=5.8f;

    /*��ġ ����*/
    public Transform target;
    private NavMeshAgent yumiAgent;
    int nextTarget = 0;
    private Transform yumiTarget;

    /*ĳ�̺���*/
    Vector3 pos;
    Vector3 startPos;
    //float prevZ;
    Rigidbody yumiRigid;
    Transform player;
    CapsuleCollider yumiCollider;
    private Animator girlAnim;
    AudioSource heartAudio;

    /*�ڷ�ƾ ĳ�̺���*/
    IEnumerator playerMove;
    IEnumerator playerAni;
    IEnumerator playerCheck;
    IEnumerator playerSound;
    IEnumerator playerStop;

    /*�ִϸ����� ���ڿ� Hash*/
    private readonly int hasRun = Animator.StringToHash("isRun");
    private readonly int hasDeath = Animator.StringToHash("isDeath");
    private readonly int hasJump = Animator.StringToHash("isJump");
    private readonly int hasCrouch = Animator.StringToHash("isCrouch");

    /*countDown UI ��ũ��Ʈ �ҷ��ͼ� isGo�� True�϶� ���*/
    CountDown countDownText;

    /*������ ���̾ ������*/
    public GameObject fireball;

    private void Awake()
    {
        startPos = transform.position;
    }
    void Start()
    {
        countDownText = GameObject.Find("countDownimg").GetComponent<CountDown>();
        YumiState yumiState = YumiState.Idle;
        player = GetComponent<Transform>();
        yumiRigid= GetComponent<Rigidbody>();
        yumiCollider = GetComponent<CapsuleCollider>();
        heartAudio = GetComponent<AudioSource>();

        //StartCoroutine("playerMove");
        //playerMove = yumiMove();
        playerAni = yumiAni();
        playerCheck = yumiCheck();
        playerSound = yumiSound();
        girlAnim = GetComponent<Animator>();

        /*nav ����*/
        yumiTarget= target;
        yumiAgent = GetComponent<NavMeshAgent>();
        yumiSpeed = yumiRunSpd;
        yumiAgent.speed = yumiSpeed;
        //yumiAgent.SetDestination(yumiTarget.position);

        /*�ڷ�ƾ ����*/
        //StartCoroutine(playerMove);
        StartCoroutine(playerCheck);
        StartCoroutine(playerAni);
        StartCoroutine(playerSound);
    }

    private void Update()
    {
        pos = transform.position;
        if (CountDown.isGo)
        {
            HeartCheck();
            if (isDead == true) yumiSpeed = 0;
            Debug.Log("������Ʈ ������ ���� ������" + pos);
            Jump();
            Move();
            Debug.Log("������Ʈ ������ ���� ������" + transform.position);
            Debug.Log("������Ʈ ������ ���� isJump: " + isJump);
        }
    }

    void HeartCheck()
    {
        if (curHeart <= 0)
        {
            StopAllCoroutines();
            player.GetChild(7).gameObject.SetActive(true);//Die sound
            girlAnim.SetBool(hasDeath, true);
            isDead = true;
            Invoke("yumiDie", 3f);
        }
    }

    void yumiDie()
    {
        gameObject.SetActive(false);
    }

    void Jump()
    {
        /*Jump Animator*/
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            yumiState = YumiState.Jump;
            player.GetChild(5).gameObject.SetActive(true);//jump sound
            Debug.Log("���� ���ڸ��� isJump: " + isJump);
            yumiRigid.velocity = transform.up * jumpForce;
            girlAnim.SetBool("isJumping", true);
            girlAnim.SetTrigger("doJump");
        }
        //�����ÿ��� ���� https://youtu.be/BjkVJq-hSH8
    }

    /*accelItem*/
    public void Accel()
    {
        yumiSpeed = yumiAccelSpd;
        Invoke("AccelCancel", 0.5f);
    }

    private void AccelCancel()
    {
        yumiSpeed = yumiRunSpd;
    }

    /*heartitem*/
    public void HeartUp()
    {
        if (curHeart < maxHeart) curHeart++;
        if (curHeart >= maxHeart) curHeart = maxHeart;
    }


    /*shieldItem*/
    public void Shielding()
    {
        isShielding = true;
        player.GetChild(8).gameObject.SetActive(true);//Shield particle
        Invoke("ShieldCancel", 3f);
    }

    private void ShieldCancel()
    {
        player.GetChild(8).gameObject.SetActive(false);//Shield particle
        isShielding = false;
    }

    /*fireworkItem*/
    public void Firework()
    {
        Debug.Log("�����");
        GameObject Fireball = Instantiate(fireball, transform.position,Quaternion.identity);
        Debug.Log("�����");
    }


    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal") * 0.25f * Time.deltaTime * yumiSpeed;
        float _moveDirZ = Input.GetAxisRaw("Vertical") * 0.75f * Time.deltaTime * yumiSpeed;

        //Vector3 _moveHorizontal = transform.right * _moveDirX*Time.deltaTime*yumiSpeed;
        //Vector3 _moveVertical = transform.forward * _moveDirZ*Time.deltaTime*yumiSpeed;

        //Vector3 _velocity =  (_moveHorizontal+_moveVertical).normalized;

        Debug.Log("������Ʈ ���� Move ���� ������" + transform.position);
        Debug.Log("������Ʈ ���� Move�� moveDirZ" + _moveDirZ);
        transform.position = new Vector3(transform.position.x+ _moveDirX, transform.position.y, transform.position.z+ _moveDirZ);
      //  yumiRigid.MovePosition(transform.position + _velocity);
        Debug.Log("������Ʈ ���� Move ���� ������" + transform.position);

    }

    /*���� ���� üũ*/
    public IEnumerator yumiCheck()
    {
        while (true)
        {
           // lastPos = transform.position;
          
            Debug.Log("������Ʈ - �ڷ�ƾ ���� ������ : " + pos);
            Debug.Log("������Ʈ - �ڷ�ƾ ���� ������ : " + transform.position);
            Debug.Log("������Ʈ - �ڷ�ƾ magnitude" + (pos - transform.position).magnitude);

            if ((pos - transform.position).magnitude > 0)
            {
                Debug.Log("������Ʈ-if����");
              //  Vector3 dir = transform.InverseTransformPoint(pos);
                yumiState = YumiState.Run;
                /*
                if (yumiSpeed == yumiAccelSpd)
                {
                    yield return waitForSeconds;
                    yumiSpeed = yumiRunSpd;
                    break;
                }*/
            }
        else
                yumiState = YumiState.Idle;
            yield return null;
        }
    }

    /*���¿� ���� ����*/
    public IEnumerator yumiSound()
    {
        while (true)
        {
            if (isJump == true)
            {
                player.GetChild(4).gameObject.SetActive(false);//run sound
                player.GetChild(6).gameObject.SetActive(false);//item sound
            }
            else
            {
                switch (yumiState)
                {
                    case YumiState.Idle:
                        player.GetChild(4).gameObject.SetActive(false);//run sound
                        player.GetChild(5).gameObject.SetActive(false);//jump sound
                        //player.GetChild(6).gameObject.SetActive(false);//item sound
                        break;

                    case YumiState.Run:
                        yield return new WaitForSeconds(0.4f);
                        player.GetChild(4).gameObject.SetActive(true);//run sound
                        player.GetChild(5).gameObject.SetActive(false);//jump sound
                        //player.GetChild(6).gameObject.SetActive(false);//item sound
                        break;

                    //case YumiState.Accel_Run:
                    //    player.GetChild(4).gameObject.SetActive(true);//run sound
                    //    player.GetChild(5).gameObject.SetActive(false);//jump sound
                    //    player.GetChild(6).gameObject.SetActive(true);//item sound
                    //    break;


                    case YumiState.Crouch:
                        girlAnim.SetTrigger(hasCrouch);
                        break;

                    case YumiState.Die:
                        player.GetChild(4).gameObject.SetActive(false);//run sound
                        player.GetChild(5).gameObject.SetActive(false);//jump sound
                        //player.GetChild(6).gameObject.SetActive(false);//item sound
                        break;
                }
            }
            
            yield return null;
        }
    }

    /*���¿� ���� �ִϸ��̼�*/
    public IEnumerator yumiAni()
    {
        while (!isDead )
        {
            switch (yumiState)
            {
                case YumiState.Idle:
                    girlAnim.SetBool(hasRun, false);
                    break;

                case YumiState.Run:
                    girlAnim.SetBool(hasRun, true);
                    break;

                //case YumiState.Accel_Run:
                //    girlAnim.SetBool(hasRun, true);
                //    break;

                case YumiState.Jump:
                    break;

                case YumiState.Crouch:
                    girlAnim.SetTrigger(hasCrouch);
                    break;

                case YumiState.Die:
                    girlAnim.SetBool(hasDeath, true);
                    isDead = true;
                    break;
            }
            yield return null;
        }
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
            transform.position = pos;
        if (collision.gameObject.tag == "firstwall")
            transform.position = startPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "specialwall2")
        {
            pos -= new Vector3(1.3f, 0, 0);
            transform.position = pos;
        }
        if (other.gameObject.tag == "specialwall")
        {
            pos += new Vector3(1.5f, 0, 0);
            transform.position = pos;
        }
        if (other.gameObject.tag == "finaltouch")
        {
            isfianlGoal = true;
            StartCoroutine(DownSpeed());
        }
        if (other.gameObject.tag == "runitem")
        {
            player.GetChild(6).gameObject.SetActive(false);
            player.GetChild(6).gameObject.SetActive(true);//item sound
        }
        //Debug.Log("Detach: "+other.gameObject.layer);
        if (other.gameObject.layer == 8) 
            girlAnim.SetBool("isJumping", false);//Landing
            isJump = false;
            girlAnim.SetBool("isJumping", false);//Landing
            //isJump = false;

        //Debug.Log("ColliderCollider isJump: " + isJump);
        if (other.gameObject.tag == "Obstacle")
        {
            if (!isShielding)
            {
                curHeart--;
                if (curHeart >= 0) heartAudio.Play();
            }
        }
        Debug.Log("���� ��Ʈ����"+ curHeart);

        if (other.gameObject.tag == "spy")
        {
            if (!isShielding)
            {
                curHeart = 0;
            }
        }

    }

    public IEnumerator DownSpeed()
    {
        while(isfianlGoal)
        {
            if (yumiSpeed <= 0) yumiSpeed = 0;
            else yumiSpeed--;
            yield return new WaitForSeconds(0.21f);
        }
    }
}
