/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  UIFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on UI(Image).
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/2/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Developer.TwoDAnimation
{
    [RequireComponent(typeof(Image))]
    [AddComponentMenu("Developer/TwoDAnimation/UIFramesAnimation")]
    public class UIFramesAnimation : FramesAnimation
    {
        #region Property and Field
        /// <summary>
        /// Frames sprite of animation.
        /// </summary>
        public Sprite[] frames;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Image image;
        #endregion

        #region Protected Method
        protected override void Start()
        {
            base.Start();
            image = GetComponent<Image>();
        }

        /// <summary>
        /// Get image frames count.
        /// </summary>
        /// <returns>Frames count</returns>
        protected override int GetFramesCount()
        {
            return frames.Length;
        }

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            image.sprite = frames[frameIndex];
        }
        #endregion
    }
}