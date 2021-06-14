using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Animations;

public class CreateAnimCtrl : MonoBehaviour {
    [MenuItem("Assets/Create/CreateAnimCtrl")]
    // 执行函数
    static void Run() {
        Debug.Log("Run called");
        // Step1: 生成我们的动画控制文件;
        AnimatorController ctrl = AnimatorController.CreateAnimatorControllerAtPath("Assets/res/code_anim.controller");
        // Step2 获取我们的动画状态机;
        AnimatorStateMachine state_machine = ctrl.layers[0].stateMachine;

        // 创建我们的动画状态;
        AnimatorState[] state = new AnimatorState[10] ;
        for (int i = 0; i < 10; i++) {
            state[i] = state_machine.AddState("state" + i);
            // as 强转类型过去
            AnimationClip anim = AssetDatabase.LoadAssetAtPath("Assets/Animations/AnisWithNum/Ani" + i + ".FBX", typeof(AnimationClip)) as AnimationClip;
            state[i].motion = anim;
        }

        // 两两添加过渡;
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {  // i --> j 的transform
                // 创建每个过渡的控制变量
                ctrl.AddParameter(i + "switch" + j, AnimatorControllerParameterType.Trigger);
                // end 
                AnimatorStateTransition trans = state[i].AddTransition(state[j], false);
                trans.AddCondition(AnimatorConditionMode.If, 0, i + "switch" + j);
            }
        }
            // end 
        // 设置一个默认动画状态;
        state_machine.defaultState = state[0];

    }
}
