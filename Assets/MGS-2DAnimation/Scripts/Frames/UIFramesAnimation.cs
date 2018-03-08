/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on UI(Image).
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Developer.TwoDAnimation
{
    [AddComponentMenu("Developer/TwoDAnimation/UIFramesAnimation")]
    [RequireComponent(typeof(Image))]
    public class UIFramesAnimation : FramesAnimation
    {
        #region Field and Property
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
        /// <returns>Frames count.</returns>
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