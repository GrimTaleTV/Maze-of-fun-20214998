using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GyroscopeBehaviour : MonoBehaviour
{

    private bool gyroEnabled;
    private UnityEngine.Gyroscope gyro;

    float MaxAngle = 35;
    float speed = 10;
    private Rigidbody _body;

    private Quaternion quatRot;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();

        gyroEnabled = EnabledGryo();
    }

    private bool EnabledGryo()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Portrait;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            Debug.LogError("Enabled");
        }


        return false;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 rotation = new Vector3();
        if (gyro != null)
        {
            rotation = transform.right * gyro.gravity.y
                + transform.forward * -gyro.gravity.x;

            rotation = rotation.normalized * speed;

            // Debug.Log("X: " + rotation.x + ", Y" + rotation.y);
            Debug.Log(rotation);
        }

        if(Mathf.Abs(_body.velocity.magnitude) < speed)
            _body.velocity += rotation * Time.deltaTime;
    }
}
