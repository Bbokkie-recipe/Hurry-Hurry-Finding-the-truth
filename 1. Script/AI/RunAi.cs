using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RunAi : MonoBehaviour
{
    //enum으로 상태
    public enum AiState
    {
        Run,
        Jump
    }

    float manSpeed;
    public Transform[] target;
    private NavMeshAgent agent;
    int nextTarget=0;
    private Transform AiTarget;
    IEnumerator AiMove;
    IEnumerator AiAni;
    private Animator manAni;

    /*yumi*/
    public GameObject Yumi;
    public yumiRun YumiSc;

    /*countDown UI 스크립트 불러와서 isGo가 True일때 출발*/
    CountDown countDownText;

    void Start()
    {
        YumiSc = GetComponent<yumiRun>();
        countDownText = GameObject.Find("countDownimg").GetComponent<CountDown>();
        IEnumerator AiAni = PoliceAni();
        manAni = GetComponent<Animator>();

        AiTarget = target[0];
        agent= GetComponent<NavMeshAgent>();
        //agent.speed = manSpeed;

        StartCoroutine(AiAni);
    }

    void Update()
    {
            if (CountDown.isGo)
        {
            if ((Yumi.transform.position - transform.position).magnitude < 1)
            {
                agent.SetDestination(Yumi.transform.position);

            }
            else if(Yumi.transform.position.z <=transform.position.z)
             {
                agent.SetDestination(Yumi.transform.position);
            }
            else
            {
                agent.SetDestination(AiTarget.position);
            }
        }
}

    //상태에 따른 애니메이션
    public IEnumerator PoliceAni()
    {
        WaitForSeconds _waitForSeconds = new WaitForSeconds(0.03f);
        Vector3 lastPos;
        while(true)
        {
            lastPos = transform.position;
            yield return _waitForSeconds;
            if((lastPos-transform.position).magnitude>0)
            {
                Vector3 dir = transform.InverseTransformPoint(lastPos);
                if(dir.x>=-0.01f&&dir.x<=0.01f)
                    manAni.Play("Run01_Forwards");
                if (dir.x < -0.01f)
                    manAni.Play("Run01ForwardsRight");
                if (dir.x > 0.01f)
                    manAni.Play("Run01ForwardsLeft");
            }
                yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "fireball")
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
