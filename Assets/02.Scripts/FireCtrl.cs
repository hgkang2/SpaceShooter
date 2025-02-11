using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//반드시 필요한 컴포턴트를 삭제 안되도록 하는 어트리트뷰
[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public AudioClip firesfx;
    private new AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        audio.PlayOneShot(firesfx, 1.0f);
    }
}
