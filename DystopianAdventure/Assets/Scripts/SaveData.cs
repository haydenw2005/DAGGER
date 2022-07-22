//Source: https://www.youtube.com/watch?v=5roZtuqZyuw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

 [System.Serializable]
public class SaveData
{
    //public Vector3 position;
    public int testNum;
    private static SaveData _current;

    public static SaveData current
    {
        get
        {
            if(_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
        set
        {
            if(value != null)
            {
                _current = value;
            }
        }
    }
}
