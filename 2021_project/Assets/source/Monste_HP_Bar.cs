using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monste_HP_Bar : MonoBehaviour
{
    Camera Ui_Camera;
    Canvas Ui_canvas;
    RectTransform rect_Transform;
    RectTransform rect_HP;

    [HideInInspector] public Vector3 offset = Vector3.zero;
    [HideInInspector] public Transform Target_transform;


    // Start is called before the first frame update
    void Start()
    {
        Ui_canvas = GetComponentInParent<Canvas>();
        Ui_Camera = Ui_canvas.worldCamera;
        rect_Transform = Ui_canvas.GetComponent<RectTransform>();
        rect_HP = GetComponent<RectTransform>();
    }

    //업데이트 후 작동하는 함수()
    //캐릭터 이동후 따라갈수 있게 LateUpdate 함수 사용
    private void LateUpdate()
    {
        //월드 좌표를 카메라 좌표로 변경하는 함수
        var screenPos = Camera.main.WorldToScreenPoint(Target_transform.position + offset);


        if(screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }


        var localPos = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect_Transform, screenPos, Ui_Camera ,out localPos);

        rect_HP.localPosition = localPos;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    /**/
}
