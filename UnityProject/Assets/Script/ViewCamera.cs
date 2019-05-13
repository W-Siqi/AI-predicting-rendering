using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ViewCamera : MonoBehaviour {   
    [SerializeField]
    private float viewDistance=-1;
    [SerializeField]
    private GameObject viewCenter = null;
    [SerializeField]
    private float _viewAngle = 0;
    [SerializeField]
    private Camera camera = null;
   
    public static ViewCamera _instance = null;
    public static ViewCamera instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ViewCamera>();
            }

            return _instance;
        }
    }

    public float viewAngle {
        get {
            return ToRawAngle(_viewAngle);
        }
        set
        {
            var realAngle = ToRealAngle(value);
            if (_viewAngle != realAngle)
            {
                UpdateViewAngle(realAngle);
            }
        }
    }

    public void Render()
    {
        EditorUtility.SetDirty(this);
    }

    float ToRealAngle(float rawAngle)
    {
        var realAngle = rawAngle - 90f;
        if (realAngle < 0)
        {
            realAngle += 360f;
        }

        return realAngle;
    }

    float ToRawAngle(float realAngle)
    {
        var rawAngle = realAngle + 90f;
        if (rawAngle > 360)
        {
            rawAngle -= 360;
        }
        return rawAngle;
    }

    private void Start()
    {
        _instance = this;

        if (camera == null)
        {
            camera = GetComponent<Camera>();
        }

        if (viewDistance < 0)
        {
            viewDistance = (transform.position - viewCenter.transform.position).magnitude;
        }
    }

    private void Update()
    {
        camera.Render();
    }

    private void UpdateViewAngle(float newAngle)
    {
        _viewAngle = newAngle;

        var angleVal = newAngle * (Mathf.PI / 180f);

        Vector3 camRelativePos = new Vector3();
        camRelativePos.x = viewDistance * Mathf.Cos(angleVal);
        camRelativePos.y = transform.position.y-viewCenter.transform.position.y;
        camRelativePos.z = viewDistance * Mathf.Sin(angleVal);
        transform.position = viewCenter.transform.position + camRelativePos;

        Vector3 viewDirection = viewCenter.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(viewDirection);
    }
}
