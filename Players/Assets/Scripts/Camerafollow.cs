using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private float distance = 20f;
    private float hauteur = 20f;
    
    private Transform lookAt;
    private Transform camTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        camTransform = Camera.main.transform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        TargetFollow();
    }

    private void TargetFollow()
    {
        transform.LookAt(target);
        transform.position = new Vector3(target.position.x,target.position.y + hauteur,target.position.z - distance);
    }
    
}
