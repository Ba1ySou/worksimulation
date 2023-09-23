using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    Vector2 moveDir;
    public LayerMask detectLayer;

    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow) || UnityEngine.Input.GetKeyDown(KeyCode.D))   
            moveDir = Vector2.right;

        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow) || UnityEngine.Input.GetKeyDown(KeyCode.A))
            moveDir = Vector2.left;

        if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) || UnityEngine.Input.GetKeyDown(KeyCode.W))
            moveDir = Vector2.up;

        if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow) || UnityEngine.Input.GetKeyDown(KeyCode.S))
            moveDir = Vector2.down;

        if (moveDir != Vector2.zero)
        {
            if (CanMoveToDir(moveDir))
            {
                Move(moveDir);
            }
        }

        moveDir = Vector2.zero;
       
        
        
        
        
        //NewMove();    //使用InputManager控制角色，但我放弃了，没办法解决按下时是顺滑移动的问题，如果感兴趣的话可以把注释消掉玩一玩（把上面那些移动代码记得注释掉）
    }

    bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.3f, detectLayer);

        if (!hit)
            return true;
        else
        {
            if (hit.collider.GetComponent<Box>() != null)
                return hit.collider.GetComponent<Box>().CanMoveToDir(dir);
        }

        return false;
    }

    void Move(Vector2 dir)
    {
        transform.Translate(dir);
    }

    void NewMove()  //使用Unity的InputManager来控制角色
    {
        float horizontal = UnityEngine.Input.GetAxisRaw("Horizontal"); //获取水平轴移动
        float vertical = UnityEngine.Input.GetAxisRaw("Vertical");  //获取垂直轴移动

        Vector2 dir = new Vector3(horizontal, vertical, 0);//根据输入得到移动方向
        transform.Translate(dir * Time.deltaTime ); //修改位置


        //transform.Translate(dir)
    }

}
