using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public delegate void RunMethod();
public class UpdatingValue
{
    private int _prevValue;
    private float _prevValueF;
    public void CheckingValue(int curValue, RunMethod rm)
    {
        if (curValue != _prevValue)
        {
            rm();
            _prevValue = curValue;
        }
    }

    public void CheckingValue(float curValue, float treshold, RunMethod rm)
    {
        if (Mathf.Abs(curValue - _prevValueF) > treshold)
        {
            rm();
            //Debug.Log($"Changing value: {curValue}");
            _prevValueF = curValue;
        }
    }
}



