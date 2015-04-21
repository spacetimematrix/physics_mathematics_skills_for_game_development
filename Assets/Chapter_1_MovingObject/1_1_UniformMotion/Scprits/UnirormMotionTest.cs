using UnityEngine;
using System.Collections;

//匀速运动
public class UnirormMotionTest : MonoBehaviour 
{
    //物体的位置
    float posX = 0;

    //物体在x方向上的速度
    float speed = 3;

    //屏幕的右上像素在世界空间的坐标
    Vector3 ScreenRightTopPos;

    //屏幕的左下像素在世界空间的坐标
    Vector3 ScreenLeftBottomPos;

    //box的半宽度
    float boxHalfWidth;


    //屏幕坐标的示意图
    //+-----------+(Screen.width, Screen.height)
    //|           |
    //|  screen   |
    //|           |
    //+-----------+
    //(0, 0)


    void Start()
    {
        //将屏幕右上的像素转换为世界空间的坐标
        ScreenRightTopPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        //将屏幕右下的像素转换为世界空间的坐标
        ScreenLeftBottomPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

        //box的半宽度
        boxHalfWidth = transform.localScale.x * 0.5f;
    }



	void Update () 
    {
        if (transform.localPosition.x + boxHalfWidth > ScreenRightTopPos.x
            || transform.localPosition.x - boxHalfWidth < ScreenLeftBottomPos.x)
        {
            //改变方向
            speed = -speed;
        }

        posX += speed * Time.deltaTime;

        transform.localPosition = new Vector3(posX, 0.5f, 0);
	}
}

//0、摄像机的设置 Projection Orthographic

//1、Start() 和 Update()的执行顺序与执行次数

//2、时间空间坐标与屏幕坐标的转换

//3、关于Time.deltaTime

//4、x += v;  v = -v;
