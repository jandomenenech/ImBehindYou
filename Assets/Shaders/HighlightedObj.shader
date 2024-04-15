Shader "Custom/OutlineShader"
{
    Properties
    {
        _Color("Outline Color", Color) = (1,1,1,1)
        _Outline("Outline Width", Range (0.0, 0.1)) = .05
    }
    SubShader
    {
        Tags {"Queue"="Overlay" "RenderType"="Opaque"}
        ZWrite On
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Front
        
        Pass
        {
            Name "OUTLINE"
            Tags {"LightMode"="Always"}
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            uniform float _Outline;
            uniform float4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}

