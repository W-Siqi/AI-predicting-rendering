using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
public class Background : MonoBehaviour {
    private Material attachedMat = null;

    public static void SetBackground(Texture2D backgroundImg)
    {
        var instance = FindObjectOfType<Background>();
        if (instance != null)
        {
            instance.SetBackgroundImg(backgroundImg);
        }
    }

    private void Start()
    {
        var mr = GetComponent<MeshRenderer>();
        attachedMat = mr.sharedMaterial;
    }

    private void SetBackgroundImg(Texture2D backgroundImg)
    {
        attachedMat.mainTexture = backgroundImg;
    }
}
