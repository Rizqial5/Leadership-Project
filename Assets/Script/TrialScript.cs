using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialScript : MonoBehaviour
{
    [SerializeField] float zoomSpeed = 10;
    [SerializeField] float zoomOutBoundary = 7;
    [SerializeField] float zoomInBoundary = 2;


    private bool isCameraStop;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (isCameraStop) return;
        ZoomController();
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 5f * Time.deltaTime);
        }else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * 5f * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }else if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }

        
    }

    private void ZoomController()
    {
        if (Input.mouseScrollDelta.y <= 0f)
        {
            if(!ZoomOutBoundary(zoomOutBoundary)) return;

            ZoomMovement(zoomSpeed);
        }
        if (Input.mouseScrollDelta.y >= 0f)
        {
            if(!ZoomInBoundary(zoomInBoundary)) return;
            
            ZoomMovement(-zoomSpeed);
        }
    }

    private bool ZoomOutBoundary(float zoomOut)
    {
        if(Camera.main.orthographicSize >= zoomOut)
        {
            return false;
        }
        return true;
    }

    private bool ZoomInBoundary(float zoomIn)
    {
        if(Camera.main.orthographicSize <= zoomIn )
        {
            return false;
        }
        return true;
    }

    public void ZoomMovement(float speed)
    {
        Camera.main.orthographicSize += speed * Time.deltaTime;
    }

    public void SetCameraStop(bool isStop)
    {
        isCameraStop = isStop;
    }
}
