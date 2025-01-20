using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;

    void Start()
    {
        // Transform 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h="+h);
        Debug.Log("v="+v);

        //Transform 컴포넌트의 position 속성값을 변경
        transform.position += Vector3.forward*1;
    }
}
