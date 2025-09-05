Shader "Unlit/WaterMask"
 {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Color",Color) = (1,1,1,1)
        _HorizontalOffset ("水平偏移", Range(-1,1)) = 0 // 新增水平偏移参数
        _VerticalOffset ("垂直偏移", Range(-1,1)) = 0   // 优化后的垂直偏移
        _Offset ("Clip Offset", Float) = 0
        _RadiusX ("X Radius", Float) = 0.5
        _RadiusY ("Y Radius",Float) = 0.5
        _Angle("Angle",float) =0
        _ObjectScale("ObjectScale",Vector) =(0,0,0,0)
    }
    SubShader {
        Tags { 
            "Queue"="Transparent" 
            "RenderType"="Transparent" 
            "IgnoreProjector"="True"
        }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float2 uv : TEXCOORD0; // 添加UV坐标
                float4 vertex : POSITION;
            };

            struct v2f {
                float2 uv : TEXCOORD0; // 传递UV坐标
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _HorizontalOffset;
            float _VerticalOffset;
            float4 _Color;
            float _Offset;
            float _RadiusX;
            float _RadiusY;
            float _Angle;
            float3 _ObjectScale; // 通过脚本传递物体缩放值

            v2f vert (appdata v) {
                v2f o;
                 // 获取物体缩放值
                _ObjectScale = float3(
                    length(unity_ObjectToWorld._m00_m01_m02),
                    length(unity_ObjectToWorld._m10_m11_m12),
                    length(unity_ObjectToWorld._m20_m21_m22)
                );
                // 应用缩放补偿到UV
                float2 scaledUV = v.uv * _ObjectScale.xy;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // 应用纹理偏移和缩放
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                 // 坐标系统转换（以中心为旋转原点）
                float2 uv = (i.uv / _ObjectScale.xy) - 0.5; // 关键缩放补偿
                
                // 角度转弧度计算
                float rad = radians(_Angle);
                float sinRot, cosRot;
                sincos(rad, sinRot, cosRot);

                // 应用旋转矩阵
                float2 offsetUV = uv + float2(_HorizontalOffset, _VerticalOffset);
                float2 rotatedUV;
                rotatedUV.x = offsetUV.x * cosRot - offsetUV.y * sinRot;
                rotatedUV.y = offsetUV.x * sinRot + offsetUV.y * cosRot;

                rotatedUV *= _ObjectScale.xy;
                // 在旋转后的坐标上应用Offset偏移
                rotatedUV.y -= _Offset; // 通过Offset控制上下偏移
                 // 计算椭圆方程值
                float ellipseVal = (rotatedUV.x * rotatedUV.x)/(_RadiusX * _RadiusX) 
                                 + (rotatedUV.y * rotatedUV.y)/(_RadiusY * _RadiusY);

                 // 计算当前X对应的最大Y值
                float maxY = _RadiusY * sqrt(max(1 - (rotatedUV.x * rotatedUV.x)/(_RadiusX * _RadiusX), 0));

                // 双重裁剪条件
                float isInEllipse = step(ellipseVal, 1.0);  // 在椭圆内=1
                float isUpperHalf = step(0, rotatedUV.y);    // 在上半平面=1
                float isAboveCurve = step(maxY, rotatedUV.y);// 超过最大Y=1

                // 组合裁剪逻辑
                float alpha = 1 - max(isInEllipse * isUpperHalf, isAboveCurve);
                
                // 获取贴图颜色
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb*=_Color.rgb;
                col.a *= alpha;
                
                return col;
            }
            ENDCG
        }
    }
}
