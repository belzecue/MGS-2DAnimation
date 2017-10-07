==========================================================================
  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
  Name: MGS-2DAnimation
  Author: Mogoson   Version: 0.1.0   Date: 6/7/2017
==========================================================================
  [Summary]
    Unity plugin for make 2D animation in scene.
--------------------------------------------------------------------------
  [Environment]
    Unity 5.0 or above.
    .Net Framework 3.0 or above.
--------------------------------------------------------------------------
  [Achieve]
    RFramesAnimation£ºFrames(multi images) animation display base on Mesh
    Renderer.

    SRFramesAnimation£ºFrames(multi images) animation display base on
    Sprite Renderer.

    UIFramesAnimation£ºFrames(multi images) animation display base on UI
    component(Image).

    UVFramesAnimation£ºFrames(an frames image) animation display base on
    Mesh Renderer.

    UVAnimation£º(an frames image)UV offset animation display base on
    Mesh Renderer.
--------------------------------------------------------------------------
  [Usage]
    Attach FramesAnimation(example RFramesAnimation) or UVAnimation
    component to the Renderer gameobject.

    Add the images to the "Frames" of FramesAnimation and set the main
    texture of Renderer material.

    If use UVFramesAnimation component, set the values of "Row" and
    "Column" and click the "Apply UV Maps" button in Inspector to apply
    UV maps.
--------------------------------------------------------------------------
  [Demo]
    Demos in the path "MGS-2DAnimation\Scenes" provide reference to you.
--------------------------------------------------------------------------
  [Resource]
    https://github.com/mogoson/MGS-2DAnimation.
--------------------------------------------------------------------------
  [Contact]
    If you have any questions, feel free to contact me at mogoson@qq.com.
--------------------------------------------------------------------------