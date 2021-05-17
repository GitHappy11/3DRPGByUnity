using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//由于不继承Mono 需要序列化才能在检查器中显示出来
//[System.Serializable]
//public class EventVector3:UnityEvent<Vector3>
//{

//}

public class MonuseManager : MonoBehaviour
{
    public static MonuseManager Instance;

    //鼠标图片
    public Texture2D point, doorway, attack, target, arrow;

    //显示并可以在检查器中赋相应的事件
    public Action<Vector3> onMouseClick;

    //射线触碰的预制体
    RaycastHit hitInfo;

    private void Awake()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    private void Update()
    {
        SetCursorTexture();
        MouseControl();
    }


    void SetCursorTexture()
    {
        //创建射线（摄像机到鼠标的位置）
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //鼠标点击的预制体不为空
        if (Physics.Raycast(ray,out hitInfo))
        {
            //切换鼠标贴图
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    //设置鼠标图片，以及偏移（默认鼠标中心点是以图片左上角为中心点）
                    Cursor.SetCursor(arrow, new Vector2(16,16), CursorMode.Auto);
                    break;
                case "Enemy":
                    //设置鼠标图片，以及偏移（默认鼠标中心点是以图片左上角为中心点）
                    Cursor.SetCursor(attack, new Vector2(16, 16), CursorMode.Auto);
                    break;
                default:
                    break;
            }
        }
    }


    void MouseControl()
    {
        if (Input.GetMouseButtonDown(1)&&hitInfo.collider!=null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
            {
                //执行委托中的所有参数（由于需要Vector3条件，所以只有需要Vector3的参数的方法才能加入这个委托）
                onMouseClick?.Invoke(hitInfo.point);
            }
        }
    }

}
