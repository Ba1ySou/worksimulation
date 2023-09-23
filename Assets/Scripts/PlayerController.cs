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
       
        
        
        
        
        //NewMove();    //ʹ��InputManager���ƽ�ɫ�����ҷ����ˣ�û�취�������ʱ��˳���ƶ������⣬�������Ȥ�Ļ����԰�ע��������һ�棨��������Щ�ƶ�����ǵ�ע�͵���
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

    void NewMove()  //ʹ��Unity��InputManager�����ƽ�ɫ
    {
        float horizontal = UnityEngine.Input.GetAxisRaw("Horizontal"); //��ȡˮƽ���ƶ�
        float vertical = UnityEngine.Input.GetAxisRaw("Vertical");  //��ȡ��ֱ���ƶ�

        Vector2 dir = new Vector3(horizontal, vertical, 0);//��������õ��ƶ�����
        transform.Translate(dir * Time.deltaTime ); //�޸�λ��


        //transform.Translate(dir)
    }

}
