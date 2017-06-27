/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: UIFramesAnimation.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/2/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.       UIFramesAnimation          Ignore.
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
    using UnityEngine.UI;

    [RequireComponent(typeof(Image))]
    [AddComponentMenu("Developer/Animation/UIFramesAnimation")]
    public class UIFramesAnimation : FramesAnimation
    {
        #region Property and Field
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
        }//Start()_end

        /// <summary>
        /// Get image frames count.
        /// </summary>
        /// <returns>Frames count</returns>
        protected override int GetFramesCount()
        {
            return frames.Length;
        }//GetF...()_end

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            image.sprite = frames[frameIndex];
        }//SetFrame()_end
        #endregion
    }//class_end
}//namespace_end