using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using mset;

[ExecuteInEditMode]
public class IBLWrapper : MonoBehaviour {
    [SerializeField]
    private Sky sky;

    public static IBLWrapper _instance = null;
    public static IBLWrapper instance {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<IBLWrapper>();
            }

            return _instance;
        }
    }

    public float masterIntensity {
        get {
            return sky.MasterIntensity;
        }
        set {
            sky.MasterIntensity = value;
        }
    }

    public float diffuseIntensity {
        get {
            return sky.DiffIntensity;
        }
        set {
            sky.DiffIntensity = value;
        }
    }

    public float specularIntensity {
        get {
            return sky.SpecIntensity;
        }
        set {
            sky.SpecIntensity = value;
        }
    }

    public float cameraExposure {
        get {
            return sky.CamExposure;
        }
        set {
            sky.CamExposure = value;
        }
    }

    public void SetEnvironmentMap(Cubemap envMap)
    {
        sky.SkyboxCube = envMap;
        sky.SpecularCube = envMap;
        Selection.activeObject = sky.gameObject;   
    }

    private void Start()
    {
        if (sky == null)
        {
            sky = GetComponent<Sky>(); 
        }

        _instance = this;
    }
}
