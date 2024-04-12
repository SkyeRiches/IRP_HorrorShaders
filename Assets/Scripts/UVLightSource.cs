using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UVLightSource : MonoBehaviour
{
    [SerializeField] Material uvMat;
    [SerializeField] Light light;

    // Update is called once per frame
    void Update()
    {
        uvMat.SetVector("_LightPos", light.transform.position);
        uvMat.SetVector("_LightDir", -light.transform.forward);
        uvMat.SetColor("_LightColor", light.color);
        uvMat.SetFloat("_LightRange", light.range);
    }
}
