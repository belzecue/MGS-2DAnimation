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

using UnityEngine;

namespace Mogoson.UAnimation
{
    /// <summary>
    /// Animation base on UV offset.
    /// </summary>
    [AddComponentMenu("Mogoson/AnimationExtension/UVAnimation")]
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
        protected virtual void Start()
        {
            mRenderer = GetComponent<Renderer>();
        }

        protected virtual void Update()
        {
            mRenderer.material.mainTextureOffset += speed * coefficient * Time.deltaTime;
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