using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GetMikyled
{
    ///-////////////////////////////////////////////////////////////////////////
    ///
    public static class VectorExtensionMethods
    {
        ///-////////////////////////////////////////////////////////////////////////
        ///
        public static Vector2 AsVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }
    }

}