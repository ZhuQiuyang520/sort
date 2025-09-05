Shader "Unlit/WaterUpColor"
{
    Properties
    {
        _MainTex ("渐变图", 2D) = "white" {}
        _BrightnessTex("高光图", 2D) = "white" {}
        _Color ("颜色", Color) = (1,1,1,1)
        _Brightness ("高光亮度", Range(0, 10)) = 0
        _Contrast ("渐变亮度", Range(0, 5)) = 1
        _StencilRef ("Stencil Reference", Float) = 0
        _StencilWriteMask("_StencilWriteMask",Float) = 255
        _StencilOp ("Stencil Reference", Float) = 0
        _Stencil ("Stencil", Float) = 0
        _StencilReadMask("_StencilReadMask",Float)= 255
        _ColorMask("Color Mask",Float) = 15
        [Enum(UnityEngine.Rendering.CompareFunction)] _StencilComp ("Stencil Comparison", Float) = 8
    }
    SubShader
    {
        Tags { 
                "RenderType" = "Opaque" 
                "Queue" = "Transparent"
            }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100
        Stencil
        {
            Ref[_Stencil]
            Comp[_StencilComp]
            Pass[_StencilOp]
            ReadMask[_StencilReadMask]
            WriteMask[_StencilWriteMask]
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _BrightnessTex;
            float4 _BrightnessTex_ST;
            float4 _Color;
            float _Brightness;
            float _Contrast;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv2 = TRANSFORM_TEX(v.uv, _BrightnessTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 bncol = tex2D(_BrightnessTex, i.uv2);
                col.rgb *= _Color.rgb*_Contrast;
                bncol.a *= _Brightness;
                col.rgb += bncol.a;
                return col;
            }
            ENDCG
        }
    }
}
