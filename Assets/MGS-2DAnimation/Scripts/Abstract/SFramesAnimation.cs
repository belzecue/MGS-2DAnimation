/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SFramesAnimation.cs
 *  Description  :  Animation base on frames sprites.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/20/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Mogoson.TwoDAnimation
{
    /// <summary>
    /// Animation base on frames sprites.
    /// </summary>
    public abstract class SFramesAnimation : FramesAnimation
    {
        #region Field and Property
        /// <summary>
        /// Frames sprite of animation.
        /// </summary>
        [SerializeField]
        protected List<Sprite> frames = new List<Sprite>();
        #endregion

        #region Protected Method
        /// <summary>
        /// Get frames count.
        /// </summary>
        /// <returns>Frames count.</returns>
        protected override int GetFramesCount()
        {
            return frames.Count;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Refresh frames texture of animation.
        /// </summary>
        /// <param name="animation">Animation frames, type is IEnumerable<Sprite>.</param>
        public override void Refresh(object animation)
        {
            var newFrames = animation as IEnumerable<Sprite>;
            if (newFrames == null)
            {
                LogUtility.LogError("[SFramesAnimation] Refresh error: the type of param is not IEnumerable<Sprite>.");
            }
            else
            {
                frames.Clear();
                frames.AddRange(newFrames);
                Rewind(0);
            }
        }
        #endregion
    }
}