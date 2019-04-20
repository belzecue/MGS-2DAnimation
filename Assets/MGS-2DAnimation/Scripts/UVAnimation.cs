/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UVAnimation.cs
 *  Description  :  Define UV offset animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.IO;
using Mogoson.UAnimation;
using UnityEngine;

namespace Mogoson.TwoDAnimation
{
    /// <summary>
    /// Animation base on UV offset.
    /// </summary>
    [AddComponentMenu("Mogoson/TwoDAnimation/UVAnimation")]
    [RequireComponent(typeof(Renderer))]
    public class UVAnimation : MonoAnimation
    {
        #region Field and Property
        /// <summary>
        /// Speed coefficient of move uv map.
        /// </summary>
        public Vector2 coefficient = Vector2.one;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Private Method
        protected virtual void Update()
        {
            mRenderer.material.mainTextureOffset += speed * coefficient * Time.deltaTime;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Init animation.
        /// </summary>
        public override void Init()
        {
            mRenderer = GetComponent<Renderer>();
        }

        /// <summary>
        /// Play animation.
        /// </summary>
        public override void Play()
        {
            enabled = IsPlaying = true;
        }

        /// <summary>
        /// Pause animation.
        /// </summary>
        public override void Pause()
        {
            enabled = IsPlaying = false;
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        public override void Rewind(float progress)
        {
            Rewind(Vector2.one * progress);
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="uvMapOffset">UV map offset.</param>
        public void Rewind(Vector2 uvMapOffset)
        {
            mRenderer.material.mainTextureOffset = uvMapOffset;
        }

        /// <summary>
        /// Refresh frames sprite of animation.
        /// </summary>
        /// <param name="animation">Animation frames, type is Texture.</param>
        public override void Refresh(object animation)
        {
            var newFrames = animation as Texture;
            if (newFrames == null)
            {
                LogUtility.LogError("[UVAnimation] Refresh error: the type of param is not Texture.");
            }
            else
            {
                mRenderer.material.mainTexture = newFrames;
            }
        }

        /// <summary>
        /// Stop animation.
        /// </summary>
        public override void Stop()
        {
            enabled = IsPlaying = false;
            Rewind(0);
        }
        #endregion
    }
}