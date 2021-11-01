using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_camera : MonoBehaviour
{
    [SerializeField]
    Image panel;

    public float fade_speed = 10;

    // Start is called before the first frame update
    void Start()
    {
//        StartCoroutine("fade_onoff");
    }
   
    public void panel_fade()
    {
        StartCoroutine("fade_onoff");
    }

    IEnumerator fade_onoff()
    {
        Color fade_color = panel.color;

        while (fade_color.a < 1)
        {
            Debug.Log("���̵� �� �̺�Ʈ!");
            fade_color.a += Time.deltaTime;  // fade_speed;
            if(fade_color.a >= 1)
            {
                fade_color.a = 1;
            }
            panel.color = fade_color;

            yield return null;
        }
        Debug.Log("���̵� �� �̺�Ʈ �Ϸ�");
        yield return new WaitForSeconds(2f);

        while (fade_color.a > 0)
        {
            Debug.Log("���̵� �ƿ� �̺�Ʈ!");
            fade_color.a -= Time.deltaTime; // fade_speed;
            if (fade_color.a <= 0)
            {
                fade_color.a = 0;
            }
            panel.color = fade_color;
            yield return null;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
