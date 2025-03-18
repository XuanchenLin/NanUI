// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.Forms;

internal class ShadowEffectConfiguration
{
    int _shadowBlur = 0;
    int _shadowOffsetX = 0;
    int _shadowOffsetY = 0;

    public int OffsetX
    {
        get => _shadowOffsetX;
        set
        {
            if (value >= -20 && value <= 20)
            {
                _shadowOffsetX = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(OffsetX)} should be -20 to 20.");

            }
        }
    }



    public int OffsetY
    {
        get => _shadowOffsetY;
        set
        {
            if (value >= -20 && value <= 20)
            {
                _shadowOffsetY = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(OffsetY)} should be -20 to 20.");

            }
        }
    }

    public int Blur
    {
        get => _shadowBlur;
        set
        {
            if (value >= -25 && value <= 25)
            {
                _shadowBlur = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(Blur)} should be -20 to 25.");
            }
        }
    }




    public int Offset => Math.Max(Math.Abs(OffsetX), Math.Abs(OffsetY));

    public int Size => Blur <= 0 && Offset == 0 ? 5 + Math.Abs(Blur) : (Blur + Math.Abs(Offset)) * 2;

    public int InsideOffset => 10;
}
