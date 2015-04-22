using UnityEngine;
using System.Collections;

public class AnyDirectionMotionTest : MonoBehaviour 
{

    //物体的X位置
    float posX = 0;

    //物体的Y位置
    float posY = 0;

    //物体速度
    float speed = 3;

    //物体在x方向上的速度
    float speedX;

    //物体在y方向上的速度
    float speedY;

    //屏幕的右上像素在世界空间的坐标
    Vector3 ScreenRightTopPos;

    //屏幕的左下像素在世界空间的坐标
    Vector3 ScreenLeftBottomPos;

    //box的半宽度
    float boxHalfWidth;

    //偏移弧度
    float angle = 0;

    void Start()
    {
        //将屏幕右上的像素转换为世界空间的坐标
        ScreenRightTopPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //将屏幕右下的像素转换为世界空间的坐标
        ScreenLeftBottomPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        //box的半宽度，因为box是正方形
        boxHalfWidth = transform.localScale.x * 0.5f;

        //初始位置（0，0）点
        transform.localPosition = new Vector3(posX, posY, 0);

        //angle默认为0初始x分速度
        speedX = speed * Mathf.Cos(angle);

        //angle默认为0 初始y分速度
        speedY = speed * Mathf.Sin(angle);
    }

    void Update()
    {
        //检测，如果物体出了界面，让其重新到（0，0）点
        //并且旋转的度数加(2.0f * Mathf.PI) / 10.0f
        if (posX - boxHalfWidth >= ScreenRightTopPos.x
            || posX + boxHalfWidth <= ScreenLeftBottomPos.x
            || posY - boxHalfWidth >= ScreenRightTopPos.y
            || posY + boxHalfWidth <= ScreenLeftBottomPos.y)
        {
            //归（0，0）点
            posX = 0;
            posY = 0;

            angle += (2.0f * Mathf.PI) / 10.0f;
            if(angle > (2.0f * Mathf.PI))
            {
                //经过一周后弧度重置,避免该值过大产生精度问题
                //控制旋转的弧度始终在(theta >= 0 && theta <= 2PI)
                angle -= 2.0f * Mathf.PI;
            }

            //x分速度
            speedX = speed * Mathf.Cos(angle);

            //Y分速度
            speedY = speed * Mathf.Sin(angle);
        }

        //x方向每帧时间内的位移到的值
        posX += speedX * Time.deltaTime;

        //y方向每帧时间内的位移到的值
        posY += speedY * Time.deltaTime;

        //设置该帧的位置
        transform.localPosition = new Vector3(posX, posY, 0);
    }
}
