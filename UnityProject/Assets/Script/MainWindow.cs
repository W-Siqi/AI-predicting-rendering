using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using mset;

public class MainWindow : EditorWindow {
    private Texture2D background=null;
    private Cubemap enviromentMap=null;
    private IBLWrapper iBLWrapper = null;
    private ViewCamera viewCamera = null;

    [MenuItem("点这里/光照估算与渲染")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MainWindow));
    }

    private void OnEnable()
    {
        iBLWrapper = IBLWrapper.instance;
        viewCamera = ViewCamera.instance;
    }

    private void OnGUI()
    {
        background = EditorGUILayout.ObjectField("背景图", background, typeof(Texture2D)) as Texture2D;
        enviromentMap = EditorGUILayout.ObjectField("光照环境图", enviromentMap, typeof(Cubemap)) as Cubemap;

        if (GUILayout.Button("应用",GUILayout.Height(30f)))
        {
            Background.SetBackground(background);
            iBLWrapper.SetEnvironmentMap(enviromentMap);
          
        }


        viewCamera.viewAngle = EditorGUILayout.Slider("观察角度", viewCamera.viewAngle, 0, 360);
        EditorGUILayout.Space();
        iBLWrapper.masterIntensity = EditorGUILayout.Slider("人工强度", iBLWrapper.masterIntensity, 0f, 10f);
        iBLWrapper.specularIntensity =EditorGUILayout.Slider("spec强度", iBLWrapper.specularIntensity, 0f, 10f);
        iBLWrapper.diffuseIntensity =EditorGUILayout.Slider("diffuse强度", iBLWrapper.diffuseIntensity, 0f, 10f);
        iBLWrapper.cameraExposure = EditorGUILayout.Slider("相机曝光度", iBLWrapper.cameraExposure, 0, 10f);

        GUI.BeginGroup(new Rect(100,100,300,300));
        viewCamera.Render();
        GUI.EndGroup();
    }
}
