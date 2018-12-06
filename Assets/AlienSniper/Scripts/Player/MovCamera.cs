using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovCamera : MonoBehaviour {

    public float posJoistyckX;
    public float posJoistyckY;
    public float secibility;
    private LeftJoystick leftJoystick;
    private Vector3 leftJoystickInput;
    Vector3 limiteYp;
    Vector3 limiteYn;
    public float valorLimite;

    void Start () {
        leftJoystick = FindObjectOfType<LeftJoystick>();
        limiteYp.y = -30f;
        limiteYn.y = 60f;
    }
	
	void Update () {
        MovCam();
        if (FindObjectOfType<ZoomCamera>().active_Zoom == true)
            secibility = 5f;
        else
            secibility = 60f;
    }

    public void MovCam()
    {
        leftJoystickInput = leftJoystick.GetInputDirection();

        posJoistyckX += leftJoystickInput.x * secibility * Time.deltaTime;
        posJoistyckY -= leftJoystickInput.y * secibility * Time.deltaTime;

        if (posJoistyckY <= limiteYp.y)
            valorLimite = limiteYp.y;
        else if (posJoistyckY >= limiteYn.y)
            valorLimite = limiteYn.y;
        else
            valorLimite = posJoistyckY;

        transform.eulerAngles = new Vector3(valorLimite, posJoistyckX, 0);
    }
}
