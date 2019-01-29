Shader "Hidden/SetAlpha" {
    SubShader {
        Pass {
            ZTest Always Cull Off ZWrite Off
            SetTexture [_CameraNormalsTexture] { combine texture }
        }
    }
}
