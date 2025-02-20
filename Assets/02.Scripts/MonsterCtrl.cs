using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
public class MonsterCtrl : MonoBehaviour
{
    //해시값 추출
    private readonly int hashTrace = Animator.StringToHash("IsTrace");
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    private readonly int hashHit = Animator.StringToHash("Hit");
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE
    }
    public State state = State.IDLE;
    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    public bool isDie = false;
    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent agent;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //agent.destination = playerTr.position;
        //몬스터의 상태를 체크라는 코루틴 함수 호출
        StartCoroutine(CheckMonsterState());
        //상태에 따라 몬스터의 행동을 수행하는 코루틴 함수 호출
        StartCoroutine(MonsterAction());
    }
    IEnumerator CheckMonsterState()
    {
        while(!isDie)
        {
            //0.3초 대기하는 동안 제어권 넘김
            yield return new WaitForSeconds(0.3f);
            //몬스터와 주인공 캐릭터 사이의 거리 측정
            float distance = Vector3.Distance(playerTr.position,monsterTr.position);
            //공격 사정거리 범위로 들어왔는지 확인
            if (distance <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (distance <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }
        }
    }
     IEnumerator MonsterAction()
    {
        while(!isDie)
        {
            switch(state)
            {
            case State.IDLE:
            agent.isStopped = true;
            anim.SetBool(hashTrace,false);
            break;
            case State.TRACE:
            agent.SetDestination(playerTr.position);
            agent.isStopped = false;
            anim.SetBool(hashTrace,true);
            anim.SetBool(hashAttack,false);
            break;
            case State.ATTACK:
            anim.SetBool(hashAttack, true);
            break;
            case State.DIE:
            break;

        }
            yield return new WaitForSeconds(0.3f);
    }
}
    void OnDrawGizmos()
    {
        //추적 사정거리 표시
        if (state == State.TRACE)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position,traceDist);
        }        
        if(state == State.ATTACK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,attackDist);
        }
    }
}
