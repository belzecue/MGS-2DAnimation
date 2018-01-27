/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  UVAnimation.cs
 *  Description  :  Define UV offset animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/1/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.TwoDAnimation
{
    [AddComponentMenu("Developer/TwoDAnimation/UVAnimation")]
    [RequireComponent(typeof(Renderer))]
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