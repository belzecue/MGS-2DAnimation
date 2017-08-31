/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: RFramesAnimation.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/1/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.       RFramesAnimation           Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/1/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.Animation
{
    using UnityEngine;

    [RequireComponent(typeof(Renderer))]
    [AddComponentMenu("Developer/Animation/RFramesAnimation")]
    public class RFramesAnimation : FramesAnimation
    {
        #region Property and Field
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
            mRenderer.material.mainTexture = frames[frameIndex];
        }
        #endregion
    }
}