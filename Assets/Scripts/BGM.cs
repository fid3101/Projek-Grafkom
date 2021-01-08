﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject bgmOn;
    public GameObject bgmOff;
    public static bool isMuted;
    public static bool isStopping;
    public static AudioSource bgm;
    public static BGM instance = null;
    void Start()
    {
        isMuted = false;
        isStopping = false;
        bgm = GetComponent<AudioSource>();
    }
    void Awake(){
        if(instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Update(){
        if(isStopping){
            bgmOn.gameObject.SetActive(false);
            bgmOff.gameObject.SetActive(false);
        } else if (!isStopping && isMuted){
            bgmOn.gameObject.SetActive(false);
            bgmOff.gameObject.SetActive(true);
        } else if (!isStopping && !isMuted){
            bgmOn.gameObject.SetActive(true);
            bgmOff.gameObject.SetActive(true);
        }
        
    }

    public void Mute(){
        SoundManager.PlaySound("buttonClick");
        isMuted = !isMuted;
        bgm.enabled = !isMuted;
        bgmOn.gameObject.SetActive(false);
    }

    public void unMute(){
        SoundManager.PlaySound("buttonClick");
        isMuted = !isMuted;
        bgm.enabled = !isMuted;
        bgmOn.gameObject.SetActive(true);
    }

    public static void StopBGM(){
        bgm.enabled = false;
        isStopping = true;   
    }
    public static void StartBGM(){
        if(!isMuted) bgm.enabled = true;
        else bgm.enabled = false;
        isStopping = false;
    }
}