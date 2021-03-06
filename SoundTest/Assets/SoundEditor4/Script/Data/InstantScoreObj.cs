﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 譜面オブジェクトの生成
/// </summary>
public class InstantScoreObj : MonoBehaviour
{
    [Header("生成するオブジェクト")]
    public GameObject boolObj0;
    public GameObject boolObj1;
    public GameObject plObj;
    public GameObject enemyObj;

    [Header("生成したオブジェクト格納場所")]
    public GameObject boolObjGroup;
    public GameObject plObjGroup;
    public GameObject enemyObjGroup;

    void Awake()
    {
        InstantObj();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantObj()
    {

        for (int f = 0; f < StepData.GetStepData.Count; f++)
        {
            GameObject obj;

            //敵の攻撃位置を判別するためのオブジェクト生成
            for (int i = (int)StepData.INPUT_TEXT.EnemyAttackLane0 - 2; i <= (int)StepData.INPUT_TEXT.EnemyAttackLane5 - 2; i++)
            {
                obj = BoolObjInstant(i, f);
                obj.transform.parent = boolObjGroup.transform;
            }

            //敵の攻撃タイプを判別するためのオブジェクト生成
            obj = Instantiate(enemyObj, new Vector3((int)StepData.INPUT_TEXT.EnemyAttackLane5, f, 0), new Quaternion());
            obj.transform.parent = enemyObjGroup.transform;

            //プレイヤーのステップ位置を判別するためのオブジェクト生成
            obj = Instantiate(plObj, new Vector3((int)StepData.INPUT_TEXT.EnemyAttackLane5 + 1, f, 0), new Quaternion());
            obj.transform.parent = plObjGroup.transform;
        }

        //格子状にするためのやつ
        GameObject BoolObjInstant(int x, int y)
        {
            if (x % 2 == 0)
            {
                if (y % 2 == 0)
                {
                    return Instantiate(boolObj0, new Vector3(x, y, 0), new Quaternion());
                }
                else
                {
                    return Instantiate(boolObj1, new Vector3(x, y, 0), new Quaternion());
                }
            }
            else
            {
                if (y % 2 != 0)
                {
                    return Instantiate(boolObj0, new Vector3(x, y, 0), new Quaternion());
                }
                else
                {
                    return Instantiate(boolObj1, new Vector3(x, y, 0), new Quaternion());
                }

            }
        }
    }
}
