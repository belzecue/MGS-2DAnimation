/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: UVFramesAnimation.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/2/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.         UVFramesAnimation             Ignore.
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

    [RequireComponent(typeof(Renderer))]
    [AddComponentMenu("Developer/Animation/UVFramesAnimation")]
    public class UVFramesAnimation : FramesAnimation
    {
        #region Property and Field
        /// <summary>
        /// Row of frames.
        /// </summary>
        [SerializeField]
        protected int row = 2;

        /// <summary>
        /// Column of frames.
        /// </summary>
        [SerializeField]
        protected int column = 5;

        /// <summary>
        /// Width of a frame.
        /// </summary>
        protected float frameWidth;

        /// <summary>
        /// Height of a frame.
        /// </summary>
        protected float frameHeight;

        /// <summary>
        /// Renderer of animation.
        /// </summary>
        protected Renderer mRenderer;
        #endregion

        #region Private Method
        protected override void Start()
        {
            base.Start();
            mRenderer = GetComponent<Renderer>();
            ApplyUVMaps();
        }

        /// <summary>
        /// Get image frames count.
        /// </summary>
        /// <returns>Frames count</returns>
        protected override int GetFramesCount()
        {
            return column * row;
        }

        /// <summary>
        /// Set current frame to renderer.
        /// </summary>
        /// <param name="frameIndex">Index of frame.</param>
        protected override void SetFrame(int frameIndex)
        {
            mRenderer.material.mainTextureOffset = new Vector2(frameIndex % column * frameWidth,
                frameIndex / column * frameHeight);
        }

        /// <summary>
        /// Apply main textute uv maps.
        /// </summary>
        protected void ApplyUVMaps()
        {
            frameWidth = 1.0f / column;
            frameHeight = 1.0f / row;
            mRenderer.material.mainTextureOffset = Vector2.zero;
            mRenderer.material.mainTextureScale = new Vector2(frameWidth, frameHeight);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Set source frames of animation.
        /// </summary>
        /// <param name="frames">Frames texture.</param>
        /// <param name="row">Row of frames.</param>
        /// <param name="column">Column of frames.</param>
        public void SetSourceFrames(Texture frames, int row, int column)
        {
            this.row = row;
            this.column = column;
            mRenderer.material.mainTexture = frames;
            ApplyUVMaps();
        }

#if UNITY_EDITOR
        /// <summary>
        /// Apply main textute uv maps [Only call this method in editor script].
        /// </summary>
        public void ApplyUVMapsInEditor()
        {
            if (mRenderer == null)
                mRenderer = GetComponent<Renderer>();
            mRenderer.sharedMaterial.mainTextureOffset = Vector2.zero;
            mRenderer.sharedMaterial.mainTextureScale = new Vector2(1.0f / column, 1.0f / row);
        }
#endif
        #endregion
    }
}