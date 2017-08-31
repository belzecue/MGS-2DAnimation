/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: SRFramesAnimation.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/2/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.      SRFramesAnimation           Ignore.
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

    [RequireComponent(typeof(SpriteRenderer))]
    [AddComponentMenu("Developer/Animation/SRFramesAnimation")]
    public class SRFramesAnimation : FramesAnimation
    {
        #region Property and Field
        /// <summary>
        /// Frames sprite of animation.
        /// </summary>
        public Sprite[] frames;

        /// <summary>
        /// SpriteRenderer of animation.
        /// </summary>
        protected SpriteRenderer sRenderer;
        #endregion

        #region Protected Method
        protected override void Start()
        {
            base.Start();
            sRenderer = GetComponent<SpriteRenderer>();
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
            sRenderer.sprite = frames[frameIndex];
        }
        #endregion
    }
}