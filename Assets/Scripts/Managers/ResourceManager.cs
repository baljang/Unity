using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(prefab, parent);  // Instantiate를 재귀적으로 호출 할 수 있으니 Object의 Instantiate를 호출하라고 명시를 해준 것
    }

    public void Destroy(GameObject go)  // 나중에 필요하면 시간도 넣는 거 만들어 주면 된다. 
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}