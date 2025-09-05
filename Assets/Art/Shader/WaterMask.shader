Shader "Unlit/WaterMask"
 {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Color",Color) = (1,1,1,1)
        _HorizontalOffset ("ˮƽƫ��", Range(-1,1)) = 0 // ����ˮƽƫ�Ʋ���
        _VerticalOffset ("��ֱƫ��", Range(-1,1)) = 0   // �Ż���Ĵ�ֱƫ��
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
                float2 uv : TEXCOORD0; // ���UV����
                float4 vertex : POSITION;
            };

            struct v2f {
                float2 uv : TEXCOORD0; // ����UV����
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
            float3 _ObjectScale; // ͨ���ű�������������ֵ

            v2f vert (appdata v) {
                v2f o;
                 // ��ȡ��������ֵ
                _ObjectScale = float3(
                    length(unity_ObjectToWorld._m00_m01_m02),
                    length(unity_ObjectToWorld._m10_m11_m12),
                    length(unity_ObjectToWorld._m20_m21_m22)
                );
                // Ӧ�����Ų�����UV
                float2 scaledUV = v.uv * _ObjectScale.xy;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // Ӧ������ƫ�ƺ�����
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                 // ����ϵͳת����������Ϊ��תԭ�㣩
                float2 uv = (i.uv / _ObjectScale.xy) - 0.5; // �ؼ����Ų���
                
                // �Ƕ�ת���ȼ���
                float rad = radians(_Angle);
                float sinRot, cosRot;
                sincos(rad, sinRot, cosRot);

                // Ӧ����ת����
                float2 offsetUV = uv + float2(_HorizontalOffset, _VerticalOffset);
                float2 rotatedUV;
                rotatedUV.x = offsetUV.x * cosRot - offsetUV.y * sinRot;
                rotatedUV.y = offsetUV.x * sinRot + offsetUV.y * cosRot;

                rotatedUV *= _ObjectScale.xy;
                // ����ת���������Ӧ��Offsetƫ��
                rotatedUV.y -= _Offset; // ͨ��Offset��������ƫ��
                 // ������Բ����ֵ
                float ellipseVal = (rotatedUV.x * rotatedUV.x)/(_RadiusX * _RadiusX) 
                                 + (rotatedUV.y * rotatedUV.y)/(_RadiusY * _RadiusY);

                 // ���㵱ǰX��Ӧ�����Yֵ
                float maxY = _RadiusY * sqrt(max(1 - (rotatedUV.x * rotatedUV.x)/(_RadiusX * _RadiusX), 0));

                // ˫�زü�����
                float isInEllipse = step(ellipseVal, 1.0);  // ����Բ��=1
                float isUpperHalf = step(0, rotatedUV.y);    // ���ϰ�ƽ��=1
                float isAboveCurve = step(maxY, rotatedUV.y);// �������Y=1

                // ��ϲü��߼�
                float alpha = 1 - max(isInEllipse * isUpperHalf, isAboveCurve);
                
                // ��ȡ��ͼ��ɫ
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb*=_Color.rgb;
                col.a *= alpha;
                
                return col;
            }
            ENDCG
        }
    }
}
