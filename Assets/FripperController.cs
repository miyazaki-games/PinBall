using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;

    private float flickAngle = -20;

    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetMouseButton(0))
        {
            // 右側タップ
            if (Input.mousePosition.x >= Screen.width / 2
                && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            // 左側タップ
            if (Input.mousePosition.x <= Screen.width / 2
                && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // 右側タップ終了
            if (Input.mousePosition.x >= Screen.width / 2
                && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
            }

            // 左側タップ終了
            if (Input.mousePosition.x <= Screen.width / 2
                && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        if (Input.touchCount == 2)
        {
            // 左右タップ
            if (Input.GetTouch(0).position.x >= Screen.width / 2 && Input.GetTouch(1).position.x <= Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
            else if (Input.GetTouch(1).position.x >= Screen.width / 2 && Input.GetTouch(0).position.x <= Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
        }
        if (Input.touchCount == 0)
        {
            SetAngle(this.defaultAngle);
        }
#endif
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
