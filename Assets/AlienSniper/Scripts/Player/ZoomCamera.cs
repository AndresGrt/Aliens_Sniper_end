using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomCamera : MonoBehaviour
{
    public bool active_Zoom;
    public Image lente;
    public Image sight;
    private Camera cam;
    public float max_Zoom = 60f;
    public float min_Zoom = 5f;

    private void Start()
    {
        cam = Camera.FindObjectOfType<Camera>();
    }
    void Update () {
        if (active_Zoom)
        {
            cam.fieldOfView -= 500 * Time.deltaTime;
            if (cam.fieldOfView <= min_Zoom && active_Zoom)
            {
                cam.fieldOfView = min_Zoom;
            }
        }
        else
        {
            cam.fieldOfView += 500 * Time.deltaTime;
            if (cam.fieldOfView >= max_Zoom && !active_Zoom)
            {
                cam.fieldOfView = max_Zoom;
            }
        }
    }
    public void Play_Zoom()
    {
        if (active_Zoom)
            active_Zoom = false;
        else
            active_Zoom = true;
        lente.enabled = !lente.enabled;
        sight.enabled = !sight.enabled;
    }
}
