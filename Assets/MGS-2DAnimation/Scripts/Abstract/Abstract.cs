/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: Abstract.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/2/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.          DAnimation              Ignore.
 *     2.       FramesAnimation            Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/2/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.Animation
{
    using UnityEngine;

    public delegate void AnimationEvent();

    public abstract class DAnimation : MonoBehaviour
    {
        #region Public Method
        /// <summary>
        /// Play animation.
        /// </summary>
        public void Play()
        {
            enabled = true;
        }//Play()_end

        /// <summary>
        /// Pause animation.
        /// </summary>
        public void Pause()
        {
            enabled = false;
        }//Pause()_end

        /// <summary>
        /// Stop animation.
        /// </summary>
        public void Stop()
        {
            Pause();
            Rewind();
        }//Stop()_end

        /// <summary>
        /// Rewind animation.
        /// </summary>
        public abstract void Rewind();
        #endregion
    }//class_end

    public abstract class FramesAnimation : DAnimation
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
        }//Start()_end

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
        }//Update()_end

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
        }//Rewind()_end

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="frameIndex">Index of rewind frame.</param>
        public void Rewind(int frameIndex)
        {
            frameIndex = Mathf.Clamp(frameIndex, 0, GetFramesCount() - 1);
            index = frameIndex;
            SetFrame(frameIndex);
        }//Rewind()_end
        #endregion
    }//class_end
}//namespace_end