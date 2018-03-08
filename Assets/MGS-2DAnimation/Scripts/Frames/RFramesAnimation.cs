/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on Renderer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.TwoDAnimation
{
    [AddComponentMenu("Developer/TwoDAnimation/RFramesAnimation")]
    [RequireComponent(typeof(Renderer))]
    public class RFramesAnimation : FramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Frames texture of animation.
        /// </summary>
        public Texture[] frames;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Protected Method
        protected override void Start()
        {
            base.Start();
            mRenderer = GetComponent<Renderer>();
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
            mRenderer.material.mainTexture = frames[frameIndex];
        }
        #endregion
    }
}