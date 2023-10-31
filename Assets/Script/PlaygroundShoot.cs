using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundShoot : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        prefab = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Destroy(prefab);
    }
}
