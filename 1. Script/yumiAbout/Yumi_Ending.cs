using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yumi_Ending : MonoBehaviour
{
    /*���º���*/
    Vector3 pos;
    bool isWall = false;
    bool isGuardMeet = false;
    public float speed = 5;

    /*raycast hit����*/
    GameObject scanObj1;
    GameObject scanObj2;
    GameObject scanObj3;

    /*ĳ�̺���*/
    private Rigidbody yumiRigid;
    Animator yumAnim;

    /*�ܺκ���*/
    public Camera yumiSightCam;
    public endingDialogManage dialogManage;

    /*�ڷ�ƾ*/
    IEnumerator playerStop;
    void Start()
    {
        yumiRigid = GetComponent<Rigidbody>();
        yumAnim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        pos = transform.position;
        //RayShot();
        /*���� Ÿ�� ���� ��*/
        if (Input.GetKeyDown(KeyCode.Space) && scanObj1 != null && dialogManage.talkEnd)
        {
            dialogManage.Search1(scanObj1);
        }
        /*ó�� ���带 ������ ��*/
        if (Input.GetKeyDown(KeyCode.Space) && scanObj2 != null&& !isGuardMeet&& dialogManage.scanObject1==null)
        {
            dialogManage.Search2(scanObj2);
            isGuardMeet = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && scanObj3 != null)
        {
            dialogManage.Search3(scanObj3);
        }
    }
    void FixedUpdate()
    {
        /*������ ����*/
        float m_mouseX = Input.GetAxis("Mouse X") * 15;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical") * 0.8f;
        Vector3 moveVec = new Vector3(h, 0, v).normalized;
        yumAnim.SetBool("isWalk", moveVec != Vector3.zero);
        if (!isWall)
        {
            transform.Translate(moveVec * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * Time.deltaTime * m_mouseX);
        }
        /*����ĳ��Ʈ*/
        Debug.DrawRay(yumiRigid.position, transform.forward * 1f, new Color(0, 1, 0));
        RaycastHit hit;

        if (Physics.Raycast(yumiRigid.position, transform.forward * 1f, out hit, 1f, 1 << LayerMask.NameToLayer("StoryItem2")))
            scanObj2 = hit.collider.gameObject;
        else
            scanObj2 = null;

        if (Physics.Raycast(yumiRigid.position, transform.forward * 1f, out hit, 1f, 1 << LayerMask.NameToLayer("StoryItem")))
            scanObj1 = hit.collider.gameObject;
        else
            scanObj1 = null;


    }

    //void RayShot()
    //{
    //if(Input.GetKeyDown(KeyCode.Space)&& scanObj!=null)
    //{
    //    dialogManage.Action(scanObj);
    //    Debug.Log("This is : " + scanObj.name);
    //    RaycastHit hit;
    //    if (Physics.Raycast(yumiRigid.position, transform.forward * 1f, out hit, 1f, 1 << LayerMask.NameToLayer("StoryItem")))
    //    {
    //        scanObj = hit.collider.gameObject;
    //    }
    //    else
    //        scanObj = null;
    //}
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall" || collision.gameObject.layer == LayerMask.NameToLayer("StoryItem"))
        {
            isWall = true;
            transform.position = pos;
            Invoke("OutOfWall", 0.1f);
        }
    }

    void OutOfWall()
    {
        isWall = false;
    }


}
