using UnityEngine;
using System.Collections;

public static class ConstantScript
{
	////////カメラの設定////////
	//カメラのスピード
	public const float CAMERA_SPEED = 80.0f;

	public const int CAMERA_LAYER = 8;
	public const int GOAL_LAYER = 9;
	public const int FLOOR_LAYER = 10;
	public const int ROBOT_LAYER = 11;
	//public const float LOOK_LENGTH = 2.0f;

	public const float LOOK_DELAY = 1.7f;

	public const string SCENE_INGAME = "Main";
	//public const string SCENE_INGAME = "DebugScene02";


	public const float GLITCH_ATSTART_SPEED = 0.5f;

	//グリッチアニメーション長さ、1.0f->3秒. 5.0fだったら、 3/5秒で終わる
	public const float GLITCH_SPEED = 5.0f;

	//見つめる長さー＞0.2秒
	public const float LOOK_LENGTH = 0.7f;
	
}
