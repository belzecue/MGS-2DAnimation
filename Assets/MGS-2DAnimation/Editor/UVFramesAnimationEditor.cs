/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  UVFramesAnimationEditor.cs
 *  Description  :  Editor for UVFramesAnimation component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/2/2017
 *  Description  :  Initial development version.
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