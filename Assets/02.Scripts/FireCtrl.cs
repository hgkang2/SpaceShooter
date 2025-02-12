using System;
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
    private MeshRenderer muzzleFlash;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
        //처음 시작할 때 비활성화
        muzzleFlash.enabled = false;
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
        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerable ShowMuzzleFlash()
    {
        //MuzzleFlash 활성화
        muzzleFlash.enabled = true;
        //0.2초 동안 대기 (제어권 양보)
        yield return new WaitForSeconds(0.2f);
        //MuzzleFlash 비활성화
        muzzleFlash.enabled = false;
    }
}
