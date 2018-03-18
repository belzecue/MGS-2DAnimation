﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TwoDAnimation.cs
 *  Description  :  Define TwoDAnimation and FramesAnimation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace Developer.TwoDAnimation
{
    /// <summary>
    /// Two dimensional animation.
    /// </summary>
    public abstract class TwoDAnimation : MonoBehaviour
    {
        #region Public Method
        /// <summary>
        /// Play animation.
        /// </summary>
        public virtual void Play()
        {
            enabled = true;
        }

        /// <summary>
        /// Pause animation.
        /// </summary>
        public virtual void Pause()
        {
            enabled = false;
        }

        /// <summary>
        /// Stop animation.
        /// </summary>
        public virtual void Stop()
        {
            enabled = false;
            Rewind();
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        public abstract void Rewind();
        #endregion
    }

    /// <summary>
    /// Two dimensional animation base on key frames.
    /// </summary>
    public abstract class FramesAnimation : TwoDAnimation
    {
        #region Field and Property
        /// <summary>
        /// Loop animation.
        /// </summary>
        public bool loop = true;

        /// <summary>
        /// Speed of animation.
        /// </summary>
        public float speed = 10;

        /// <summary>
        /// Event of animation play on last frame.
        /// </summary>
        public event Action OnLastFrame;

        /// <summary>
        /// Index of current frame.
        /// </summary>
        protected float index = 0;
        #endregion

        #region Protected Method
        protected virtual void Update()
        {
            index += speed * Time.deltaTime;
            if (index < 0 || index >= GetFramesCount())
            {
                if (loop)
                    index -= GetFramesCount() * (index < 0 ? -1 : 1);
                else
                {
                    enabled = false;
                    index = 0;
                }

                if (OnLastFrame != null)
                    OnLastFrame.Invoke();
            }
            else
                SetFrame((int)index);
        }

        /// <summary>
        /// Get image frames count.
        /// </summary>
        /// <returns>Frames count</returns>
        protected abstract int GetFramesCount();

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected abstract void SetFrame(int frameIndex);
        #endregion

        #region Public Method
        /// <summary>
        /// Rewind animation.
        /// </summary>
        public override void Rewind()
        {
            index = 0;
            SetFrame(0);
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="frameIndex">Index of rewind frame.</param>
        public void Rewind(int frameIndex)
        {
            index = Mathf.Clamp(frameIndex, 0, GetFramesCount() - 1);
            SetFrame((int)index);
        }
        #endregion
    }
}