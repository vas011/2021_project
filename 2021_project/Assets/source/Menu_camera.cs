using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_camera : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<GameObject>();
    }
    public void panel_hide()
    {
        Debug.Log("���̵� �̺�Ʈ!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
