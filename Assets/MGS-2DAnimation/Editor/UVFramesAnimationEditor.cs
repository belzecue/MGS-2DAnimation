/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: UVFramesAnimationEditor.cs
 *  Author: Mogoson   Version: 0.1.0   Date: 6/2/2017
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
 *     1.     Mogoson     6/2/2017        0.1.0       Create this file.
 *************************************************************************/

using UnityEditor;
using UnityEngine;

namespace Developer.TwoDAnimation
{
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
                script.ApplyUVMapsInEditor();
        }
        #endregion
    }
}