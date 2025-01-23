using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
  
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;
    private Animation anim;
    public float moveSpeed = 10.0f;

    public float turnSpeed = 80.0f;

    void Start()
    {
        // Transform 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.Play("Idle");
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        //Debug.Log("h="+h);
        //Debug.Log("v="+v);

        //Transform 컴포넌트의 position 속성값을 변경
        //transform.position += Vector3.forward*1;
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
        PlayerAnim(h,v);
    }
    void PlayerAnim(float h, float v)
    {
        if (v>=0.1f)
        {
            anim.CrossFade("RunF",0.25f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB",0.25f);
        }
        else if (h>=0.1f)
        {
            anim.CrossFade("RunR",0.25f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL",0.25f);
        }
        else
        {
             anim.CrossFade("Idle",0.25f);
        }
    }
}
