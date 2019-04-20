/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SRFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on
 *                  SpriteRenderer.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.TwoDAnimation
{
    /// <summary>
    /// Sequence frames animation base on SpriteRenderer.
    /// </summary>
    [AddComponentMenu("Mogoson/TwoDAnimation/SRFramesAnimation")]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SRFramesAnimation : SFramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// SpriteRenderer of animation.
        /// </summary>
        protected SpriteRenderer sRenderer;
        #endregion

        #region Protected Method
        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            sRenderer.sprite = frames[frameIndex];
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Init animation.
        /// </summary>
        public override void Init()
        {
            sRenderer = GetComponent<SpriteRenderer>();
        }
        #endregion
    }
}