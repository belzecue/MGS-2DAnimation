﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UVFramesAnimation.cs
 *  Description  :  Define sequence frames animation base on UV offset.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.AnimationExtension
{
    /// <summary>
    /// Sequence frames animation base on UV offset.
    /// </summary>
    [AddComponentMenu("Mogoson/AnimationExtension/UVFramesAnimation")]
    [RequireComponent(typeof(Renderer))]
    public class UVFramesAnimation : FramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Row of frames.
        /// </summary>
        [SerializeField]
        protected int row = 2;

        /// <summary>
        /// Column of frames.
        /// </summary>
        [SerializeField]
        protected int column = 5;

        /// <summary>
        /// Count of image frames.
        /// </summary>
        protected int framesCount;

        /// <summary>
        /// Width of a frame.
        /// </summary>
        protected float frameWidth;

        /// <summary>
        /// Height of a frame.
        /// </summary>
        protected float frameHeight;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            mRenderer = GetComponent<Renderer>();
            framesCount = row * column;
            ApplyUVMaps();
        }

        /// <summary>
        /// Get image frames count.
        /// </summary>
        /// <returns>Frames count</returns>
        protected override int GetFramesCount()
        {
            return framesCount;
        }

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            mRenderer.material.mainTextureOffset = new Vector2(frameIndex % column * frameWidth, frameIndex / column * frameHeight);
        }

        /// <summary>
        /// Apply main textute uv maps.
        /// </summary>
        protected void ApplyUVMaps()
        {
            frameWidth = 1.0f / column;
            frameHeight = 1.0f / row;
            mRenderer.material.mainTextureOffset = Vector2.zero;
            mRenderer.material.mainTextureScale = new Vector2(frameWidth, frameHeight);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Set source frames of animation.
        /// </summary>
        /// <param name="frames">Frames texture.</param>
        /// <param name="row">Row of frames.</param>
        /// <param name="column">Column of frames.</param>
        public void SetSourceFrames(Texture frames, int row, int column)
        {
            this.row = row;
            this.column = column;
            framesCount = row * column;
            mRenderer.material.mainTexture = frames;
            ApplyUVMaps();
        }

#if UNITY_EDITOR
        /// <summary>
        /// Apply main textute uv maps (Only call this method in editor script).
        /// </summary>
        public void ApplyUVMapsInEditor()
        {
            if (mRenderer == null)
                mRenderer = GetComponent<Renderer>();

            ApplyUVMaps();
        }
#endif
        #endregion
    }
}