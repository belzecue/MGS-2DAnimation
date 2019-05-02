/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestGifAnimation.cs
 *  Description  :  Test play gif animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/20/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Graph;
using System.Collections.Generic;
using UnityEngine;

namespace MGS.UAnimation
{
    [AddComponentMenu("MGS/UAnimation/TestGifAnimation")]
    [RequireComponent(typeof(RIFramesAnimation))]
    public class TestGifAnimation : MonoBehaviour
    {
        #region Field and Property
        public string gifName;

        private RIFramesAnimation fAnimation;
        private string gifFile;
        private bool showBtn = true;
        private bool showLoading = false;
        #endregion

        #region Private Method
        private void Start()
        {
            gifFile = string.Format("{0}/Gif/{1}.gif", Application.streamingAssetsPath, gifName);
            fAnimation = GetComponent<RIFramesAnimation>();
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(transform.position.x);
            GUILayout.BeginVertical();
            GUILayout.Space(Screen.height - transform.position.y);
            if (showBtn)
            {
                GUI.color = Color.black;
                if (GUILayout.Button("Play Gif"))
                {
                    GraphUtility.GifToFrames(gifFile, OnGifLoaded);
                    showBtn = false;
                    showLoading = true;
                }
            }
            else if (showLoading)
            {
                GUI.color = Color.black;
                GUILayout.Label("Loading...");
            }

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }

        private void OnGifLoaded(List<Texture2D> frames)
        {
            if (frames == null)
            {
                return;
            }

            fAnimation.Refresh(frames);
            fAnimation.Play();
            showLoading = false;
        }
        #endregion
    }
}