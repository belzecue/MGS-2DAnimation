/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: UVAnimation.cs
 *  Author: Mogoson   Version: 0.1.0   Date: 6/1/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.          UVAnimation             Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/1/2017       0.1.0        Create this file.
 *************************************************************************/

using UnityEngine;

namespace Developer.TwoDAnimation
{
    [RequireComponent(typeof(Renderer))]
    [AddComponentMenu("Developer/TwoDAnimation/UVAnimation")]
    public class UVAnimation : TwoDAnimation
    {
        #region Property and Field
        /// <summary>
        /// Speed of move uv map.
        /// </summary>
        public Vector2 speed = Vector2.one;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Private Method
        protected virtual void Start()
        {
            mRenderer = GetComponent<Renderer>();
        }

        protected virtual void Update()
        {
            mRenderer.material.mainTextureOffset += speed * Time.deltaTime;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Rewind animation.
        /// </summary>
        public override void Rewind()
        {
            Rewind(Vector2.zero);
        }

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="uvMapOffset">UV map offset.</param>
        public void Rewind(Vector2 uvMapOffset)
        {
            mRenderer.material.mainTextureOffset = uvMapOffset;
        }
        #endregion
    }
}