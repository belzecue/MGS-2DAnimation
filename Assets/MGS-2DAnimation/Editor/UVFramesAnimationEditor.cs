/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: UVFramesAnimationEditor.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/2/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.    UVFramesAnimationEditor       Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/2/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.Animation
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(UVFramesAnimation), true)]
    [CanEditMultipleObjects]
    public class UVFramesAnimationEditor : Editor
    {
        #region Property and Field
        protected UVFramesAnimation script { get { return target as UVFramesAnimation; } }
        #endregion

        #region Public Method
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Apply UV Maps"))
            {
                script.ApplyUVMapsInEditor();
            }
        }//OnI...()_end
        #endregion
    }//class_end
}//namespace_end