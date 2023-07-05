using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
   // public Transform targetPosition;

    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public bool isActive = false;
    public float transX = 0;
    public int sceneCnt = 1;
    public AudioSource audioObj;
    public AudioClip[] audioSources;
    public SettingWindow win;

    private void Start()
    {
        audioObj = this.GetComponent<AudioSource>();
        audioSources = new AudioClip[2];
        audioSources[0] = (AudioClip)Resources.Load("BytheFireplace-AudioTrim");
        audioSources[1] = (AudioClip)Resources.Load("Forest Lullabye - AudioTrim");
        audioObj.clip = (AudioClip)audioSources[0];
        //audioObj.Play();
    }
    
    
    
    private void Update()
    {
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && isActive == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) ChangeAudio(0, audioSources[0]);
            else if (Input.GetKey(KeyCode.RightArrow)) ChangeAudio(26f, audioSources[1]);
        }
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && isActive == false)
        {
            isActive = true;
            if (Input.GetKey(KeyCode.LeftArrow)) ChangeAudio(0, audioSources[0]);
            else if (Input.GetKey(KeyCode.RightArrow)) ChangeAudio(26f, audioSources[1]);
        }


        if (Input.GetKey(KeyCode.Escape))
        {
            win.SettingBtnClick();
        }


        Moving(transX);

    }

    private void ChangeAudio(float x, AudioClip clip)
    {
        transX = x;
        audioObj.clip = clip;
    }
    public void Moving(float transX)
    {   
        if(isActive)
        {   
            if(audioObj.isPlaying) audioObj.Pause();

            Vector3 target = new Vector3(transX, Camera.main.transform.position.y, Camera.main.transform.position.z);
            Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, target, ref velocity, smoothTime);
            if (Vector3.Distance(target, Camera.main.transform.position) < 0.1f)
            {
                isActive = false;
            }
        } else
        {
            if (!audioObj.isPlaying) audioObj.Play();
        }
        
    }
}