/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: Abstract.cs
 *  Author: Mogoson   Version: 0.1.0   Date: 6/2/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.       TwoDAnimation              Ignore.
 *     2.       FramesAnimation            Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/2/2017        0.1.0       Create this file.
 *************************************************************************/

using UnityEngine;

namespace Developer.TwoDAnimation
{
    public delegate void AnimationEvent();

    public abstract class TwoDAnimation : MonoBehaviour
    {
        #region Public Method
        /// <summary>
        /// Play animation.
        /// </summary>
        public void Play()
        {
            enabled = true;
        }

        /// <summary>
        /// Pause animation.
        /// </summary>
        public void Pause()
        {
            enabled = false;
        }

        /// <summary>
        /// Stop animation.
        /// </summary>
        public void Stop()
        {
            Pause();
            Rewind();
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        public abstract void Rewind();
        #endregion
    }

    public abstract class FramesAnimation : TwoDAnimation
    {
        #region Property and Field
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
        public AnimationEvent OnLastFrame;

        /// <summary>
        /// Index of current frame.
        /// </summary>
        protected float index = 0;
        #endregion

        #region Protected Method
        protected virtual void Start()
        {
            if (speed < 0)
                index = GetFramesCount();
        }

        protected virtual void Update()
        {
            index += speed * Time.deltaTime;
            if (index >= GetFramesCount() || index < 0)
            {
                if (loop)
                    index -= index / Mathf.Abs(index) * GetFramesCount();
                else
                {
                    index = Mathf.Clamp(index, 0, GetFramesCount() - 1);
                    enabled = false;
                }
                if (OnLastFrame != null)
                    OnLastFrame();
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
            frameIndex = Mathf.Clamp(frameIndex, 0, GetFramesCount() - 1);
            index = frameIndex;
            SetFrame(frameIndex);
        }
        #endregion
    }
}