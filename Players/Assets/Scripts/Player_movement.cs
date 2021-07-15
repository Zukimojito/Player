using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_movement : MonoBehaviour
{
    [SerializeField]private float MoveSpeed;
    
    private float RotationSpeed;
    private float LastTimeInput;
    private const float double_input_time = 1f;

    private Animator animation;
    
    void Start()
    {
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var MoveIntent = Vector3.zero;
        float RotationIntent = 0f;
        
        if (Input.GetKey(KeyCode.Z))
        {
            /*
            float timeSincelastinput = Time.time - LastTimeInput;

            if (timeSincelastinput <= double_input_time)  //double Z
            {
                MoveIntent += new Vector3(0,0,10);
            }
            else
            {
             MoveIntent += Vector3.forward;
            }
        */
            animation.SetBool("walk",true);
            MoveIntent += Vector3.forward;
            LastTimeInput = Time.time;

        }
        else
        {
            animation.SetBool("walk",false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animation.SetBool("walk",true);
            MoveIntent += Vector3.back;
        }
        else
        {
            animation.SetBool("walk",false);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            MoveIntent += Vector3.left;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            MoveIntent += Vector3.right;
        }

        MoveIntent = MoveIntent.normalized;
        
        transform.Rotate(0f,RotationIntent * Time.deltaTime * RotationSpeed,0f);
        transform.position += transform.rotation * MoveIntent * MoveSpeed * Time.deltaTime;
    }
}
