using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeBehaviour : MonoBehaviour
{

    private bool gyroEnabled;
    private Gyroscope gyro;

    public float rollSpeed = 10;
    float MaxAngle = 35;


    // Start is called before the first frame update
    void Start()
    {


        gyroEnabled = EnabledGyro();
    }

    private bool EnabledGryo()
    {
        if (SystemInfo.supportGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 rotation = new Vector3(); ;
        rotation.x = gyro.gravity.x * MaxAngle;
        rotation.y = gyro.gravity.y * MaxAngle;

        transform.eulerAngles = rotation;
    }
}
