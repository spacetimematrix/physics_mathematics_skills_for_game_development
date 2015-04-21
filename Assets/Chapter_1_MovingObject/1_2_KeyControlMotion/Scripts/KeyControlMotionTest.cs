using UnityEngine;
using System.Collections;

//通过键盘控制物体的运动 
public class KeyControlMotionTest : MonoBehaviour
{   
    //物体的X位置
    float posX = 0;

    //物体的Y位置
    float posY = 0;

    //物体在x方向上的速度
    float speedX = 1;

    //物体在y方向上的速度
    float speedY = 1;

    //屏幕的右上像素在世界空间的坐标
    Vector3 ScreenRightTopPos;

    //屏幕的左下像素在世界空间的坐标
    Vector3 ScreenLeftBottomPos;

    //box的半宽度
    float boxHalfWidth;

    readonly float Sqrt2;

    public KeyControlMotionTest()
    {
        //2的开方
        Sqrt2 = Mathf.Sqrt(2);
    }

    void Start()
    {
        //将屏幕右上的像素转换为世界空间的坐标
        ScreenRightTopPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //将屏幕右下的像素转换为世界空间的坐标
        ScreenLeftBottomPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        //box的半宽度，因为box是正方形
        boxHalfWidth = transform.localScale.x * 0.5f;

        //初始位置
        transform.localPosition = new Vector3(posX, posY, 0);
    }


    void Update()
    {
        //按住左键
        if (IsLeftKey())
        {
            //按住左键且按住上键
            if (IsUpKey())
            {
                posX -= speedX / Sqrt2 * Time.deltaTime;
                posY += speedY / Sqrt2 * Time.deltaTime;
            }
            //按住左键且按住下键
            else if (IsDownKey())
            {
                posX -= speedX / Sqrt2 * Time.deltaTime;
                posY -= speedY / Sqrt2 * Time.deltaTime;
            }
            else
            {
                posX -= speedX * Time.deltaTime;
            }
        }
        //按住右键
        else if (IsRightKey())
        {
            //按住右键且按住上键
            if (IsUpKey())
            {
                posX += speedX / Sqrt2 * Time.deltaTime;
                posY += speedY / Sqrt2 * Time.deltaTime;
            }
            //按住右键且按住下键
            else if (IsDownKey())
            {
                posX += speedX / Sqrt2 * Time.deltaTime;
                posY -= speedY / Sqrt2 * Time.deltaTime;
            }
            else
            {
                posX += speedX * Time.deltaTime;
            }
        }
        //按住上键
        else if (IsUpKey())
        {
            posY += speedY * Time.deltaTime;
        }
        //按住下键
        else if (IsDownKey())
        {
            posY -= speedY * Time.deltaTime;
        }

        //边界检测 右
        if (posX + boxHalfWidth >= ScreenRightTopPos.x)
        {
            posX = ScreenRightTopPos.x - boxHalfWidth;
        }

        //边界检测 左
        if (posX - boxHalfWidth <= ScreenLeftBottomPos.x)
        {
            posX = ScreenLeftBottomPos.x + boxHalfWidth;
        }

        //边界检测 上
        if (posY + boxHalfWidth >= ScreenRightTopPos.y)
        {
            posY = ScreenRightTopPos.y - boxHalfWidth;
        }

        //边界检测 下
        if (posY - boxHalfWidth <= ScreenLeftBottomPos.y)
        {
            posY = ScreenLeftBottomPos.y + boxHalfWidth;
        }

        //设置当前物体的位置
        transform.localPosition = new Vector3(posX, posY, 0);
    }


    bool IsLeftKey()
    {
        //按住左键或者a键，都是向左
        if (Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.A))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsUpKey()
    {
        //按住上键或者w键，都是向上
        if (Input.GetKey(KeyCode.UpArrow)
            || Input.GetKey(KeyCode.W))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    bool IsDownKey()
    {
        //按住下键或者s键，都是向下
        if (Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.S))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool IsRightKey()
    {
        //按住右键或者d键，都是向右
        if (Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}


//1、获取键盘相应的方法
//2、边界检测
//3、合力方向的速度处理，勾股定理